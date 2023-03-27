namespace Domain.Common
{
    public abstract class Entity
    {

        /// <summary>
        /// Entity identifier
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Entity constructor that initializes its identifier
        /// </summary>
        /// <param name="id">Entity identifier</param>
        public Entity(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Operator equals
        /// </summary>
        /// <param name="first">First entity to be comparer</param>
        /// <param name="second">Second entity to be comparer</param>
        /// <returns></returns>
        public static bool operator ==(Entity? first, Entity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        /// <summary>
        /// Operator not equal
        /// </summary>
        /// <param name="first">First entity to be comparer</param>
        /// <param name="second">Second entity to be comparer</param>
        /// <returns></returns>
        public static bool operator !=(Entity? first, Entity? second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Object Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (obj is not Entity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        /// <summary>
        /// IEquatable implementation
        /// </summary>
        /// <param name="other">Entity to match</param>
        /// <returns></returns>
        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return other.Id == Id;
        }

        /// <summary>
        /// GetHasCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode() * 13;
        }
    }
}
}
