using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace jf_web {
    /// <summary>
    /// Captures synchronous and asynchronous exceptions from the pipeline and generates HTML error responses.
    /// </summary>
    public sealed class JsonExceptionMiddleware {
        private const string DefaultErrorMessage = "A server error occurred.";
        private readonly IWebHostEnvironment _env;
        private readonly JsonSerializer _serializer;

        public JsonExceptionMiddleware(IWebHostEnvironment env) {
            _env = env;
            _serializer = new JsonSerializer {ContractResolver = new CamelCasePropertyNamesContractResolver()};
        }

        public async Task Invoke(HttpContext context) {
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null) return;
            var error = BuildError(ex, _env);
            using (var writer = new StreamWriter(context.Response.Body)) {
                _serializer.Serialize(writer, error);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }

        private static ApiError BuildError(Exception ex, IHostEnvironment env) {
            var error = new ApiError();
            if (env.IsDevelopment()) {
                error.Message = ex.Message;
                error.Detail = ex.StackTrace;
            } else {
                error.Message = DefaultErrorMessage;
                error.Detail = ex.Message;
            }

            return error;
        }
    }

    internal static class Test {
        internal static void UseJsonExceptionPage(this IApplicationBuilder app) {
            var jsonExceptionMiddleware = new JsonExceptionMiddleware(
                app.ApplicationServices.GetRequiredService<IWebHostEnvironment>());
            app.UseExceptionHandler(new ExceptionHandlerOptions {ExceptionHandler = jsonExceptionMiddleware.Invoke});
        }
    }
}