using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARC.PIForm.Model.Entities;

namespace ARC.PIForm.Service.Interfaces
{
    public interface ICandidateService
    {
        PersonalInformationEntity InsertCandidate(PersonalInformationEntity personalInformation);
        bool UpdateCandidate(PersonalInformationEntity personalInformation);
        //List<CandidateDisplayEntity> GetCandidateDetails(int candidateId);
        ContactInfoEntity InsertContactDetails(ContactInfoEntity contactInfoEntity, int candidateId);

        EducationalDetailsEntity InsertEducationalDetails(EducationalDetailsEntity educationalDetailsEntity, int candidateId);

        PreviousEmploymentDetails InsertPreviousEmployment(PreviousEmploymentDetails previousEmploymentEntity, int candidateId);

        ReferenceDetails InsertReferenceDetails(ReferenceDetails referenceDetails, int candidateId);
        AdditionalDetailsEntity InsertAdditionalDetails(AdditionalDetailsEntity additionalDetailsEntity, int candidateId);
    }
}
