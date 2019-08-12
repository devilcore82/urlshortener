using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    //[Route("api/[controller]")]
    [Route("/")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlShortenerService service;

        public UrlShortenerController(IUrlShortenerService service)
        {
            this.service = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[HttpPost]
        //public IActionResult Post([FromBody] string uriToShorten)
        //{
        //    return Ok(service.Create(new Uri(uriToShorten)));
        //}

        [HttpPost]
        public IActionResult Post()
        {
            var uriToShorten = string.Empty;

            using (var reader = new StreamReader(Request.Body))
            {
                uriToShorten = reader.ReadToEnd();
            }

            return Ok(service.Create(new Uri(uriToShorten)));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
