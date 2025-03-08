namespace CastleIncInventory.Domain.Entities
{
    public class LinkComputerStatus
    {
        public uint Id { get; set; }
        public uint ComputerId { get; set; }
        public uint ComputerStatusId { get; set; } 
        public DateTime AssignDate { get; set; }
        public Computer Computer { get; set; }
        public ComputerStatus ComputerStatus { get; set; }
    }
}
