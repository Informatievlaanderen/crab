namespace Be.Vlaanderen.Basisregisters.Crab
{
    using NodaTime;

    public interface ICrabEvent
    {
        CrabModification? Modification { get; }
        LocalDateTime? BeginDateTime { get; }
        LocalDateTime? EndDateTime { get; }
        Instant Timestamp { get; }
        string Operator { get; }
        CrabOrganisation? Organisation { get; }
    }
}
