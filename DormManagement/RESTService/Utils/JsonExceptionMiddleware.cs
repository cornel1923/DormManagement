using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DormManagement.Utils
{
    public class JsonExceptionMiddleware
    {
        public async Task Invoke(HttpContext context)
        {
            Exception exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception == null)
            {
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var error = new { exception.Message };
            
            context.Response.ContentType = "application/json";

            using (StreamWriter writer = new StreamWriter(context.Response.Body))
            {
                new JsonSerializer().Serialize(writer, error);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
