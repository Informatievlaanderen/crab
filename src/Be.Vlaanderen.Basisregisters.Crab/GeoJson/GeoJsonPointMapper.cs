namespace Be.Vlaanderen.Basisregisters.Crab.GeoJson
{
    using System;
    using GeoJSON.Net.Geometry;

    internal class CrabGeoJsonPointMapper : CrabGeoJsonObjectMapper<Point>
    {
        public override string ToWkt(Point point)
        {
            if (point == null)
                throw new ArgumentNullException(nameof(point));

            return $"POINT ({point.Coordinates.Longitude} {point.Coordinates.Latitude})";
        }
    }
}
