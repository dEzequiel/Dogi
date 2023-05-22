using Domain.Common;
using Domain.Support;

namespace Domain.Entities
{
    /// <summary>
    /// Represents the cage where the animal is located.
    /// </summary>
    public class Cage : Entity
    {
        /// <summary>
        /// Cage number.
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Cage zone.
        /// </summary>
        public int? AnimalZoneId { get; set; }
        /// <summary>
        /// Cage occupation status.
        /// </summary>
        public bool IsOccupied { get; set; } = false;

        /// <summary>
        /// Animal zone relationship.
        /// </summary>
        public virtual AnimalZone? AnimalZone { get; set; } = null!;
        /// <summary>
        /// Individual proceeding relationship.
        /// </summary>
        public virtual IndividualProceeding? IndividualProceeding { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zoneId"></param>
        /// <param name="individualProceeding"></param>
        /// <param name="number"></param>
        /// <param name="isOccupied"></param>
        public Cage(Guid id, int? zoneId, Guid? individualProceeding, int number, bool isOccupied) : base(id)
        {
            AnimalZoneId = zoneId;
            IsOccupied = isOccupied;
            Number = number;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public Cage(Guid id) : base(id) { }
        /// <summary>
        /// Constructor
        /// </summary>
        public Cage() : base(Guid.NewGuid()) { }
    }
}
