namespace Be.Vlaanderen.Basisregisters.Crab.GeoJson
{
    using System;

    internal interface ICrabGeoJsonObjectMapper
    {
        Type MapType { get; }
    }
}
