namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System;
    using System.Globalization;
    using NodaTime;
    using NodaTime.Text;

    public static class NodaHelpers
    {
        public static DateTimeZone DefaultCrabDateTimeZone = DateTimeZoneProviders.Tzdb.GetZoneOrNull("Europe/Brussels");

        public static string Print(this Instant? value) => value.HasValue ? value.Value.ToString(InstantPattern.ExtendedIso.PatternText, CultureInfo.InvariantCulture) : "ø";

        public static string PrintRange(Instant? from, Instant? to) => $"{from.Print()} -> {to.Print()}";

        public static string Print(this LocalDateTime? value) => value.HasValue ? value.Value.ToString(LocalDateTimePattern.FullRoundtripWithoutCalendar.PatternText, CultureInfo.InvariantCulture) : "ø";

        public static string PrintRange(LocalDateTime? from, LocalDateTime? to) => $"{from.Print()} -> {to.Print()}";

        public static LocalDateTime ToCrabLocalDateTime(this DateTime dateTime) => LocalDateTime.FromDateTime(dateTime);

        public static Instant ToCrabInstant(this DateTime dateTime) => LocalDateTime.FromDateTime(dateTime).ToCrabInstant();

        public static Instant ToCrabInstant(this LocalDateTime localDateTime) =>
            localDateTime.InZoneLeniently(DefaultCrabDateTimeZone).ToInstant();

        public static DateTime ToCrabDateTime(this LocalDateTime localDateTime) =>
            localDateTime.ToDateTimeUnspecified();

        public static DateTime? ToCrabDateTime(this LocalDateTime? localDateTime) =>
            localDateTime?.ToDateTimeUnspecified();

        public static DateTime ToCrabDateTime(this Instant instant) =>
            instant.InZone(DefaultCrabDateTimeZone).ToDateTimeUnspecified();
    }
}
