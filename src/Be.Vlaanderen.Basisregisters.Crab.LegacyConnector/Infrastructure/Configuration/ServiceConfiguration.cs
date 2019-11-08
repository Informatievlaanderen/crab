namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Infrastructure.Configuration
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;

    public class ServiceConfiguration
    {
        public EndpointAddress Endpoint { get; }
        public X509Certificate2 Certificate { get; }

        public ServiceConfiguration(string endpoint, CrabCertificate certificate)
        {
            if(string.IsNullOrWhiteSpace(endpoint))
                throw new ArgumentNullException(nameof(endpoint));

            Endpoint = new EndpointAddress(new Uri(endpoint));
            Certificate = certificate ?? throw new ArgumentNullException(nameof(certificate));
        }
    }
}
