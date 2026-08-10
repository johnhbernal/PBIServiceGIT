using InventoryService.Data;
using InventoryService.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PBIServices.Ldap;
using System;
using System.Linq;
using System.Text;
using IAuthenticationService = PBIServices.Ldap.IAuthenticationService;

namespace InventoryService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Teaching lab: simulated directory only (no real LDAP network calls).
            services.AddSingleton<IAuthenticationService, SimulatedDirectoryService>();
            services.Configure<LdapConfig>(Configuration.GetSection("Ldap"));

            var provider = (Configuration["App:DataProvider"] ?? "InMemory").Trim();
            if (string.Equals(provider, "SqlServer", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "SqlServer provider is disabled in this teaching lab. Use App:DataProvider=InMemory (default). " +
                    "Do not point this project at corporate databases.");
            }

            // InMemory — never opens a real SQL connection.
            services.AddDbContext<InventoryContext>(options =>
                options.UseInMemoryDatabase(Configuration["App:InMemoryDatabaseName"] ?? "PBITeachingDb"));

            var jwtKey = Configuration["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(jwtKey) || Encoding.UTF8.GetByteCount(jwtKey) < 32)
            {
                throw new InvalidOperationException(
                    "Jwt:Key must be at least 32 characters (see appsettings.Development.json for the teaching default).");
            }

            var origins = (Configuration["Cors:AllowedOrigins"] ?? "http://localhost:3000")
                .Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(o => o.Trim())
                .ToArray();

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultCors", policy =>
                    policy.WithOrigins(origins)
                          .AllowAnyHeader()
                          .AllowAnyMethod());
            });

            services.AddControllers();
            services.AddHealthChecks();

            if (Environment.IsDevelopment())
            {
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "PBIServices Teaching Lab",
                        Version = "v1",
                        Description = "InMemory seed + simulated directory. Demo: admin@demo.local / Admin123!"
                    });
                    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Description = "JWT: Bearer {token} from POST /api/Token",
                        Name = "Authorization",
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT"
                    });
                    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                        {
                            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                            {
                                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                                {
                                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            System.Array.Empty<string>()
                        }
                    });
                });
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = !Environment.IsDevelopment();
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.FromMinutes(1),
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PBIServices Teaching Lab v1");
                    c.RoutePrefix = "swagger";
                });
            }

            TeachingDataSeeder.Seed(app.ApplicationServices);

            // Prefer HTTP in local teaching lab (avoid HTTPS cert friction).
            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = { "index.html" }
            });
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("DefaultCors");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health").AllowAnonymous();
                endpoints.MapGet("/", () => Results.Redirect("/app/")).AllowAnonymous();
                endpoints.MapControllers();
            });
        }
    }
}
