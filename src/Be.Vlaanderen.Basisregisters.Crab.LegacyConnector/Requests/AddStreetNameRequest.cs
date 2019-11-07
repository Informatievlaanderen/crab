namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Requests
{
    using System;
    using CrabWrite;

    public class AddStreetNameRequest : CrabModificationRequest
    {
        public DateTime StartDate { get; set; }
        public string Municipality { get; set; }
        public string Status { get; set; }
        public string StreetName { get; set; }
        public string StreetNameSecondLanguage { get; set; }
 
        internal AddStraatRequest ToServiceRequest()
        {
            return new AddStraatRequest
            {
                Begindatum = StartDate,
                Gemeente = Municipality,
                Status = Status,
                Straatnaam = StreetName,
                Straatnaam2 = StreetNameSecondLanguage,
            };
        }
    }
}
