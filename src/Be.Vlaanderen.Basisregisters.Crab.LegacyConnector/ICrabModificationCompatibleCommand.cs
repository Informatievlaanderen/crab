namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector
{
    using Requests;

    /// <summary>Interface to extend commands, create request that can be send to CrabEditService</summary>
    public interface ICrabModificationCompatibleCommand
    {
        CrabModificationRequest CreateCrabModificationRequest();
    }
}