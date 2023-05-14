namespace Application.DTOs.WelcomeManager
{
    public class RegisterInformation
    {
        public ReceptionDocumentWithAnimalInformation? ReceptionDocumentWithAnimalOwnerInfo { get; set; }
        public ReceptionDocumentWithIndividualProceeding? ReceptionDocumentWithIndividualProceeding { get; set; }

        ///<summary>
        /// Constructor.
        ///</summary>
        ///<param name="receptionDocumentWithAnimalOwnerInfo"></param>
        ///<param name="receptionDocumentWithIndividualProceeding"></param>
        public RegisterInformation(ReceptionDocumentWithAnimalInformation receptionDocumentWithAnimalOwnerInfo, ReceptionDocumentWithIndividualProceeding receptionDocumentWithIndividualProceeding)
        {
            ReceptionDocumentWithAnimalOwnerInfo = receptionDocumentWithAnimalOwnerInfo;
            ReceptionDocumentWithIndividualProceeding = receptionDocumentWithIndividualProceeding;
        }

        public RegisterInformation() {}
    }
}