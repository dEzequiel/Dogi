using Domain.Common;
using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Support table representing records eqivalent to IndividualProceedingStatus domain enumerator.
    /// </summary>
    public class IndividualProceedingStatus
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Status.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual ICollection<IndividualProceeding>? IndivualProceedings { get; set; } = null!;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public IndividualProceedingStatus(int id, string status)
        {
            Status = status;
        }

    }
}
