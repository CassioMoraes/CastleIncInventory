using System.ComponentModel;
using System.Reflection;

namespace CastleIncInventory.Shared.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value) 
        { 
            var field = value.GetType().GetField(value.ToString()); 

            if (field is null)
                return value.ToString();

            var customAttribute = field.GetCustomAttribute(typeof(DescriptionAttribute));

            if (customAttribute is null)
                return value.ToString();

            var descriptionAttribute = customAttribute as DescriptionAttribute;

            return descriptionAttribute == null ? value.ToString() : descriptionAttribute.Description; }
    }
}
