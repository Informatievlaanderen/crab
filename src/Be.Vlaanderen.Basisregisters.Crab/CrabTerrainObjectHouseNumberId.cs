namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;

    public class CrabTerrainObjectHouseNumberId : IntegerValueObject<CrabTerrainObjectHouseNumberId>
    {
        public CrabTerrainObjectHouseNumberId([JsonProperty("value")] int terrainObjectHouseNumberId) : base(terrainObjectHouseNumberId) { }
    }
}
