namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Infrastructure.Configuration
{
    using System.ServiceModel;

    internal class CrabBindings
    {
        public static BasicHttpBinding DefaultHttp =>
            new BasicHttpBinding
            {
                MaxBufferSize = int.MaxValue,
                ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max,
                MaxReceivedMessageSize = int.MaxValue,
                AllowCookies = true
            };
    }
}
