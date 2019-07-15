using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Abstractions.Services;
using DiscordRPGBot.BusinessLogic.Concretes.Repositories;
using DiscordRPGBot.BusinessLogic.Concretes.Services;
using DiscordRPGBot.BusinessLogic.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DiscordRPGBot.MicroservicesV2
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
            var mySqlConnectionString = Configuration.GetConnectionString("DiscordRPGBotConnectionString");
            services.AddDbContext<DiscordRPGBotContext>(options =>
                options.UseMySQL(mySqlConnectionString)
            );

            //Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Discord RPG Bot API", Version = "v1" });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // DI - Repositories
            services.AddTransient<IPlayerCharacterRepository, PlayerCharacterRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IRaceRepository, RaceRepository>();
            services.AddTransient<ILocationActionRepository, LocationActionRepository>();
            services.AddTransient<IItemActionRepository, ItemActionRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();

            // DI - Services
            services.AddTransient<IPlayerCharacterService, PlayerCharacterService>();
            services.AddTransient<IActionService, ActionService>();
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

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Discord RPG Bot API V1");
            });
        }
    }
}
