using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Tui.Domain;
using Microsoft.EntityFrameworkCore;
using Tui.Business;

namespace Tui.WebApi
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
            services.AddMvc();
            services.AddAutoMapper();
            services.AddDbContext<TuiContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TuiContext")));
            // services
            services.AddScoped<Services.Flight.IFlightService, Services.Flight.FlightService>();
            services.AddScoped<Services.Airport.IAirportService, Services.Airport.AirportService>();
            services.AddScoped<Services.Aircraft.IAircraftService, Services.Aircraft.AircraftService>();

            // business
            services.AddScoped<IFlightBusiness, FlightBusiness>();
            
            // repo
            services.AddScoped<Infrastructure.Aircraft.IAircraftRepository, Infrastructure.Aircraft.AircraftRepository>();
            services.AddScoped<Infrastructure.Airport.IAirportRepository, Infrastructure.Airport.AirportRepository > ();
            services.AddScoped<Infrastructure.Flight.IFlightRepository, Infrastructure.Flight.FlightRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
