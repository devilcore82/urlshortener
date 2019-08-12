using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public interface IUrlStorage
    {
        bool Add(string key, string uri);
        string Get(string key);
    }
}
