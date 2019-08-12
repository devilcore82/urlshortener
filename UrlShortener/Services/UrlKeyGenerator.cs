using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public class UrlKeyGenerator : IUrlKeyGenerator
    {
        public const int KeyLength = 7;

        public string Generate()
        {
            return Guid.NewGuid().ToString("N").Substring(0, KeyLength);
        }
    }
}
