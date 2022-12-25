using Application.Commands;
using Application.Commands.Validator;
using Application.Handlers.QueryHandlers;
using Core.Interface.Command.Generic;
using Core.Interface.Query;
using Core.Interface.Query.Generic;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence.Entities;
using Infrastructure.Repository.Command;
using Infrastructure.Repository.Command.Generic;
using Infrastructure.Repository.Query;
using Infrastructure.Repository.Query.Generic;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>());

            services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
            //services.AddValidatorsFromAssemblyContaining<PersonValidator>();
            services.AddMediatR(typeof(GetAllCustomerHandler).GetTypeInfo().Assembly);
         //   services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
              services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<Core.Interface.Command.ICustomerCommandRepository, CustomerCommandRepository>();



            #region DB

          

            services.AddDbContext<CRUDTESTContext>(options =>
            {
                object p = options.UseSqlServer(Configuration.GetConnectionString("CRUDTEST"), x => x.UseNetTopologySuite());
                ////  options.UseSqlServer(nooshDarooConnectionString);
                options.EnableSensitiveDataLogging();

            });


            


            #endregion




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
