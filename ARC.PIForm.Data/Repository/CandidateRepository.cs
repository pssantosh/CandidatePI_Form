using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARC.PIForm.Model.Entities;
using Dapper;

namespace ARC.PIForm.Data.Repository
{
    public class CandidateRepository
    {
        private SqlConnectionFactory _sqlConnectionFactory;
        private SqlConnectionFactory SqlConnectionFactory
        {
            get { return _sqlConnectionFactory ?? new SqlConnectionFactory(); }
            set { _sqlConnectionFactory = value; }
        }

        public int InsertCandidate(Candidate candidate)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO Candidate "
                          + " (Prefix, FirstName, MiddleName, LastName, Gender, MaritalStatus, BirthDate, Anniversary,  Qualification, WorkExperience, PanCardNumber, AadharCardNumber, UanNumber, PassportNumber, PassportExpiry, PassportIssuePlace, Visa, VisaExpiry) "
                          + " VALUES (@Prefix, @FirstName, @MiddleName, @LastName, @Gender, @MaritalStatus, @BirthDate, @Anniversary, "
                          + "  @Qualification, @WorkExperience, @PanCardNumber, @AadharCardNumber, @UanNumber, @PassportNumber, @PassportExpiry, @PassportIssuePlace, @Visa, @VisaExpiry)"
                          + " SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = conn.Query<int>(sql, new
                {
                    candidate.Prefix,
                    candidate.FirstName,
                    candidate.MiddleName,
                    candidate.LastName,
                    candidate.Gender,
                    candidate.MaritalStatus,
                    candidate.BirthDate,
                    candidate.Anniversary,
                    candidate.Qualification,
                    candidate.WorkExperience,
                    candidate.PanCardNumber,
                    candidate.AadharCardNumber,
                    candidate.UanNumber
                            ,
                    candidate.PassportNumber,
                    candidate.PassportExpiry,
                    candidate.PassportIssuePlace,
                    candidate.Visa,
                    candidate.VisaExpiry
                }).Single();
                return result;
            }
        }

        public int InsertAddress(CandidateAddress candidateAddress)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO CandidateAddress "
                          + " (CandidateId, AddressType, Address, City, PinCode, State, Country, Landmark) "
                          + " VALUES (@CandidateId, @AddressType, @Address, @City, @PinCode, @State, @Country, @Landmark)"
                          + " SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = conn.Query<int>(sql, new { candidateAddress.CandidateId, candidateAddress.AddressType, candidateAddress.Address, candidateAddress.City, candidateAddress.PinCode, candidateAddress.State, candidateAddress.Country, candidateAddress.Landmark }).Single();
                return result;
            }
        }

        public int InsertContact(CandidateContact candidateContact)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO CandidateContact "
                          + " (CandidateId, EmailAddress, MobileNumber, LandlineContactNumber, EmergencyContactNumber) "
                          + " VALUES (@CandidateId, @EmailAddress, @MobileNumber, @LandlineContactNumber, @EmergencyContactNumber)"
                          + " SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = conn.Query<int>(sql, new { candidateContact.CandidateId, candidateContact.EmailAddress, candidateContact.MobileNumber, candidateContact.LandlineContactNumber, candidateContact.EmergencyContactNumber }).Single();
                return result;
            }
        }

        public int InsertDependents(CandidateDependents candidateDependents)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO CandidateDependents "
                          + " (CandidateId, FatherName, FatherBirthDate, MotherName, MotherBirthDate, SpouseName, SpouseBirthDate, FirstChildName, FirstChildBirthDate, SecondChildName, SecondChildBirthDate ) "
                          + " VALUES (@CandidateId, @FatherName, @FatherBirthDate, @MotherName, @MotherBirthDate, @SpouseName, @SpouseBirthDate, @FirstChildName, @FirstChildBirthDate, @SecondChildName, @SecondChildBirthDate )"
                          + " SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = conn.Query<int>(sql, new { candidateDependents.CandidateId, candidateDependents.FatherName, candidateDependents.FatherBirthDate, candidateDependents.MotherName, candidateDependents.MotherBirthDate, candidateDependents.SpouseName, candidateDependents.SpouseBirthDate, candidateDependents.FirstChildName, candidateDependents.FirstChildBirthDate, candidateDependents.SecondChildName, candidateDependents.SecondChildBirthDate }).Single();
                return result;
            }
        }

        public int InsertEducationDetails(CandidateEducationDetails candidateEducationDetails)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO CandidateEducationDetails "
                          + " (CandidateId, UniversityName, UniversityAddress, UniversityContactNumber, RegistrationNumber, "
                          + " Course, Specialization, CollegeName, CollegeAddress, CollegeContact, CourseStartDate, CourseEndDate, FileNamePath) "
                          + " VALUES (@CandidateId, @UniversityName, @UniversityAddress, @UniversityContactNumber, @RegistrationNumber, "
                          + " @Course, @Specialization, @CollegeName, @CollegeAddress, @CollegeContact, @CourseStartDate, @CourseEndDate, @FileNamePath) "
                          + " SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = conn.Query<int>(sql, new
                {
                    candidateEducationDetails.CandidateId,
                    candidateEducationDetails.UniversityName,
                    candidateEducationDetails.UniversityAddress,
                    candidateEducationDetails.UniversityContactNumber,
                    candidateEducationDetails.RegistrationNumber,
                    candidateEducationDetails.Course,
                    candidateEducationDetails.Specialization,
                    candidateEducationDetails.CollegeName,
                    candidateEducationDetails.CollegeAddress,
                    candidateEducationDetails.CollegeContact,
                    candidateEducationDetails.CourseStartDate,
                    candidateEducationDetails.CourseEndDate,
                    candidateEducationDetails.FileNamePath
                }).Single();
                return result;
            }
        }

        public int InsertTrainings(CandidateTrainings candidateTrainings)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO CandidateEducationDetails "
                          + " (CandidateId, Trainings, Institute, StartDate, EndDate, Certifications) "
                          + " VALUES (@CandidateId, @Trainings, @Institute, @StartDate, @EndDate, @Certifications)"
                          + " SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = conn.Query<int>(sql, new { candidateTrainings.CandidateId, candidateTrainings.Trainings, candidateTrainings.Institute, candidateTrainings.StartDate, candidateTrainings.EndDate, candidateTrainings.Certifications }).Single();
                return result;
            }
        }

        public int InsertEmploymentDetails(CandidateEmploymentDetails candidateEmploymentDetails)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO CandidateEmploymentDetails "
                          + " (CandidateId, OrganizationName, OrganizationLocation, Designation, EmployeeCode, HumanResourceName, HumanResourceDesignation, HumanResourceContact, EmploymentStartDate, EmploymentEndDate, AnnualCompensation, ReasonToLeave ) "
                          + " VALUES (@CandidateId, @OrganizationName, @OrganizationLocation, @Designation, @EmployeeCode, @HumanResourceName, @HumanResourceDesignation, @HumanResourceContact, @EmploymentStartDate, @EmploymentEndDate, @AnnualCompensation, @ReasonToLeave )"
                          + " SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = conn.Query<int>(sql, new
                {
                    candidateEmploymentDetails.CandidateId,
                    candidateEmploymentDetails.OrganizationName,
                    candidateEmploymentDetails.OrganizationLocation,
                    candidateEmploymentDetails.Designation,
                    candidateEmploymentDetails.EmployeeCode,
                    candidateEmploymentDetails.HumanResourceName,
                    candidateEmploymentDetails.HumanResourceDesignation,
                    candidateEmploymentDetails.HumanResourceContact,
                    candidateEmploymentDetails.EmploymentStartDate,
                    candidateEmploymentDetails.EmploymentEndDate,
                    candidateEmploymentDetails.AnnualCompensation,
                    candidateEmploymentDetails.ReasonToLeave
                }).Single();
                return result;
            }
        }

        public int InsertReferences(CandidateReferences candidateReferences)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO CandidateReferences "
                          + " (CandidateId, Name, Duration, Designation, Organization, Email, Mobile, AlternateNumber) "
                          + " VALUES (@CandidateId, @Name, @Duration, @Designation, @Organization, @Email, @Mobile, @AlternateNumber)"
                          + " SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = conn.Query<int>(sql, new
                {
                    candidateReferences.CandidateId,
                    candidateReferences.Name,
                    candidateReferences.Duration,
                    candidateReferences.Designation,
                    candidateReferences.Organization,
                    candidateReferences.Email,
                    candidateReferences.Mobile,
                    candidateReferences.AlternateNumber
                }).Single();
                return result;
            }
        }

        public int InsertAdditionalDetails(CandidateAdditionalDetails candidateAdditionalDetails)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO CandidateAddtionalDetails "
                          + " (CandidateId, VisaDenial, VisaDenialDetails, OverseasAssignment,OverseasAssignmentDetails, EmidsFriendsRelatives, EmidsFriendsRelativesDetails, Illness, IllnessDetails, Prosecution,"
                          + "  ProsecutionDetails, OtherEmployerCommittment, OtherEmployerCommittmentDetails, TravelAbroad,TravelAbroadDetails, TravelAbroadDuration) "
                          + " VALUES (@CandidateId, @VisaDenial, @VisaDenialDetails, @OverseasAssignment, @OverseasAssignmentDetails, @EmidsFriendsRelatives, @EmidsFriendsRelativesDetails, @Illness, @IllnessDetails, @Prosecution,"
                          + "  @ProsecutionDetails, @OtherEmployerCommittment, @OtherEmployerCommittmentDetails, @TravelAbroad, @TravelAbroadDetails, @TravelAbroadDuration)"
                          + " SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = conn.Query<int>(sql, new
                {
                    candidateAdditionalDetails.CandidateId,
                    candidateAdditionalDetails.VisaDenial,
                    candidateAdditionalDetails.VisaDenialDetails,
                    candidateAdditionalDetails.OverseasAssignment,
                    candidateAdditionalDetails.OverseasAssignmentDetails,
                    candidateAdditionalDetails.EmidsFriendsRelatives,
                    candidateAdditionalDetails.EmidsFriendsRelativesDetails,
                    candidateAdditionalDetails.Illness,
                    candidateAdditionalDetails.IllnessDetails,
                    candidateAdditionalDetails.Prosecution,
                    candidateAdditionalDetails.ProsecutionDetails,
                    candidateAdditionalDetails.OtherEmployerCommittment,
                    candidateAdditionalDetails.OtherEmployerCommittmentDetails,
                    candidateAdditionalDetails.TravelAbroad,
                    candidateAdditionalDetails.TravelAbroadDetails,
                    candidateAdditionalDetails.TravelAbroadDuration
                }).Single();
                return result;
            }

        }

        //public int InsertEmoluments(CandidateEmoluments candidateEmoluments)
        //{
        //    using (var conn = SqlConnectionFactory.CreateConnection())
        //    {
        //        var sql = "INSERT INTO CandidateEmoluments "
        //                  + " (CandidateId, Basic, HRA, Allowances, FixedOthers, Medical, Food, LTA, VariableOthers, PF, MonthlyGross, AnnualGross ) "
        //                  + " VALUES (@CandidateId, @Basic, @HRA, @Allowances, @FixedOthers, @Medical, @Food, @LTA, @VariableOthers, @PF, @MonthlyGross, @AnnualGross)"
        //                  + " SELECT CAST(SCOPE_IDENTITY() as int)";
        //        var result = conn.Query<int>(sql, new { candidateEmoluments.CandidateId, candidateEmoluments.Basic, candidateEmoluments.HRA, candidateEmoluments.Allowances, candidateEmoluments.FixedOthers, candidateEmoluments.Medical, candidateEmoluments.Food, candidateEmoluments.LTA, candidateEmoluments.VariableOthers, candidateEmoluments.PF, candidateEmoluments.MonthlyGross, candidateEmoluments.AnnualGross }).Single();
        //        return result;
        //    }
        //}
        public bool UpdateCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Candidate> GetCandidateDetails(int candidateId)
        {
            throw new NotImplementedException();
        }

        public NewCandidateLinkRequest CheckPIFormLinkExists(string emailAddress)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "SELECT TOP 1 CAST(UniqueKey AS VARCHAR(255)) As UniqueId, ExpiryDate FROM dbo.CandidateAdmin WHERE CandidateEmail = @emailAddress"
                          + " AND CONVERT(date, getdate()) <= ExpiryDate "
                          + " ORDER BY CandidateAdminId DESC";
                var result = conn.Query<NewCandidateLinkRequest>(sql, new { emailAddress }).FirstOrDefault();
                return result;
            }
        }

        public void CreatePIFormLink(NewCandidateLinkRequest model)
        {
            using (var conn = SqlConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO CandidateAdmin ([CandidateName], [CandidateEmail], [UniqueKey], [CreatedOn], [ExpiryDate], [IsLocked], [IsFinalized])"
                          + " VALUES (@Name, @EmailAddress, @UniqueId, GETDATE(), CONVERT(DATE, (DATEADD(DAY, 14, GETDATE()))), 0, 0) ";
                conn.Execute(sql, new { model.Name, model.EmailAddress, model.UniqueId });
            }
        }
    }
}
