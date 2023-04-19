using Domain.Common;
using Domain.Exceptions;
using Domain.Exceptions.Result;

namespace Domain.Entities
{
    /// <summary>
    /// It is a document filled out by the collection services at the time of action or by the protector when receiving the animal.
    /// </summary>
    public class ReceptionDocument : Entity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public bool? HasChip { get; set; }
        public string? Observations { get; set; } = string.Empty;
        public string? PickupLocation { get; set; } = string.Empty;
        public DateTime? PickupDate { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual IndividualProceeding? IndividualProceeding { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>W
        /// <param name="hasChip"></param>
        /// <param name="observations"></param>
        /// <param name="pickupLocation"></param>
        /// <param name="pickupDate"></param>
        public ReceptionDocument(Guid id) : base(id) { }
        public ReceptionDocument() : base(Guid.NewGuid()) { }

        public ReceptionDocument(
            Guid id,
            bool? hasChip, 
            string? observations, 
            string? pickupLocation, 
            DateTime? pickupDate) : base(id)
        {
            HasChip = hasChip;
            Observations = observations;
            PickupLocation = pickupLocation;
            PickupDate = pickupDate;
        }

        /// <summary>
        /// Static Factory Pattern. Creates new ReceptionDocument in valid state.
        /// in valid state.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hasChip"></param>
        /// <param name="observations"></param>
        /// <param name="pickupLocation"></param>
        /// <param name="pickupDate"></param>
        /// <returns>ReceptionDocument</returns>
        public virtual Result<ReceptionDocument> Verify(
            ReceptionDocument document)
        {
            if(document.Id == Guid.Empty)
                return Result.Failure<ReceptionDocument>(DomainErrors.ReceptionDocument.ReceptionIdIsNullOrEmpty);

            return Result.Success(document);
        }
    }
}
