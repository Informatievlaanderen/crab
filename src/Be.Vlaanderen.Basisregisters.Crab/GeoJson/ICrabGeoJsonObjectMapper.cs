namespace Be.Vlaanderen.Basisregisters.Crab.GeoJson
{
    using System;

    public interface ICrabGeoJsonObjectMapper
    {
        Type MapType { get; }
    }
}
