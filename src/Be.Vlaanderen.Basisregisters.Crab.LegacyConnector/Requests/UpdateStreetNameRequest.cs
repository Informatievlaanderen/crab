namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Requests
{
    using System;
    using CrabWrite;

    public class UpdateStreetNameRequest : CrabModificationRequest
    {
        public int Id { get; set; }
        public StreetNameUpdate UpdateType { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string StreetName { get; set; }
        public string StreetNameSecondLanguage { get; set; }

        internal UpdateStraatRequest ToServiceRequest()
        {
            if(UpdateType == StreetNameUpdate.Unknown)
                throw new ArgumentNullException(nameof(UpdateType));

            return new UpdateStraatRequest
            {
                Id = Id,
                IsCorrectie = UpdateType == StreetNameUpdate.Correction,
                Begindatum = StartDate,
                Status = Status,
                Straatnaam = StreetName,
                Straatnaam2 = StreetNameSecondLanguage,
                NegeerRrInformatie = true,
            };
        }
    }

    public enum StreetNameUpdate
    {
        Unknown,
        Correction,
        Change
    }
}
