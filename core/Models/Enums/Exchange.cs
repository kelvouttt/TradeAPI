using System.Text.Json.Serialization;

namespace Models.Enums.Exchange;


[JsonConverter(typeof(JsonStringEnumConverter<Exchange>))]
public enum Exchange
{
    NYSE,
    TSE,
    LSE,
    NSE,
    ASX,
    NASDAQ,
    SSE,
    HKEX,
    Euronext
}