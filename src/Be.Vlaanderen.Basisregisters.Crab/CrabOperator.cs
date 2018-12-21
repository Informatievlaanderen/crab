namespace Be.Vlaanderen.Basisregisters.Crab
{
    using AggregateSource;
    using Newtonsoft.Json;

    public class CrabOperator : StringValueObject<CrabOperator>
    {
        public CrabOperator([JsonProperty("value")] string @operator) : base(@operator) { }
    }
}
