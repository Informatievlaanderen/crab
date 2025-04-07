namespace Be.Vlaanderen.Basisregisters.Crab
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Chronicle<T, TKey> : IEnumerable<T>
        where T : ICrabEvent, IHasCrabKey<TKey>
    {
        private readonly List<T> _events;

        public Chronicle() => _events = new List<T>();

        public void Add(T @event) => _events.Add(@event);

        public T? MostCurrent(T? incomingEvent)
        {
            var events = incomingEvent == null ? _events : _events.Concat(new[] { incomingEvent });

            var nonDeleteds = events.GroupBy(e => e.Key)
                .Select(LastInGroup)
                .Where(e => e != null);

            return nonDeleteds
                .OrderBy(e => e!.BeginDateTime)
                .ThenBy(e => e!.Timestamp)
                .LastOrDefault();
        }

        private static T? LastInGroup(IGrouping<TKey, T> group)
        {
            if (group.Any(e => e.Modification == CrabModification.Delete))
                return default;

            return group
                .OrderBy(e => e.Timestamp)
                .ThenBy(e => e.BeginDateTime)
                .LastOrDefault();
        }

        public IEnumerator<T> GetEnumerator() => _events.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
