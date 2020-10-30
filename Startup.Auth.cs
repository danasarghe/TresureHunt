using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using TreasureHunt.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TreasureHunt
{
    public partial class Startup
    {
        private void ConfigureExternalLogin(IServiceCollection services){
            ConfigureTwitchAccount(services);
            ConfigureGitHubAccount(services);
            ConfigureMicrosoftAccount(services);
            ConfigureFacebookAccount(services);
            ConfigureGoogleAccount(services);
        }
       
        private void ConfigureTwitchAccount(IServiceCollection services)
        {
            services.AddAuthentication().AddTwitch(options =>
            {
                options.ClientId = Configuration["Authentication:Twitch:ClientId"];
                options.ClientSecret = Configuration["Authentication:Twitch:ClientSecret"];
            });
        }

        private void ConfigureGitHubAccount(IServiceCollection services)
        {
            services.AddAuthentication().AddGitHub( options =>
                {
                options.ClientId = Configuration["Authentication:GitHub:ClientId"];
                options.ClientSecret = Configuration["Authentication:GitHub:ClientSecret"];
                }
            );
        }

        private void ConfigureMicrosoftAccount(IServiceCollection services)
        {
            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
            });
        }

        private void ConfigureFacebookAccount(IServiceCollection services)
        {
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
        }
        private void ConfigureGoogleAccount(IServiceCollection services)
        {

            services.AddAuthentication().AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                    Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            });

        }
       
    }
}
