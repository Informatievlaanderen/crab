namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Responses;

    public class CrabConnector
    {
        private readonly CrabWriter _writer;

        public CrabConnector(CrabReader crabReader, CrabWriter crabWriter)
        {
            Get = crabReader ?? throw new ArgumentNullException(nameof(crabReader));
            _writer = crabWriter ?? throw new ArgumentNullException(nameof(crabWriter));
        }

        public async Task<CrabEditResponse> Send(ICrabModificationCompatibleCommand command, CancellationToken cancellationToken)
            => await _writer.Send(command, cancellationToken);

        public CrabReader Get { get; }
    }
}
