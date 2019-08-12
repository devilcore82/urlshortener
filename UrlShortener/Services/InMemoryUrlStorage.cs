using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public class InMemoryUrlStorage : IUrlStorage
    {
        private static ConcurrentDictionary<string, string> storage = new ConcurrentDictionary<string, string>();

        public void Add(string key, string uri)
        {
            storage.TryAdd(key, uri);
        }

        public string Get(string key)
        {
            storage.TryGetValue(key, out string uri);
            return uri;
        }
    }
}
