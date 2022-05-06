using System;

namespace SmoothDrivingAPI.Domain.Enums
{
    public class EnumUtils<TEnum>
    {
        public string GetEnumName(Enum enumValue)
        {
            return Enum.GetName(typeof(TEnum), enumValue);
        }

        public TEnum EnumNameToEnumValue(Enum enumValue)
        {
            string enumName = GetEnumName(enumValue);
            return (TEnum)Enum.Parse(typeof(TEnum), enumName, true);
        }
    }
}