using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener
{
    public class ServiceUnavailableResult : ActionResult
    {
        public object value { get; private set; }
        public ServiceUnavailableResult(object value)
        {
            this.value = value;
        }

        public async override Task ExecuteResultAsync(ActionContext ctx)
        {
            var result = new ObjectResult(this.value) { StatusCode = 503 };
            await result.ExecuteResultAsync(ctx);
        }
    }
}
