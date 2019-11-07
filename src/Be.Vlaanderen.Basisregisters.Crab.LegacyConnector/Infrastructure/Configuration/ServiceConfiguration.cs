namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Infrastructure.Configuration
{
    using System;
    using System.ServiceModel;

    public class ServiceConfiguration
    {
        public string Endpoint { get; internal set; }

        internal EndpointAddress GetAddress()
        {
            if(string.IsNullOrWhiteSpace(Endpoint))
                throw new ArgumentNullException(nameof(Endpoint));

            return new EndpointAddress(new Uri(Endpoint));
        }
    }
}
