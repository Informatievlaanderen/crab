namespace Be.Vlaanderen.Basisregisters.Crab
{
    public interface IHasCrabPosition
    {
        string AddressPosition { get; }
        CrabAddressPositionOrigin AddressPositionOrigin { get; }
    }
}
