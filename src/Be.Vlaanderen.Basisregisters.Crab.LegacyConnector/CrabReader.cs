namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using CrabRead;
    using Infrastructure;
    using Infrastructure.Configuration;

    public class CrabReader
    {
        private readonly ServiceConfiguration _configuration;

        public CrabReader(ServiceConfiguration configuration)
            => _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        public async Task<IEnumerable<string>> StreetNamesByMunicipality(string municipalityName, CancellationToken cancellationToken)
            => await Read(client => client.ListStraatnaamByGemeenteAsync(municipalityName), cancellationToken);

        private async Task<T> Read<T>(Func<CrabReadClient, Task<T>> execute, CancellationToken cancellationToken)
        {
            if(cancellationToken.IsCancellationRequested)
                throw new TaskCanceledException();

            var client = new CrabReadClient(CrabBindings.Read, _configuration.Endpoint);
            client.Endpoint.EndpointBehaviors.Add(new CrabBehaviour());
            client.ClientCredentials.ClientCertificate.Certificate = _configuration.Certificate;

            try
            {
                var result = await execute(client);
                await client.CloseAsync();

                return result;
            }
            catch
            {
                client.Abort();
                throw;
            }
        }
    }
}
