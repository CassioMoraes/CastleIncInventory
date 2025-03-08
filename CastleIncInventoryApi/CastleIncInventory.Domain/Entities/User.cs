namespace CastleIncInventory.Domain.Entities
{
    public class User
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname { get { return $"{FirstName} {LastName}"; } }
        public string EmailAddress { get; set; }
        public DateTime CreateDate { get; set; }
        public LinkComputerUser LinkComputerUser { get; set; }
    }
}
