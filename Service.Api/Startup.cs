using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO;
using DAO.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Service.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ()
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2)
                .AddJsonOptions (options => {
                    options.SerializerSettings.Converters.Add (new StringEnumConverter ());
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddSwaggerGen (c => { c.SwaggerDoc ("v1", new Info { Title = "Sample DockerFile API", Version = "v1" }); });

            var dbConnectionString = Configuration.GetConnectionString ("SqlConnection");

            services.AddDbContext<Context> (options =>
                options.UseSqlServer (dbConnectionString,
                    optionsBuilder =>
                    optionsBuilder.MigrationsAssembly (typeof (Context).Namespace)
                )
            );

            services.AddScoped<IRepository, TodoRepository> ();
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseMvc ();
            app.UseSwagger ();
            app.UseSwaggerUI (s => {
                s.SwaggerEndpoint ("v1/swagger.json", "Sgr API v1.0");
                s.EnableFilter ();
                s.DocExpansion (DocExpansion.None);
            });
        }
    }
}