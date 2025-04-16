using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AvtoElon.API.Demo.Helpers
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Currency
    {
        [EnumMember(Value = "usd")]
        USD,
        [EnumMember(Value = "uzs")]
        UZS,
        [EnumMember(Value = "rub")]
        RUB
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Category
    {
        [EnumMember(Value = "default")]
        Default,
        [EnumMember(Value = "yengil_avtomobillar")]
        YengilAvtomobillar,
        [EnumMember(Value = "extiyot_qisimlar")]
        EhtiyotQismlar,
        [EnumMember(Value = "xizmatlar")]
        Xizmatlar,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Location
    {
        [EnumMember(Value = "Andijon")]
        Andijon,
        [EnumMember(Value = "Buxoro")]
        Buxoro,
        [EnumMember(Value = "Farg'ona")]
        Fargona,
        [EnumMember(Value = "Jizzax")]
        Jizzax,
        [EnumMember(Value = "Xorazm")]
        Xorazm,
        [EnumMember(Value = "Navoiy")]
        Navoiy,
        [EnumMember(Value = "Namangan")]
        Namangan,
        [EnumMember(Value = "Samarkand")]
        Samarkand,
        [EnumMember(Value = "Sirdaryo")]
        Sirdaryo,
        [EnumMember(Value = "Toshkent")]
        Toshkent,
        [EnumMember(Value = "Surxandaryo")]
        Surxandaryo,
        [EnumMember(Value = "Qashqadaryo")]
        Qashqadaryo
    }
}
