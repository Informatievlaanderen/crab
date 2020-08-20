namespace Be.Vlaanderen.Basisregisters.Crab.GeoJson
{
    using System;
    using GeoJSON.Net;

    public abstract class CrabGeoJsonObjectMapper<T> : ICrabGeoJsonObjectMapper
        where T : GeoJSONObject
    {
        public Type MapType => typeof(T);
        public abstract string ToWkt(T geoJson);
    }
}
