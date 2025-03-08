using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Shared.Extensions;

namespace CastleIncInventory.Domain.DataTransfer
{
    public class ComputerUpsert
    {
        public uint Id { get; set; }
        public uint ManufacturerId { get; set; }
        public string SerialNumber { get; set; }
        public string Specifications { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpirationDate { get; set; }
        public DateTime? AssignedOn { get; set; }
        public string AssignedTo { get; set; } = string.Empty;
        public string Manufacturer { get; set; }
        public string OperacionalStatus { get; set; } = "New";

        public Computer ToComputer()
        {
            return new Computer
            {
                Id = Id,
                ComputerManufacturerId = ManufacturerId,
                CreateDate = CreateDate,
                PurchaseDate = PurchaseDate,
                WarrantyExpirationDate = WarrantyExpirationDate,
                SerialNumber = SerialNumber,
                Specifications = Specifications,
                ImageUrl = ImageUrl,
            };
        }

        public ComputerUpsert() { }

        public ComputerUpsert(Computer computer)
        {
            var currentStatus = computer?.ComputerStatuses?.OrderByDescending(c => c.AssignDate).FirstOrDefault();
            var computerUser = computer?.ComputerUser?.User;

            Id = computer.Id;
            ManufacturerId = computer.ComputerManufacturerId;
            CreateDate = computer.CreateDate;
            PurchaseDate = computer.PurchaseDate;
            WarrantyExpirationDate = computer.WarrantyExpirationDate;
            SerialNumber = computer.SerialNumber;
            Specifications = computer.Specifications;
            ImageUrl = computer.ImageUrl;
            Manufacturer = computer.Manufacturer.Name.ToString();
            OperacionalStatus = currentStatus.ComputerStatus?.LocalizedName.GetDescription() ?? string.Empty;
            AssignedOn = computer?.ComputerUser?.AssignDate;
            AssignedTo = computerUser is null ?
                "Not assigned yet." :
                $"{computer.ComputerUser.User.FirstName} {computer.ComputerUser.User.LastName}";
        }
    }
}