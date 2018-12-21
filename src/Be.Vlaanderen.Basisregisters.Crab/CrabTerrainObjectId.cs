namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System;
    using AggregateSource;
    using Generators.Guid;
    using Newtonsoft.Json;

    public class CrabTerrainObjectId : IntegerValueObject<CrabTerrainObjectId>
    {
        private static readonly Guid CrabBuildingNamespace = new Guid("75114296-f457-468d-9fc1-346570704de1");

        public CrabTerrainObjectId([JsonProperty("value")] int terrainObjectId) : base(terrainObjectId) { }

        public Guid CreateDeterministicId() => Deterministic.Create(CrabBuildingNamespace, $"terreinobjectid-{Value}");
    }
}
