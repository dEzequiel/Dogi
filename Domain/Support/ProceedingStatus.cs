using Domain.Common;
using Domain.Entities;

namespace Domain.Support
{
    /// <summary>
    /// Support table representing records eqivalent to IndividualProceedingStatus domain enumerator.
    /// </summary>
    public class ProceedingStatus : SupportTable
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public ICollection<IndividualProceeding>? Processees { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public ProceedingStatus(int id, string status) : base(id)
        {
            Status = status;
        }
    }
}
