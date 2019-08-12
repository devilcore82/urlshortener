using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly Uri baseUri;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUrlStorage storage;
        private RNGCryptoServiceProvider x;

        public UrlShortenerService(Uri baseUri, IUrlStorage storage)
        {
            this.baseUri = baseUri;
            this.storage = storage;
        }

        public UrlShortenerService(IHttpContextAccessor httpContextAccessor, IUrlStorage storage)
        {
            this.httpContextAccessor = httpContextAccessor;
            var request = httpContextAccessor.HttpContext.Request;

            this.baseUri = new Uri($"{request.Scheme}://{request.Host.ToString()}");
            this.storage = storage;
        }

        public Uri Create(Uri uriToShorten)
        {
            //create random key
            var key = "XXXXXXXX";

            storage.Add(key, uriToShorten.ToString());
            return new Uri(baseUri, key);
        }

        public Uri Delete(Uri shortenedUri)
        {
            throw new NotImplementedException();
        }

        public Uri Retrieve(Uri uriToExpand)
        {
            throw new NotImplementedException();
        }

        public bool Update(Uri shortenedUri, Uri updatedUri)
        {
            throw new NotImplementedException();
        }
    }
}
