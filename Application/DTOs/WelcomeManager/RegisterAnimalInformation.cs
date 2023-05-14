using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.WelcomeManager
{
    public class RegisterAnimalInformation
    {
        public ReceptionDocumentWithAnimalInformation ReceptionDocumentWithAnimalOwnerInfo { get; set; } = null!;
        
        public ReceptionDocumentWithIndividualProceeding ReceptionDocumentWithIndividualProceeding { get; set; } = null!;

        public RegisterAnimalInformation(ReceptionDocumentWithAnimalInformation receptionDocumentWithAnimalOwnerInfo, ReceptionDocumentWithIndividualProceeding receptionDocumentWithIndividualProceeding)
        {
            ReceptionDocumentWithAnimalOwnerInfo = receptionDocumentWithAnimalOwnerInfo;
            ReceptionDocumentWithIndividualProceeding = receptionDocumentWithIndividualProceeding;
        }
    }
}