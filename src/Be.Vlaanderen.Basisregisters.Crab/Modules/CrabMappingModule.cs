namespace Be.Vlaanderen.Basisregisters.Crab.Modules
{
    using Autofac;
    using GeoJson;

    public class CrabMappingModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterAssemblyTypes(typeof(CrabGeoJsonObjectMapper<>).Assembly)
                .AsClosedTypesOf(typeof(CrabGeoJsonObjectMapper<>))
                .As<ICrabGeoJsonObjectMapper>();

            containerBuilder
                .RegisterType<CrabGeoJsonMapper>()
                .As<ICrabGeoJsonMapper>();
        }
    }
}
