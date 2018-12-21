namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System;
    using AggregateSource;
    using Generators.Guid;
    using Newtonsoft.Json;

    public class CrabHouseNumberId : IntegerValueObject<CrabHouseNumberId>
    {
        private static readonly Guid CrabHouseNumberIdNamespace = new Guid("7e6ebef8-08f0-4f92-8de5-c5af50d54e80");

        public CrabHouseNumberId([JsonProperty("value")] int houseNumberId) : base(houseNumberId) { }

        public Guid CreateDeterministicId() => Deterministic.Create(CrabHouseNumberIdNamespace, $"huisnummerid-{Value}");
    }
}
