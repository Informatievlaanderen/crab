namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System;
    using AggregateSource;
    using Generators.Guid;
    using Newtonsoft.Json;

    public class CrabMunicipalityId : IntegerValueObject<CrabMunicipalityId>
    {
        private static readonly Guid CrabMunicipalityIdNamespace = new Guid("caea7019-4129-4c3d-bd6b-447059de1c9e");

        public CrabMunicipalityId([JsonProperty("value")] int municipalityId) : base(municipalityId) { }

        public Guid CreateDeterministicId() => Deterministic.Create(CrabMunicipalityIdNamespace, $"gemeenteid-{Value}");
    }
}
