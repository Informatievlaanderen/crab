namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System;
    using AggregateSource;
    using Generators.Guid;
    using Newtonsoft.Json;

    public class CrabSubaddressId : IntegerValueObject<CrabSubaddressId>
    {
        private static readonly Guid CrabSubAddressIdNamespace = new Guid("bf5e5c82-eaaa-48d8-b928-44336e6e4308");

        public CrabSubaddressId([JsonProperty("value")] int subaddressId) : base(subaddressId) { }

        public Guid CreateDeterministicId() => Deterministic.Create(CrabSubAddressIdNamespace, $"subadres-{Value}");
    }
}
