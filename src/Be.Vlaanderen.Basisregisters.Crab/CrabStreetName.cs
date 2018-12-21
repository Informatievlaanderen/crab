namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System.Collections.Generic;
    using AggregateSource;

    public class CrabStreetName : ValueObject<CrabStreetName>
    {
        public string Name { get; }

        public CrabLanguage? Language { get; }

        public CrabStreetName(string name, CrabLanguage? language)
        {
            Name = name;
            Language = language;
        }

        protected override IEnumerable<object> Reflect()
        {
            yield return Name;
            yield return Language;
        }

        public override string ToString()
            => $"{Name}{(Language.HasValue ? " (" + Language.Value + ")" : string.Empty)}";
    }
}
