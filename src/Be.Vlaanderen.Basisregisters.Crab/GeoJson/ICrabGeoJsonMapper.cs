namespace Be.Vlaanderen.Basisregisters.Crab.GeoJson
{
    using GeoJSON.Net;

    public interface ICrabGeoJsonMapper
    {
        string ToWkt<T>(T geoJson) where T : GeoJSONObject;
    }
}
