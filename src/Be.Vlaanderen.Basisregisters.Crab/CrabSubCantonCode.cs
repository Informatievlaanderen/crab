namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;

    public class CrabSubCantonCode : StringValueObject<CrabSubCantonCode>
    {
        public CrabSubCantonCode([JsonProperty("value")] string subCantonCode) : base(subCantonCode) { }
    }
}
