namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Responses
{
    public class UndefinedEdit : CrabEditResponse
    {
        public string Message => "No CRAB edit request was send";
    }
}
