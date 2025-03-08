namespace CastleIncInventory.Domain.Entities
{
    public class ComputerStatus
    {
        public uint Id { get; set; }
        public OperacionalStatus LocalizedName { get; set; }

        public ICollection<LinkComputerStatus> ComputerLink { get; set; }
    }
}
