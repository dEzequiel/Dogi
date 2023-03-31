using Domain.Common;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Guid Actor { get; private set; }
        public Guid Category { get; private set; }
        public Sex Sex { get; private set; }
        public bool HasChip { get; private set; } = false;
        public string Color { get; private set; } = string.Empty;
        public string? Observations { get; private set; } = string.Empty;
        public string? PickupLocation { get; private set; } = string.Empty;
        public DateTime? PickupDate { get; private set; }

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual Animal Animal { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="sex"></param>
        /// <param name="category"></param>
        /// <param name="hasChip"></param>
        /// <param name="color"></param>
        /// <param name="observations"></param>
        /// <param name="pickupLocation"></param>
        /// <param name="pickupDate"></param>
        private ReceptionDocument(
            Guid id,
            Guid actor,
            Guid category,
            Sex sex, 
            bool hasChip, 
            string color, 
            string? observations, 
            string? pickupLocation, 
            DateTime? pickupDate) : base(id)
        {
            Actor = actor;
            Sex = sex;
            Category = category;
            HasChip = hasChip;
            Color = color;
            Observations = observations;
            PickupLocation = pickupLocation;
            PickupDate = pickupDate;
        }

        /// <summary>
        /// Static Factory Pattern. Creates new ReceptionDocument in valid state.
        /// in valid state.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="actor"></param>
        /// <param name="sex"></param>
        /// <param name="category"></param>
        /// <param name="hasChip"></param>
        /// <param name="color"></param>
        /// <param name="observations"></param>
        /// <param name="pickupLocation"></param>
        /// <param name="pickupDate"></param>
        /// <returns>ReceptionDocument</returns>
        public static Result<ReceptionDocument?> Create(
            Guid id,
            Guid actor,
            Guid category,
            Sex sex,
            bool hasChip,
            string color,
            string? observations,
            string? pickupLocation,
            DateTime? pickupDate)
        {

            if(id == Guid.Empty)
                return Result.Failure<ReceptionDocument?>(DomainErrors.ReceptionDocument.ReceptionIdIsNullOrEmpty);

            if (actor == Guid.Empty)
                return Result.Failure<ReceptionDocument?>(DomainErrors.ReceptionDocument.ActorIsNullOrEmpty);
            
            if(category  == Guid.Empty)
                return Result.Failure<ReceptionDocument?>(DomainErrors.ReceptionDocument.CategoryIsNullOrEmpty);

            if(string.IsNullOrEmpty(color))
                return Result.Failure<ReceptionDocument?>(DomainErrors.ReceptionDocument.ColorIsEmpty);

            return new ReceptionDocument(id, actor, category, sex, hasChip, color, observations, pickupLocation, pickupDate);

        }
    }
}
