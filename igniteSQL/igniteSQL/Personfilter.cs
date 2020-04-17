using Apache.Ignite.Core.Cache;

namespace igniteSQL
{
    internal class Personfilter : ICacheEntryFilter<int, Person>
    {
        public bool Invoke(ICacheEntry<int, Person> entry)
        {
            return entry.Value.Age > 30;
        }
    }
}