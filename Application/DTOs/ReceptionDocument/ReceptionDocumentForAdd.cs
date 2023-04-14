namespace Application.DTOs.ReceptionDocument
{
    /// <summary>
    /// Transfer ReceptionDocument data objects between Application layer.
    /// </summary>
    public class ReceptionDocumentForAdd
    {
        public bool HasChip { get; set; }
        public string? Observations { get; private set; } = string.Empty;
        public string? PickupLocation { get; private set; } = string.Empty;
        public DateTime? PickupDate { get; private set; }
    }
}
