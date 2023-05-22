namespace Application.Managers.Abstraction
{
    public interface IWelcomeManager : IApplicationServiceBase
    {
        /// <summary>
        /// Register a new animal at the kennel. It is analyzed if the animal has a chip and the information 
        /// of the chip and owner is stored. The animal is assigned to a zone depending on whether or not the owner has a chip.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="adminData"></param>
        /// <returns>Information about register. Includ ReceptionDocument, AnimalChip and IndividualProceeding if process.</returns>
        Task<RegisterInformation> RegisterAnimal(RegisterInformation data, AdminData adminData);
    }
}