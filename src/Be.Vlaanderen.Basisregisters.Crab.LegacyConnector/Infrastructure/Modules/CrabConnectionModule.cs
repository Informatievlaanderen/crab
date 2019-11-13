namespace Be.Vlaanderen.Basisregisters.Crab.LegacyConnector.Infrastructure.Modules
{
    using System;
    using Autofac;
    using Configuration;
    using Microsoft.Extensions.Configuration;

    public class CrabConnectionModule : Module
    {
        private const string CrabServicesSectionName = "CrabServices";
        private readonly IConfiguration _configuration;

        public CrabConnectionModule(IConfiguration configuration)
            => _configuration = configuration;

        protected override void Load(ContainerBuilder containerBuilder)
        {
            var crabServicesConfiguration = _configuration
                .GetSection(CrabServicesSectionName)
                .Get<CrabServicesConfiguration>();

            if (crabServicesConfiguration == null)
                throw new Exception($"Missing configuration: {typeof(CrabServicesConfiguration).Name}. Verify that '{CrabServicesSectionName}' section is set.");

            var certificate = new CrabCertificate(crabServicesConfiguration);

            var readConfiguration = new ServiceConfiguration(crabServicesConfiguration.ReadEndpoint, certificate);
            containerBuilder
                .Register(c => new CrabReader(readConfiguration))
                .AsSelf()
                .SingleInstance();

            var writerConfiguration = new ServiceConfiguration(crabServicesConfiguration.EditEndpoint, certificate);
            containerBuilder
                .Register(c => new CrabWriter(writerConfiguration))
                .AsSelf()
                .SingleInstance();

            containerBuilder
                .RegisterType<CrabConnector>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
