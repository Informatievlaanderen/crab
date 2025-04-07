namespace Be.Vlaanderen.Basisregisters.Crab.Playground
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    using NodaTime;
    using NodaTime.Serialization.JsonNet;
    using NodaTime.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var instant = Instant.FromUtc(2018, 3, 15, 0, 5, 0);

            Console.WriteLine("Instant");
            Console.WriteLine("-------");
            Console.WriteLine(instant.ToString());
            Console.WriteLine(instant.ToString("g", CultureInfo.InvariantCulture));
            Console.WriteLine(instant.ToString("uuuu-MM-ddTHH:mm:ss.FFFFFFFFF'Z'", CultureInfo.InvariantCulture));
            Console.WriteLine(instant.ToString(InstantPattern.ExtendedIso.PatternText, CultureInfo.InvariantCulture));
            Console.WriteLine();

            var instant2 = instant.PlusNanoseconds(21);

            Console.WriteLine("Instant2");
            Console.WriteLine("--------");
            Console.WriteLine(instant2.ToString());
            Console.WriteLine(instant2.ToString("g", CultureInfo.InvariantCulture));
            Console.WriteLine(instant2.ToString("uuuu-MM-ddTHH:mm:ss.FFFFFFFFF'Z'", CultureInfo.InvariantCulture));
            Console.WriteLine(instant2.ToString(InstantPattern.ExtendedIso.PatternText, CultureInfo.InvariantCulture));
            Console.WriteLine();

            var instant3 = instant.PlusNanoseconds(2000);

            Console.WriteLine("Instant3");
            Console.WriteLine("--------");
            Console.WriteLine(instant3.ToString());
            Console.WriteLine(instant3.ToString("g", CultureInfo.InvariantCulture));
            Console.WriteLine(instant3.ToString("uuuu-MM-ddTHH:mm:ss.FFFFFFFFF'Z'", CultureInfo.InvariantCulture));
            Console.WriteLine(instant3.ToString(InstantPattern.ExtendedIso.PatternText, CultureInfo.InvariantCulture));
            Console.WriteLine();

            var apiSettings = EventsJsonSerializerSettingsProvider.CreateSerializerSettings().ConfigureDefaultForApi();
            var eventSettings = EventsJsonSerializerSettingsProvider.CreateSerializerSettings().ConfigureDefaultForEvents();
            void Print(object o, JsonSerializerSettings s) => Console.WriteLine(JsonConvert.SerializeObject(o, s));

            Console.WriteLine("Crab Timestamp (Instant)");
            Console.WriteLine("------------------------");
            var crabTimestamp = new CrabTimestamp(instant2);
            Print(crabTimestamp, apiSettings);
            Print(crabTimestamp, eventSettings);
            Console.WriteLine(crabTimestamp);
            Console.WriteLine();

            //foreach (var tz in DateTimeZoneProviders.Tzdb.GetAllZones())
            //    Console.WriteLine(tz.Id);

            var brussels = DateTimeZoneProviders.Tzdb.GetZoneOrNull("Europe/Brussels")!;
            var localDateTime = instant2.InZone(brussels).LocalDateTime;

            Console.WriteLine("Crab Lifetime (LocalDateTime)");
            Console.WriteLine("-----------------------------");
            var crabLifetime = new CrabLifetime(localDateTime, localDateTime.PlusDays(2));

            Print(crabLifetime, apiSettings);
            Print(crabLifetime, eventSettings);
            Console.WriteLine(crabLifetime);
            Console.WriteLine(new CrabLifetime(localDateTime, null));
            Console.WriteLine(new CrabLifetime(null, localDateTime));
            Console.WriteLine(new CrabLifetime(null, null));
        }
    }

    public static class EventsJsonSerializerSettingsProvider
    {
        private const int DefaultMaxDepth = 32;

        // return shared resolver by default for perf so slow reflection logic is cached once
        // developers can set their own resolver after the settings are returned if desired
        private static readonly DefaultContractResolver SharedContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy(),
        };

        private static readonly DefaultContractResolver SharedEventsContractResolver =
            new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = true,
                    ProcessDictionaryKeys = true,
                    ProcessExtensionDataNames = true
                }
            };

        /// <summary>
        /// Creates default <see cref="JsonSerializerSettings"/>.
        /// </summary>
        /// <returns>Default <see cref="JsonSerializerSettings"/>.</returns>
        public static JsonSerializerSettings CreateSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = SharedContractResolver,

                MissingMemberHandling = MissingMemberHandling.Ignore,

                // Limit the object graph we'll consume to a fixed depth. This prevents stackoverflow exceptions
                // from deserialization errors that might occur from deeply nested objects.
                MaxDepth = DefaultMaxDepth,

                // Do not change this setting
                // Setting this to None prevents Json.NET from loading malicious, unsafe, or security-sensitive types
                TypeNameHandling = TypeNameHandling.None,
            };
        }

        public static JsonSerializerSettings ConfigureDefaultForApi(this JsonSerializerSettings source)
        {
            if (source.ContractResolver is DefaultContractResolver resolver)
                resolver.NamingStrategy!.ProcessDictionaryKeys = true;

            source.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            source.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;

            source.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });
            //source.Converters.Add(new TrimStringConverter());
            //source.Converters.Add(new GuidConverter());

            return source.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
        }

        public static JsonSerializerSettings ConfigureDefaultForEvents(this JsonSerializerSettings source)
        {
            source.ContractResolver = SharedEventsContractResolver;

            source.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            source.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            source.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });
            //source.Converters.Add(new TrimStringConverter());
            //source.Converters.Add(new GuidConverter());

            return source
                .ConfigureForNodaTime(DateTimeZoneProviders.Tzdb)
                .WithIsoIntervalConverter();
        }
    }
}
