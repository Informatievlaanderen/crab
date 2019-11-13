namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Infrastructure
{
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    internal class CrabBehaviour : IEndpointBehavior
    {
        private readonly IClientMessageInspector _inspector;

        public CrabBehaviour()
            => _inspector = new CrabMessageInspector();

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            => clientRuntime.ClientMessageInspectors.Add(_inspector);

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        { }

        public void Validate(ServiceEndpoint endpoint)
        { }
    }
}
