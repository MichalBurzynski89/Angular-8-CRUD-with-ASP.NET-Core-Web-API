using AspNetCoreWebAPI.DataAccess.QBatis;
using AspNetCoreWebAPI.Models.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using QBatis.DataMapper;
using QBatis.DataMapper.DependencyInjection;

namespace AspNetCoreWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddSqlMapper(options => Configuration.GetSection("Database:Primary").Bind(options));
            services.AddSqlMapper(options => Configuration.Bind("Database:Primary", options));

            services.AddSingleton<IDistributedCache, SqlServerCache>();

            services.AddOptions<SqlServerCacheOptions>()
                .Configure<ISqlMapper>((options, mapper) => 
                {
                    options.ConnectionString = mapper.DataSource.ConnectionString;
                });

            services.AddSingleton<IGenericDataSource, SqlMapperDataSource>();

            services.AddTransient<ICustomerDao, CustomerDao>();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NET Core Web API", Version = "v1" });
            });

            // Enable CORS
            services.AddCors(options => 
            {
                options.AddPolicy("EnableCORS", builder => 
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core Web API V1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseCors("EnableCORS");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
