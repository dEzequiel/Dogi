namespace Domain.Enums.Authorization;

/// <summary>
/// Represents permissions.
/// </summary>
public enum Permissions
{
    CanRegister = 1,
    CanDelete = 2,
    CanCreateMedicalRecord = 3,
    CanCheckMedicalRecord = 4,
    CanCloseMedicalRecord = 5,
    CanVaccine = 6,
    CanAssigneRole = 7,
    CanCreateAdoptionPending = 8,
    CanCompleteAdoption = 9,
    CanReadUser = 10,
    CanReadAdoptionApplications = 11,
    CanReadVaccinationCard = 12,
    CanReadMedicalRecord = 13,
    CanReadCage = 14,
    CanReadPerson = 15,
    CanReadAnimalChip = 16,
    CanReadIndividualProceeding = 17,
}