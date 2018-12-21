namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System.Collections.Generic;
    using AggregateSource;

    public class CrabTransStreetName : ValueObject<CrabTransStreetName>
    {
        public string TransStreetName { get; }

        public CrabLanguage? Language { get; }

        public CrabTransStreetName(string transStreetName, CrabLanguage? language)
        {
            TransStreetName = transStreetName;
            Language = language;
        }

        protected override IEnumerable<object> Reflect()
        {
            yield return TransStreetName;
            yield return Language;
        }

        public override string ToString()
            => $"{TransStreetName}{(Language.HasValue ? " (" + Language.Value + ")" : string.Empty)}";
    }
}
