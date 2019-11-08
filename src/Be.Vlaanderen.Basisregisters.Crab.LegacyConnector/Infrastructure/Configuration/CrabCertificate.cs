namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Infrastructure.Configuration
{
    using System;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;

    public class CrabCertificate
    {
        private readonly X509Certificate2 _certificate;

        public CrabCertificate(CrabServicesConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (!string.IsNullOrWhiteSpace(configuration.Base64Certificate))
                _certificate = new X509Certificate2(Convert.FromBase64String(configuration.Base64Certificate));
            else if (File.Exists(configuration.LocalCertificatePath))
                _certificate = new X509Certificate2(configuration.LocalCertificatePath);

            if(_certificate == null)
                throw new Exception($"Crab-service certificate could not be configured. {nameof(configuration.Base64Certificate)} was not set and certificate file '{configuration.LocalCertificatePath}' does not exist.");
        }

        public static implicit operator X509Certificate2(CrabCertificate certificate) => certificate?._certificate;
    }
}
