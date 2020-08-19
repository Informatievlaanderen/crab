namespace Be.Vlaanderen.Basisregisters.Crab.GeoJson
{
    using System;
    using System.Collections.Generic;
    using GeoJSON.Net;
    using Microsoft.Extensions.Logging;

    internal class CrabGeoJsonMapper : ICrabGeoJsonMapper
    {
        private readonly IDictionary<Type, ICrabGeoJsonObjectMapper> _mappers = new Dictionary<Type, ICrabGeoJsonObjectMapper>();
        private readonly ILogger _logger;

        public CrabGeoJsonMapper(
            IEnumerable<ICrabGeoJsonObjectMapper> objectMappers,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<CrabGeoJsonMapper>() ?? throw new ArgumentNullException(nameof(loggerFactory));

            foreach (var geoJsonObjectMapper in objectMappers)
                Register(geoJsonObjectMapper);
        }

        private void Register(ICrabGeoJsonObjectMapper crabGeoJsonObjectMapper)
        {
            if (crabGeoJsonObjectMapper == null)
                return;

            var geoJsonType = crabGeoJsonObjectMapper.MapType;
            if (_mappers.ContainsKey(geoJsonType))
                _logger.LogWarning($"Attempting to register {crabGeoJsonObjectMapper.GetType().FullName}, but there is already a mapper for {geoJsonType.FullName} registered.");
            else
                _mappers.Add(geoJsonType, crabGeoJsonObjectMapper);
        }

        public string ToWkt<T>(T geoJson)
            where T : GeoJSONObject
        {
            if (geoJson == null)
                throw new ArgumentNullException(nameof(geoJson));

            var geoJsonType = typeof(T);
            if (!_mappers.ContainsKey(geoJsonType))
                throw new NotImplementedException($"No WKT conversion for type {typeof(T).FullName}");

            if (!(_mappers[geoJsonType] is CrabGeoJsonObjectMapper<T> mapper))
                throw new Exception($"Error casting mapper {_mappers[geoJsonType].GetType().FullName} as {typeof(CrabGeoJsonObjectMapper<T>).FullName}");

            return mapper.ToWkt(geoJson);
        }
    }
}
