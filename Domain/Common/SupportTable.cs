namespace Domain.Common
{
    public abstract class SupportTable
    {
        /// <summary>
        /// SupportTable records primary key.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// SupportTable constructor that initializes its identifier
        /// </summary>
        /// <param name="id"></param>
        public SupportTable(int id)
        {
            Id = id;
        }
    }
}
