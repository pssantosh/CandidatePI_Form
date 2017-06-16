using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARC.PIForm.Data.Repository;
using ARC.PIForm.Model;
using ARC.PIForm.Model.Entities;
using ARC.PIForm.Service.Interfaces;

namespace ARC.PIForm.Service.Services
{
    public class CandidateService : ICandidateService
    {
        private CandidateRepository _candidateRepository;
        private CandidateRepository CandidateRepository
        {
            get { return _candidateRepository ?? new CandidateRepository(); }
            set { _candidateRepository = value; }
        }

        public PersonalInformationEntity InsertCandidate(PersonalInformationEntity personalInformation)
        {
            var candidate = ConvertToServiceEntity(personalInformation);

            var candidateId = CandidateRepository.InsertCandidate(candidate);
            InsertDependents(personalInformation, candidateId);
  
            //InsertEmploymentDetails(candidateDisplayEntity, candidateId);
            //InsertMonthlyEmoluments(candidateDisplayEntity, candidateId);

            personalInformation.CandidateId = candidateId;
            return personalInformation;
        }

        public ContactInfoEntity InsertContactDetails(ContactInfoEntity contactInfoEntity, int candidateId)
        {
            InsertContact(contactInfoEntity, candidateId);
            InsertAddress(contactInfoEntity, candidateId);
            return contactInfoEntity;
        }

        public EducationalDetailsEntity InsertEducationalDetails(EducationalDetailsEntity educationalDetailsEntity, int candidateId)
        {
            InsertEducation(educationalDetailsEntity, candidateId);
            return educationalDetailsEntity;
        }

        public PreviousEmploymentDetails InsertPreviousEmployment(PreviousEmploymentDetails previousEmploymentDetails, int candidateId)
        {
            if(!string.IsNullOrEmpty(previousEmploymentDetails.PreviousEmployment1?.OrganizationName))
                CandidateRepository.InsertEmploymentDetails(ConvertToEmploymentDetailsEntity(previousEmploymentDetails.PreviousEmployment1,candidateId));
            if (!string.IsNullOrEmpty(previousEmploymentDetails.PreviousEmployment2?.OrganizationName))
                CandidateRepository.InsertEmploymentDetails(ConvertToEmploymentDetailsEntity(previousEmploymentDetails.PreviousEmployment2, candidateId));

            return previousEmploymentDetails;
        }

        public ReferenceDetails InsertReferenceDetails(ReferenceDetails referenceDetails, int candidateId)
        {
            InsertReferences(referenceDetails, candidateId);
            return referenceDetails;
        }

        public AdditionalDetailsEntity InsertAdditionalDetails(AdditionalDetailsEntity additionalDetailsEntity, int candidateId)
        {
            CandidateRepository.InsertAdditionalDetails(ConvertToAdditionalDetailsEntity(additionalDetailsEntity,
                candidateId));
            return additionalDetailsEntity;
        }

        public bool UpdateCandidate(PersonalInformationEntity personalInformation)
        {
            throw new NotImplementedException();
        }

        //public List<CandidateDisplayEntity> GetCandidateDetails(int candidateId)
        //{
        //    throw new NotImplementedException();
        //}

        private Candidate ConvertToServiceEntity(PersonalInformationEntity candidate)
        {
            return new Candidate()
            {
                Prefix = candidate.Prefix,
                FirstName = candidate.FirstName,
                MiddleName = candidate.MiddleName,
                LastName = candidate.LastName,
                BirthDate = candidate.BirthDate,
                Anniversary = candidate.AnniversaryDate,
                Gender = candidate.Gender,
                MaritalStatus = candidate.MaritalStatus,
                Qualification = candidate.Qualification,
                WorkExperience = candidate.WorkExperience,
                PanCardNumber = candidate.PanCardNumber,
                AadharCardNumber = candidate.AadharCardNumber,
                UanNumber = candidate.UanNumber,
                PassportNumber = candidate.PassportNumber,
                PassportExpiry = candidate.PassportExpiry,
                PassportIssuePlace = candidate.PassportIssuePlace,
                VisaExpiry = candidate.VisaExpiry,
                Visa = candidate.Visa
            };
        }
        private void InsertDependents(PersonalInformationEntity personalInformation, int candidateId)
        {
            CandidateRepository.InsertDependents(ConvertToDependentsEntity(personalInformation, candidateId));
        }

        private CandidateDependents ConvertToDependentsEntity(PersonalInformationEntity personalInformation, int candidateId)
        {
            return new CandidateDependents()
            {
                CandidateId = candidateId,
                FatherBirthDate = personalInformation.FatherBirthDate,
                FatherName = personalInformation.FatherName,
                MotherName = personalInformation.MotherName,
                MotherBirthDate = personalInformation.MotherBirthDate,
                SpouseName = personalInformation.SpouseName,
                SpouseBirthDate = personalInformation.SpouseBirthDate,
                FirstChildName = personalInformation.FirstChildName,
                FirstChildBirthDate = personalInformation.FirstChildBirthDate,
                SecondChildName = personalInformation.SecondChildName,
                SecondChildBirthDate = personalInformation.SecondChildBirthDate
            };
        }

        private void InsertContact(ContactInfoEntity contactInfoEntity, int candidateId)
        {
            CandidateRepository.InsertContact(ConvertToContactEntity(contactInfoEntity, candidateId));
        }

        private CandidateContact ConvertToContactEntity(ContactInfoEntity contactInfoEntity, int candidateId)
        {
            return new CandidateContact()
            {
                CandidateId = candidateId,
                EmailAddress = contactInfoEntity.EmailAddress,
                MobileNumber = contactInfoEntity.MobileNumber,
                EmergencyContactNumber = contactInfoEntity.EmergencyContact,
                LandlineContactNumber = contactInfoEntity.LandlineContact
            };
        }

        private void InsertAddress(ContactInfoEntity contactInfoEntity, int candidateId)
        {
            CandidateRepository.InsertAddress(ConvertToAddressEntity(candidateId, contactInfoEntity.CurrentAddress, Enums.AddressTypes.Current.ToString()));
            CandidateRepository.InsertAddress(ConvertToAddressEntity(candidateId, contactInfoEntity.PermanentAddress, Enums.AddressTypes.Permanent.ToString()));
        }

        private static CandidateAddress ConvertToAddressEntity(int candidateId, CandidateAddressEntity addressEntity, string addressType)
        {
            return new CandidateAddress()
            {
                CandidateId = candidateId,
                AddressType = addressType,
                Address = addressEntity.Address,
                State = addressEntity.State,
                City = addressEntity.City,
                PinCode = addressEntity.PinCode,
                Country = addressEntity.Country,
                Landmark = addressEntity.Landmark
            };
        }

        private void InsertEducation(EducationalDetailsEntity educationalDetailsEntity, int candidateId)
        {
            if(!string.IsNullOrEmpty(educationalDetailsEntity.Education1?.UniversityName))
                CandidateRepository.InsertEducationDetails(ConvertToEducationalDetails(educationalDetailsEntity.Education1, candidateId));

            if (!string.IsNullOrEmpty(educationalDetailsEntity.Education2?.UniversityName))
                CandidateRepository.InsertEducationDetails(ConvertToEducationalDetails(educationalDetailsEntity.Education2, candidateId));

            if (!string.IsNullOrEmpty(educationalDetailsEntity.Education3?.UniversityName))
                CandidateRepository.InsertEducationDetails(ConvertToEducationalDetails(educationalDetailsEntity.Education3, candidateId));

            if (!string.IsNullOrEmpty(educationalDetailsEntity.Education4?.UniversityName))
                CandidateRepository.InsertEducationDetails(ConvertToEducationalDetails(educationalDetailsEntity.Education4, candidateId));
        }


        private void InsertReferences(ReferenceDetails referenceDetails, int candidateId)
        {
            if (!string.IsNullOrEmpty(referenceDetails.CurrentReferences1?.Name))
                CandidateRepository.InsertReferences(ConvertoToReferenceEntity(referenceDetails.CurrentReferences1,
                    candidateId));
            if (!string.IsNullOrEmpty(referenceDetails.CurrentReferences2?.Name))
                CandidateRepository.InsertReferences(ConvertoToReferenceEntity(referenceDetails.CurrentReferences2,
                    candidateId));
            if (!string.IsNullOrEmpty(referenceDetails.PreviousReferences1?.Name))
                CandidateRepository.InsertReferences(ConvertoToReferenceEntity(referenceDetails.PreviousReferences1,
                    candidateId));
            if (!string.IsNullOrEmpty(referenceDetails.PreviousReferences2?.Name))
                CandidateRepository.InsertReferences(ConvertoToReferenceEntity(referenceDetails.PreviousReferences2,
                    candidateId));
        }

        private CandidateReferences ConvertoToReferenceEntity(References references, int candidateId)
        {
            return new CandidateReferences()
            {
                CandidateId = 1,
                Name = references.Name,
                Duration = references.Duration,
                Designation = references.Designation,
                Organization = references.Organization,
                Email = references.Email,
                Mobile = references.Email,
                AlternateNumber = references.AlternateNumber
            };
        }

        private CandidateEducationDetails ConvertToEducationalDetails(EducationEntity education, int candidateId)
        {
            return new CandidateEducationDetails()
            {
                CandidateId = candidateId,
                UniversityName = education.UniversityName,
                UniversityAddress = education.UniversityAddress,
                UniversityContactNumber = education.UniversityContactNumber,
                RegistrationNumber = education.RegistrationNumber,
                Course = education.Course,
                Specialization = education.Specialization,
                CollegeName = education.CollegeName,
                CollegeAddress = education.CollegeAddress,
                CollegeContact = education.CollegeContact,
                CourseStartDate = education.CourseStartDate,
                CourseEndDate = education.CourseEndDate,
                FileNamePath = String.Empty
            };
        }

        private CandidateAdditionalDetails ConvertToAdditionalDetailsEntity(AdditionalDetailsEntity additionalDetailsEntity, int candidateId)
        {
            return new CandidateAdditionalDetails()
            {
                CandidateId = 1,
                VisaDenial = additionalDetailsEntity.VisaDenial,
                VisaDenialDetails = additionalDetailsEntity.VisaDenialDetails,
                OverseasAssignment = additionalDetailsEntity.OverseasAssignment,
                OverseasAssignmentDetails = additionalDetailsEntity.OverseasAssignmentDetails,
                EmidsFriendsRelatives = additionalDetailsEntity.EmidsFriendsRelatives,
                EmidsFriendsRelativesDetails = additionalDetailsEntity.EmidsFriendsRelativesDetails,
                Illness = additionalDetailsEntity.Illness,
                IllnessDetails = additionalDetailsEntity.IllnessDetails,
                OtherEmployerCommittment = additionalDetailsEntity.OtherEmployerCommittment,
                OtherEmployerCommittmentDetails = additionalDetailsEntity.OtherEmployerCommittmentDetails,
                Prosecution = additionalDetailsEntity.Prosecution,
                ProsecutionDetails = additionalDetailsEntity.ProsecutionDetails,
                TravelAbroad = additionalDetailsEntity.TravelAbroad,
                TravelAbroadDetails = additionalDetailsEntity.TravelAbroadDetails,
                TravelAbroadDuration = additionalDetailsEntity.TravelAbroadDuration
            };
        }


        private CandidateEmploymentDetails ConvertToEmploymentDetailsEntity(PreviousEmploymentEntity previousEmploymentEntity, int candidateId)
        {
            return new CandidateEmploymentDetails()
            {
                CandidateId = 1,
                OrganizationName = previousEmploymentEntity.OrganizationName,
                OrganizationLocation = previousEmploymentEntity.OrganizationLocation,
                Designation = previousEmploymentEntity.Designation,
                EmployeeCode = previousEmploymentEntity.EmployeeCode,
                HumanResourceName = previousEmploymentEntity.HumanResourceName,
                HumanResourceContact = previousEmploymentEntity.HumanResourceContact,
                HumanResourceDesignation = previousEmploymentEntity.HumanResourceDesignation,
                EmploymentStartDate = previousEmploymentEntity.EmploymentStartDate,
                EmploymentEndDate = previousEmploymentEntity.EmploymentEndDate,
                AnnualCompensation = previousEmploymentEntity.AnnualCompensation,
                ReasonToLeave = previousEmploymentEntity.ReasonForLeaving
            };
        }

        //private void InsertMonthlyEmoluments(CandidateDisplayEntity candidateDisplayEntity, int candidateId)
        //{
        //    CandidateRepository.InsertEmoluments(ConvertToEmolumentsEntity(candidateDisplayEntity, candidateId));
        //}

        //private CandidateEmoluments ConvertToEmolumentsEntity(CandidateDisplayEntity candidateDisplayEntity, int candidateId)
        //{
        //    return new CandidateEmoluments()
        //    {
        //        CandidateId = candidateId,
        //        Basic = candidateDisplayEntity.MonthlyEmoluments.Basic,
        //        HRA = candidateDisplayEntity.MonthlyEmoluments.HRA,
        //        Allowances = candidateDisplayEntity.MonthlyEmoluments.Allowances,
        //        FixedOthers = candidateDisplayEntity.MonthlyEmoluments.FixedOthers,
        //        Medical = candidateDisplayEntity.MonthlyEmoluments.Medical,
        //        Food = candidateDisplayEntity.MonthlyEmoluments.Food,
        //        LTA = candidateDisplayEntity.MonthlyEmoluments.LTA,
        //        VariableOthers = candidateDisplayEntity.MonthlyEmoluments.VariableOthers,
        //        PF = candidateDisplayEntity.MonthlyEmoluments.PF,
        //        MonthlyGross = candidateDisplayEntity.MonthlyEmoluments.MonthlyGross,
        //        AnnualGross = candidateDisplayEntity.MonthlyEmoluments.AnnualGross
        //    };
        //}

        public string GetCandidatePIFormUrl(ref NewCandidateLinkRequest model)
        {
            NewCandidateLinkRequest datamodel = CandidateRepository.CheckPIFormLinkExists(model.EmailAddress);
            if (datamodel != null && !string.IsNullOrWhiteSpace(datamodel.UniqueId))
            {
                //Existing 
                model.State         =   1;
                model.UniqueId      =   datamodel.UniqueId;
                model.ExpiryDate    =   datamodel.ExpiryDate;
            }
            else
            {
                //Create new
                model.State     =   2;
                model.UniqueId  =   Guid.NewGuid().ToString().ToUpper();
                CandidateRepository.CreatePIFormLink(model);
            }

            string message = string.Empty;
            switch (model.State)
            {
                case 0:
                    message = "Error creating the PI Form Link. Please get in touch with Admin.";
                    break;
                case 1:
                    message = "Existing active PI Link is available and will expire by " + model.ExpiryDate.ToShortDateString();
                    break;
                case 2:
                    message = "Success! The above PI Link will be active till " + model.ExpiryDate.ToShortDateString();
                    break;
                default:
                    message = "Error creating the PI Form Link. Please get in touch with Admin.";
                    break;
            }
            return message;
        }

        public List<CandidateDetail> GetCandidateSearchList(CandidateFilterData filterData)
        {
            return CandidateRepository.GetCandidateSearchList(filterData);
        }
    }
}
