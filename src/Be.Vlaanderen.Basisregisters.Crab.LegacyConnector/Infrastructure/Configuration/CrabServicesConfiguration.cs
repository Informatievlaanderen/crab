namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Infrastructure.Configuration
{
    public class CrabServicesConfiguration
    {
        /// <summary></summary>
        public string Base64Certificate { get; set; }

        /// <summary></summary>
        public string LocalCertificatePath { get; set; }

        /// <summary>CrabRead endpoint url</summary>
        public string ReadEndpoint { get; set; }

        /// <summary>CrabEdit endpoint url</summary>
        public string EditEndpoint { get; set; }
    }
}
