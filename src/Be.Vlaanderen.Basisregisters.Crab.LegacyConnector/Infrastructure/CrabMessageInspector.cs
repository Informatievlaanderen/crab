namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Infrastructure
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    internal class CrabMessageInspector : IClientMessageInspector
    {


        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //request.Headers.To = new Uri(request.Headers.To..ToString().Replace("https://", "http://"));
            return null;
        }
    }
}
