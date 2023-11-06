using huce.motcua.entities.Settings;
using huce.phuhuynh.domain.Implements;
using huce.phuhuynh.domain.Interfaces;
using huce.phuhuynh.entities.Context;
using huce.phuhuynh.identityserver;
using huce.phuhuynh.identityserver.GrantValidators;
using huce.phuhuynh.identityserver.Models;
using huce.phuhuynh.identityserver.Profiles;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace huce.identityserver
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CDSConfig>(Configuration.GetSection("CDS"));
            services.AddDbContext<HucePhuHuynhDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("HUCE_PHUHUYNH")));
            services.Configure<CDSConfig>(Configuration.GetSection("CDS"));
            #region cors
            string allowHosts = Configuration.GetSection("AllowedHosts").Value;
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder
                            .WithOrigins(allowHosts)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            ;
                    });
            });
            #endregion
            #region read appsettings sinh key
            List<ApiScope> apiScopesConfig = new();

            foreach (var item in Configuration.GetSection("IdentityServer:ApiScopes").Get<List<ApiScopeConfig>>())
            {
                apiScopesConfig.Add(new ApiScope(item.Name, item.DisplayName));
            }
            Config.ApiScopes = apiScopesConfig;

            List<Client> clientsConfig = new();
            foreach (var item in Configuration.GetSection("IdentityServer:Clients").Get<List<ClientConfig>>())
            {
                var client = new Client
                {
                    ClientId = item.ClientId,
                    AllowedGrantTypes = new[] { GrantType.ResourceOwnerPassword},
                    RequireClientSecret = true,
                    ClientSecrets = item.ClientSecrets.Select(s => new IdentityServer4.Models.Secret(s.Sha256())).ToList(),
                    AllowedScopes = item.AllowedScopes,
                    AccessTokenLifetime = item.AccessTokenLifetime,
                    AllowOfflineAccess = item.AllowOfflineAccess,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    SlidingRefreshTokenLifetime = 1296000, //15 days
                    UpdateAccessTokenClaimsOnRefresh = true
                };
                if (item.AllowedGrantTypes != null && item.AllowedGrantTypes.Count > 0) //nếu có AllowedGrantTypes thì lấy theo AllowGrantTypes
                {
                    client.AllowedGrantTypes = item.AllowedGrantTypes;
                }
                clientsConfig.Add(client);
            }
            #endregion

            #region identity server add
            Config.Clients = clientsConfig;
            var identityServerBuilder = services.AddIdentityServer()
                //.AddDeveloperSigningCredential()
                .AddSigningCredential(new SigningCredentials(new Microsoft.IdentityModel.Tokens.JsonWebKey(File.ReadAllText("tempkey.jwk")),
                    SecurityAlgorithms.RsaSha256))
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddProfileService<ProfileService>()
                ;
            #endregion

            services.AddControllers();

            #region services
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ICdsServices, CdsServices>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            #region phai de ngay sau UseRouting
            app.UseCors(MyAllowSpecificOrigins);
            #endregion
            app.UseIdentityServer();
            app.UseAuthorization();
        }
    }
}
