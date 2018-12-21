namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;

    public class CrabSubCantonId : IntegerValueObject<CrabSubCantonId>
    {
        public CrabSubCantonId([JsonProperty("value")] int subCantonId) : base(subCantonId) { }
    }

}
