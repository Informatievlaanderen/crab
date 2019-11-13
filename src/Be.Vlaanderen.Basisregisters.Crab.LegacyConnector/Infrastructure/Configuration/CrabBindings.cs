namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Infrastructure.Configuration
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Xml;

    internal class CrabBindings
    {
        public static Binding Read => new CrabBinding();
        public static Binding Write => new CrabBinding();
    }

    internal class CrabBinding : WSHttpBinding
    {
        public CrabBinding() : base(SecurityMode.TransportWithMessageCredential, false)
        {
            ReaderQuotas = XmlDictionaryReaderQuotas.Max;
            MaxReceivedMessageSize = int.MaxValue;
            AllowCookies = true;
            Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
        }
    }
}
