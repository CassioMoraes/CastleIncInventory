namespace CastleIncInventory.Domain.Entities
{
    public class Computer
    {
        public uint Id { get; set; }
        public uint ComputerManufacturerId { get; set; }
        public string SerialNumber { get; set; }
        public string Specifications { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpirationDate { get; set; }
        public DateTime CreateDate { get; set; }

        public ComputerManufacturer Manufacturer { get; set; }
        public ICollection<LinkComputerStatus> ComputerStatuses { get; set; }
        public LinkComputerUser ComputerUser { get; set; }
    }
}
