namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CrabWrite;
    using Infrastructure.Configuration;
    using Requests;
    using Responses;

    public class CrabWriter
    {
        private readonly ServiceConfiguration _configuration;

        internal CrabWriter(ServiceConfiguration configuration)
            => _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));


        public async Task<CrabEditResponse> Send(ICrabModificationCompatibleCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            switch (command.CreateCrabModificationRequest())
            {
                case null:
                    throw new NullReferenceException($"Failed to create crab request for type {command.GetType()}");

                case AddStreetNameRequest addStreet:
                    return await Execute(client => client.AddStraatAsync(addStreet.ToServiceRequest()), cancellationToken);
                case UpdateStreetNameRequest updateStreet:
                    return await Execute(client => client.UpdateStraatAsync(updateStreet.ToServiceRequest()), cancellationToken);
                case DeleteStreetNameRequest id:
                    return await Execute(client => client.DeleteStraatAsync(id), cancellationToken);
                default:
                    return new UndefinedEdit();
            }
        }


        private async Task<CrabEditResponse> Execute(Func<CrabEditClient, Task<int>> sendCrabEdit, CancellationToken cancellationToken)
        {
            return await SendRequest(
                async client =>
                {
                    var id = await sendCrabEdit(client);
                    return new CrabEditId(id);
                },
                cancellationToken);
        }

        private async Task<CrabEditResponse> Execute(Func<CrabEditClient, Task> sendCrabEdit, CancellationToken cancellationToken)
        {
            return await SendRequest(
                async client =>
                {
                    await sendCrabEdit(client);
                    return new CompletedCrabEdit();
                },
                cancellationToken);
        }

        private async Task<CrabEditResponse> SendRequest(Func<CrabEditClient, Task<CrabEditResponse>> sendCrabEdit, CancellationToken cancellationToken)
        {
            if (null == sendCrabEdit)
                throw new ArgumentNullException(nameof(sendCrabEdit));

            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException();

            var client = new CrabEditClient(CrabBindings.DefaultHttp, _configuration.Endpoint);
            client.ClientCredentials.ClientCertificate.Certificate = _configuration.Certificate;
            try
            {
                var response = await sendCrabEdit(client);
                await client.CloseAsync();

                return response ?? throw new CrabEditResponseNullReferenceException();
            }
            catch (CrabEditResponseNullReferenceException)
            {
                throw;
            }
            catch
            {
                client.Abort();
                throw;
            }
        }

        private class CrabEditResponseNullReferenceException : NullReferenceException { }
    }
}
