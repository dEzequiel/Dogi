﻿namespace Domain.Enums;

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
}