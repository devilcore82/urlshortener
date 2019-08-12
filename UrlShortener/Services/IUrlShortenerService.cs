using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public interface IUrlShortenerService
    {
        Uri Create(Uri uriToShorten);
        Uri Retrieve(Uri uriToExpand);
        bool Update(Uri shortenedUri, Uri updatedUri);
        Uri Delete(Uri shortenedUri);
    }
}
