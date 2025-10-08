using System.Text.Json.Serialization;

namespace Models.Enums.AssetClass;


[JsonConverter(typeof(JsonStringEnumConverter<AssetClass>))]
public enum AssetClass
{
    Equity,
    Bond,
    Futures,
    Options,
    Forex,
    Crypto,
    ETF
}