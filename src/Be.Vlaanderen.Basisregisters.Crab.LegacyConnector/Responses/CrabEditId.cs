namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Responses
{
    public class CrabEditId : CrabEditResponse
    {
        public CrabEditId(int id) => Id = id;

        public int Id { get; }
    }
}