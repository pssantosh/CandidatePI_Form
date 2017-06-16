using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC.PIForm.Model.Entities
{

    public class PersonalInformationEntity
    {
        public int CandidateId { get; set; }
        [StringLength(50)]
        public string Prefix { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        [RegularExpression("^(a-z|A-Z|0-9)*[^#$%^&*()]*$", ErrorMessage = "The first name cannot include any of the following characters: #$%^&*()")]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression("^(a-z|A-Z|0-9)*[^#$%^&*()]*$", ErrorMessage = "The last name cannot include any of the following characters: #$%^&*()")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Birth Date is required.")]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required(ErrorMessage = "Blood group is required.")]
        public string BloodGroup { get; set; }
        public DateTime? AnniversaryDate { get; set; }

        [Required(ErrorMessage = "Qualification is required.")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Previous work experience is required.")]
        public string WorkExperience { get; set; }
        public string PanCardNumber { get; set; }
        public string AadharCardNumber { get; set; }
        public string UanNumber { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? PassportExpiry { get; set; }
        public string PassportIssuePlace { get; set; }
        public string Visa { get; set; }
        public DateTime? VisaExpiry { get; set; }

        [Required(ErrorMessage = "Father's name is required.")]
        [StringLength(100)]
        public string FatherName { get; set; }
        public DateTime? FatherBirthDate { get; set; }

        [Required(ErrorMessage = "Mother's name is required.")]
        [StringLength(100)]
        public string MotherName { get; set; }
        public DateTime? MotherBirthDate { get; set; }

        [StringLength(100)]
        public string SpouseName { get; set; }
        public DateTime? SpouseBirthDate { get; set; }
        [StringLength(100)]
        public string FirstChildName { get; set; }
        public DateTime? FirstChildBirthDate { get; set; }
        [StringLength(100)]
        public string SecondChildName { get; set; }
        public DateTime? SecondChildBirthDate { get; set; }
    }

    public class ContactInfoEntity
    {
        [Required(ErrorMessage = "Email address is needed.")]
        [StringLength(200)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is not in correct format.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Mobile number is needed.")]
        [MaxLength(12)]
        [MinLength(6)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Landline number is needed.")]
        [MaxLength(12)]
        [MinLength(6)]
        public string LandlineContact { get; set; }
        [Required(ErrorMessage = "Emergency contact is needed.")]
        [MaxLength(12)]
        [MinLength(6)]
        public string EmergencyContact { get; set; }
        [Required]
        public CandidateAddressEntity CurrentAddress { get; set; }
        [Required]
        public CandidateAddressEntity PermanentAddress { get; set; }
    }
    public class CandidateAddressEntity
    {
        [Required(ErrorMessage = "Address is needed.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is needed.")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is needed.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Country is needed.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Pincode is needed.")]
        public string PinCode { get; set; }
        public string Landmark { get; set; }
    }

    public class EducationalDetailsEntity
    {
        public EducationEntity Education1 { get; set; }
        public EducationEntity Education2 { get; set; }
        public EducationEntity Education3 { get; set; }
        public EducationEntity Education4 { get; set; }
        public TrainingsEntity Trainings { get; set; }
    }
    public class PreviousEmploymentDetails
    {
        public PreviousEmploymentEntity PreviousEmployment1 { get; set; }
        public PreviousEmploymentEntity PreviousEmployment2 { get; set; }
    }

    public class ReferenceDetails
    {
        public References CurrentReferences1 { get; set; }
        public References CurrentReferences2 { get; set; }
        public References PreviousReferences1 { get; set; }
        public References PreviousReferences2 { get; set; }
    }

  public class EducationEntity
    {
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
    }

    public class TrainingsEntity
    {
        public string TrainingsAttended { get; set; }
        public string Institute { get; set; }
        public string TrainingFromDate { get; set; }
        public string TrainingToDate { get; set; }
        public string Certifications { get; set; }
    }

    public class PreviousEmploymentEntity
    {
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
        public string ReasonForLeaving { get; set; }
    }

    public class References
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Designation { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string AlternateNumber { get; set; }
    }

    public class AdditionalDetailsEntity
    {
        [Required]
        public bool VisaDenial { get; set; }
        public string VisaDenialDetails { get; set; }
        [Required]
        public bool OverseasAssignment { get; set; }
        public string OverseasAssignmentDetails { get; set; }
        [Required]
        public bool EmidsFriendsRelatives { get; set; }
        public string EmidsFriendsRelativesDetails { get; set; }
        [Required]
        public bool Illness { get; set; }
        public string IllnessDetails { get; set; }
        [Required]
        public bool Prosecution { get; set; }
        public string ProsecutionDetails { get; set; }
        [Required]
        public bool OtherEmployerCommittment { get; set; }
        public string OtherEmployerCommittmentDetails { get; set; }
        [Required]
        public bool TravelAbroad { get; set; }
        public string TravelAbroadDetails { get; set; }
        public string TravelAbroadDuration { get; set; }
    }

    public class MonthlyEmoluments
    {
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

    public class NewCandidateLinkRequest
    {
        public string Name { get; set; }
        //[Required(ErrorMessage = "Email address is needed.")]
        //[StringLength(200)]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Email address is not in correct format.")]
        public string EmailAddress { get; set; }

        public string PIFormLink { get; set; }

        public string UniqueId { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int State { get; set; }  //0 - error; 1 - warning; 2 - success
    }

    public class CandidateFilterData
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

    public class LinkRequestCandidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
