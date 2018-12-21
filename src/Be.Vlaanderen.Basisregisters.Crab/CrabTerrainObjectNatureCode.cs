namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;

    public class CrabTerrainObjectNatureCode : StringValueObject<CrabTerrainObjectNatureCode>
    {
        public CrabTerrainObjectNatureCode([JsonProperty("value")] string terrainObjectNatureCode) : base(terrainObjectNatureCode) { }
    }
}
