using jf_web.Application;
using jf_web.DataAccess;
using jf_web.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace jf_web {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().AddNewtonsoftJson().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseJsonExceptionPage();
            if (env.IsDevelopment()) {
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