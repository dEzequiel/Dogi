using Domain.Common;
using Domain.Support;

namespace Domain.Entities
{
    public class Cage : Entity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public int? ZoneId { get; set; }
        public bool IsOccupied { get; set; } = false;

        public virtual AnimalZone? AnimalZone { get; set; } = null!;
        public virtual IndividualProceeding? IndividualProceeding { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zoneId"></param>
        /// <param name="isOccupied"></param>
        public Cage(Guid id) : base(id) { }

        public Cage(Guid id, int? zoneId, bool isOccupied) : base(id)
        {
            ZoneId = zoneId;
            IsOccupied = isOccupied;
        }
    }
}
