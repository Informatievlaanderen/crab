namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;

    public class NumberOfFlags : IntegerValueObject<NumberOfFlags>
    {
        public NumberOfFlags([JsonProperty("value")] int numberOfFlags) : base(numberOfFlags) { }
    }
}
