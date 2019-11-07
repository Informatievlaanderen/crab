namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Configuration;
    using Responses;

    public class CrabConnector
    {
        private readonly CrabWriter _writer;

        public CrabConnector(CrabServicesConfiguration configuration)
        {
            if(configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _writer = new CrabWriter(configuration.CrabEdit);
            Get = new CrabReader(configuration.CrabRead);
        }

        public async Task<CrabEditResponse> Send(ICrabModificationCompatibleCommand command, CancellationToken cancellationToken)
            => await _writer.Send(command, cancellationToken);

        public CrabReader Get { get; }
    }
}
