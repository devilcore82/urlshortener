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

            if(string.IsNullOrEmpty(urlOriginal))
            {
                return NotFound();
            }

            return Redirect(urlOriginal);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var uriToShorten = string.Empty;

            using (var reader = new StreamReader(Request.Body))
            {
                uriToShorten = await reader.ReadToEndAsync();

                if(!Uri.IsWellFormedUriString(uriToShorten, UriKind.Absolute))
                {
                    return BadRequest($"Invalid Url provided");
                }
            }

            var urlKey = generator.Generate();
            if(!storage.Add(urlKey, uriToShorten))
            {
                return new ServiceUnavailableResult("Unable to shorten Url.  Please try again");
            }

            return Ok(new Uri(BaseUri, urlKey));
        }       
    }
}
