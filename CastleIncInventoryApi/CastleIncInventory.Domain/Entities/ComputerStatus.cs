namespace CastleIncInventory.Domain.Entities
{
    public class ComputerStatus
    {
        public uint Id { get; set; }
        public OperationalStatus LocalizedName { get; set; }

        public ICollection<LinkComputerStatus> ComputerLink { get; set; }
    }
}
