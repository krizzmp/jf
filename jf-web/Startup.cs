using System;
using System.Threading.Tasks;
using jf_web.Application;
using jf_web.DataAccess;
using jf_web.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jf_web {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<CreateMembershipController>();
            services.AddScoped<CreateMembershipInteractor>();
            services.AddScoped<ICreateMembershipPresenter, CreateMembershipPresenter>();
            services.AddScoped<CreateMembershipView>();
            services.AddScoped<IMembershipRepo, MembershipRepo>();
            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlite("Data Source=data.db"));
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseMiddleware<DeveloperExceptionPageMiddleware>();
//                app.UseStatusCodePages();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => {
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

/// <summary>
/// Captures synchronous and asynchronous exceptions from the pipeline and generates HTML error responses.
/// </summary>
public class DeveloperExceptionPageMiddleware {
    private readonly RequestDelegate _next;

    public DeveloperExceptionPageMiddleware(RequestDelegate next) {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    /// <summary>
    /// Process an individual request.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        } catch (Exception ex) {
            if (context.Response.HasStarted) {
                throw;
            }

            try {
                context.Response.Clear();
                context.Response.StatusCode = 500;

                await DisplayRuntimeException(context, ex);

                return;
            } catch (Exception) {
                // If there's a Exception while generating the error page, re-throw the original exception.
            }

            throw;
        }
    }

    private async Task DisplayRuntimeException(HttpContext context, Exception ex) {
        await context.Response.WriteAsync(ex.ToString());
    }
}