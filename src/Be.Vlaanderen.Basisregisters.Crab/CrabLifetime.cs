namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System.Collections.Generic;
    using AggregateSource;
    using Newtonsoft.Json;
    using NodaTime;

    public class CrabLifetime : ValueObject<CrabLifetime>
    {
        public LocalDateTime? BeginDateTime { get; }
        public LocalDateTime? EndDateTime { get; }

        [JsonConstructor]
        public CrabLifetime(LocalDateTime? beginDateTime, LocalDateTime? endDateTime)
        {
            BeginDateTime = beginDateTime;
            EndDateTime = endDateTime;
        }

        protected override IEnumerable<object> Reflect()
        {
            yield return BeginDateTime;
            yield return EndDateTime;
        }

        public override string ToString() => NodaHelpers.PrintRange(BeginDateTime, EndDateTime);
    }
}
