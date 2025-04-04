using System.ComponentModel;

namespace CastleIncInventory.Domain.Entities
{
    public enum OperationalStatus
    {
        [Description("New")]
        New,
        [Description("In Use")]
        InUse,
        [Description("Available")]
        Available,
        [Description("In Maintance")]
        InMaintance,
        [Description("Retired")]
        Retired
    }
}