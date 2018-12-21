namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;
    using NodaTime;

    public class CrabTimestamp : InstantValueObject<CrabTimestamp>
    {
        public CrabTimestamp([JsonProperty("value")] Instant date) : base(date) { }
    }
}
