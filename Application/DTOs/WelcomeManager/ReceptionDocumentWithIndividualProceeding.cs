using Domain.Entities;

namespace Application.DTOs.WelcomeManager
{
    public class ReceptionDocumentWithIndividualProceeding
    {

        public ReceptionDocument ReceptionDocument { get; set; } = null!;
        public IndividualProceeding IndividualProceeding { get; set; } = null!;

        ///<summary>
        /// Constructor.
        ///</summary>
        ///<param name="receptionDocument"></param>
        ///<param name="individualProceeding"></param>
        public ReceptionDocumentWithIndividualProceeding(ReceptionDocument receptionDocument, IndividualProceeding individualProceeding)
        {
            ReceptionDocument = receptionDocument;
            IndividualProceeding = individualProceeding;
        }

        public ReceptionDocumentWithIndividualProceeding() {}
    }
}