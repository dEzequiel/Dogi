using Domain.Common;
using Domain.Exceptions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Animal : Entity
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        public Guid DocumentReceptionId { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Color { get; private set; }
        public bool IsMedicallyCheck { get; private set; } = false;

        /// <summary>
        /// Navigation properties.
        /// </summary>
        public virtual ReceptionDocument ReceptionDocument { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="documentReceptionId"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="color"></param>
        private Animal(
            Guid id,
            Guid documentReceptionId,
            string name,
            int age,
            string color) : base(id)
        {
            DocumentReceptionId = documentReceptionId;
            Name = name;
            Age = age;
            Color = color;
        }

        /// <summary>
        /// Static Factory Pattern. Creates new Animal in valid state.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="documentReceptionId"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Result<Animal> Create(
            Guid id,
            Guid documentReceptionId,
            string name,
            int age,
            string color)
        {
            return new Animal(id, documentReceptionId, name, age, color);
        }

    }
}
