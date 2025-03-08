namespace CastleIncInventory.Domain.Entities
{
    public class LinkComputerUser
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public uint ComputerId { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime? AssignEndDate { get; set; }
        public User User { get; set; }
        public Computer Computer { get; set; }
    }
}
