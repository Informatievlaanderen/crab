namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System;
    using AggregateSource;
    using Generators.Guid;
    using Newtonsoft.Json;

    public class CrabStreetNameId : IntegerValueObject<CrabStreetNameId>
    {
        private static readonly Guid CrabStreetNameIdNamespace = new Guid("ec097c16-d280-408f-89b1-725fdcf87065");

        public CrabStreetNameId([JsonProperty("value")] int streetNameId) : base(streetNameId) { }

        public Guid CreateDeterministicId() => Deterministic.Create(CrabStreetNameIdNamespace, $"straatnaamid-{Value}");
    }
}
