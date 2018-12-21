namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;

    public class CrabMunicipalityNameId : IntegerValueObject<CrabMunicipalityNameId>
    {
        public CrabMunicipalityNameId([JsonProperty("value")] int municipalityNameId) : base(municipalityNameId) { }
    }
}
