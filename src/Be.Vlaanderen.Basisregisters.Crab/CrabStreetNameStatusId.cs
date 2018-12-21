namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;

    public class CrabStreetNameStatusId : IntegerValueObject<CrabStreetNameStatusId>
    {
        public CrabStreetNameStatusId([JsonProperty("value")] int streetNameStatusId) : base(streetNameStatusId) { }
    }
}
