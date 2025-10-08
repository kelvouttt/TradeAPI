using System.Text.Json.Serialization;

namespace Models.Enums.Currency;


[JsonConverter(typeof(JsonStringEnumConverter<Currency>))]
public enum Currency
{
    USD,
    JPY,
    AUD,
    GBP,
    CNY,
    HKD,
    EUR
}