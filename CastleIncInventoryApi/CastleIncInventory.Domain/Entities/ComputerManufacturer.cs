using System.Text.RegularExpressions;

namespace CastleIncInventory.Domain.Entities
{
    public class ComputerManufacturer
    {
        public uint Id { get; set; }
        public Manufactures Name { get; set; }
        public string SerialRegex { get; set; }

        public ICollection<Computer> Computers { get; set; }

        public bool IsSerialNumberValid(string input)
        {
            var regex = new Regex(SerialRegex);
            return regex.IsMatch(input);
        }
    }
}
