using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC.PIForm.Model.Entities
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? Anniversary { get; set; }
        public string Qualification { get; set; }
        public string WorkExperience { get; set; }
        public string PanCardNumber { get; set; }
        public string AadharCardNumber { get; set; }
        public string UanNumber { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? PassportExpiry { get; set; }
        public string PassportIssuePlace { get; set; }
        public string Visa { get; set; }
        public DateTime? VisaExpiry { get; set; }
    }

    public class CandidateContact
    {
        public int CandidateContactId { get; set; }
        public int CandidateId { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string LandlineContactNumber { get; set; }
        public string EmergencyContactNumber { get; set; }
    }

    public class CandidateAddress
    {
        public int CandidateAddressId { get; set; }
        public int CandidateId { get; set; }
        public string AddressType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public string Landmark { get; set; }    
    }

    public class CandidateDependents
    {
        public int CandidateDependentId { get; set; }
        public int CandidateId { get; set; }
        public string FatherName { get; set; }
        public DateTime? FatherBirthDate { get; set; }
        public string MotherName { get; set; }
        public DateTime? MotherBirthDate { get; set; }
        public string SpouseName { get; set; }
        public DateTime? SpouseBirthDate { get; set; }
        public string FirstChildName { get; set; }
        public DateTime? FirstChildBirthDate { get; set; }
        public string SecondChildName { get; set; }
        public DateTime? SecondChildBirthDate { get; set; }

    }

    public class CandidateEducationDetails
    {
        public int CandidateEducationDetailsId { get; set; }
        public int CandidateId { get; set; }
        public string UniversityName { get; set; }
        public string UniversityAddress { get; set; }
        public string UniversityContactNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string Course { get; set; }
        public string Specialization { get; set; }
        public string CollegeName { get; set; }
        public string CollegeAddress { get; set; }
        public string CollegeContact { get; set; }   
        public string CourseStartDate { get; set; }
        public string CourseEndDate { get; set; }
        public string FileNamePath { get; set; }
    }

    public class CandidateTrainings
    {
        public int CandidateTrainingsId { get; set; }
        public int CandidateId { get; set; }
        public string Trainings { get; set; }
        public string Institute { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Certifications { get; set; }
    }

    public class CandidateEmploymentDetails
    {
        public int CandidateEmploymentDetailsId { get; set; }
        public int CandidateId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationLocation { get; set; }
        public string Designation { get; set; }
        public string EmployeeCode { get; set; }
        public string HumanResourceName { get; set; }
        public string HumanResourceDesignation { get; set; }
        public string HumanResourceContact { get; set; }
        public string EmploymentStartDate { get; set; }
        public string EmploymentEndDate { get; set; }
        public decimal AnnualCompensation { get; set; }
        public string ReasonToLeave { get; set; }
    }

    public class CandidateEmoluments
    {
        public int CandidateEmolumentsId { get; set; }
        public int CandidateId { get; set; }
        public decimal Basic { get; set; }
        public decimal HRA { get; set; }
        public decimal Allowances { get; set; }
        public decimal FixedOthers { get; set; }
        public decimal Medical { get; set; }
        public decimal Food { get; set; }
        public decimal LTA { get; set; }
        public decimal VariableOthers { get; set; }
        public decimal PF { get; set; }
        public decimal MonthlyGross { get; set; }
        public decimal AnnualGross { get; set; }
    }

    public class CandidateReferences
    {
        public int CandidateReferencesId { get; set; }
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Designation { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string AlternateNumber { get; set; }
    }

    public class CandidateAdditionalDetails
    {
        public int CandidateAddtionalDetailsId { get; set; }
        public int CandidateId { get; set; }
        public bool VisaDenial { get; set; }
        public string VisaDenialDetails{ get; set; }
        public bool OverseasAssignment{ get; set; }
        public string OverseasAssignmentDetails { get; set; }
        public bool EmidsFriendsRelatives{ get; set; }
        public string EmidsFriendsRelativesDetails{ get; set; }
        public bool Illness{ get; set; }
        public string IllnessDetails{ get; set; }
        public bool Prosecution{ get; set; }
        public string ProsecutionDetails { get; set; }
        public bool OtherEmployerCommittment{ get; set; }
        public string OtherEmployerCommittmentDetails { get; set; }
        public bool TravelAbroad{ get; set; }
        public string TravelAbroadDetails{ get; set; }
        public string TravelAbroadDuration{ get; set; }
    }
}
