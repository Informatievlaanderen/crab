namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;

    public class CrabIdentifierTerrainObject : StringValueObject<CrabIdentifierTerrainObject>
    {
        public CrabIdentifierTerrainObject([JsonProperty("value")] string identifierTerrainObject) : base(identifierTerrainObject) { }
    }
}
