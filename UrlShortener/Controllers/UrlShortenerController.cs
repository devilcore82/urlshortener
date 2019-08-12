using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{ 
    [Route("/")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlKeyGenerator generator;
        private readonly IUrlStorage storage;

        private Uri BaseUri => new Uri($"{Request.Scheme}://{Request.Host.ToString()}");

        public UrlShortenerController(IUrlKeyGenerator generator, IUrlStorage storage)
        {
            this.generator = generator;
            this.storage = storage;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var urlOriginal = storage.Get(id);
            return Redirect(urlOriginal);
        }

        [HttpPost]
        public IActionResult Post()
        {
            var uriToShorten = string.Empty;

            using (var reader = new StreamReader(Request.Body))
            {
                uriToShorten = reader.ReadToEnd();
            }

            var urlKey = generator.Generate();
            storage.Add(urlKey, uriToShorten);

            return Ok(new Uri(BaseUri, urlKey));
        }       
    }
}
