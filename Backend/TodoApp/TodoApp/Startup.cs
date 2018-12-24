using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using TodoApp.Filters;
using TodoApp.Security;
using TodoAppLibrary.CryptoContext;
using TodoAppLibrary.TaskContext;
using TodoAppLibrary.UserContext;

namespace TodoApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            Environment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IUserRepository userRepository = default(IUserRepository);
            ITaskRepository taskRepository = default(ITaskRepository);

            if (Configuration.GetValue<bool>("UseDB"))
            {
                userRepository = new InDBUserRepository();
                taskRepository = new InDBTaskRepository();
            }
            else
            {
                userRepository = new InMemoryUserRepository();
                taskRepository = new InMemoryTaskRepository();
            }

            var cryptoTool = new CryptoToolWithSalt();

            var taskFacade = new TaskFacade(userRepository, taskRepository);
            var userFacade = new UserFacade(userRepository, cryptoTool);

            services.AddSwaggerGen(current =>
            {
                current.SwaggerDoc("v1", new Info
                {
                    Title = "TodoApp API",
                    Version = "v1"
                });
                current.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                current.DescribeAllEnumsAsStrings();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                current.IncludeXmlComments(xmlPath);
                current.DescribeAllEnumsAsStrings();
            });

            services.AddSingleton<IUserFacade>(userFacade);
            services.AddSingleton<ITaskFacade>(taskFacade);

            ConfigureAuth(services);

            services.AddMvc(mvc => mvc.Filters.Add(new ExceptionFilter()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(current => { current.SwaggerEndpoint("/swagger/v1/swagger.json", "QrServer"); });

        }

        private void ConfigureAuth(IServiceCollection services)
        {
            var securityConfiguration = Configuration.GetSection("Security");
            var securitySettings = new SecuritySettings(
                securityConfiguration["EncryptionKey"], securityConfiguration["Issue"],
                securityConfiguration.GetValue<TimeSpan>("ExpirationPeriod"));
            var jwtIssuer = new JwtIssuer(securitySettings);
            services.AddSingleton(securitySettings);
            services.AddSingleton<IJwtIssuer>(jwtIssuer);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(securitySettings.EncryptionKey))
                    };
                });

            services
                .AddAuthorization(options =>
                {
                    options.DefaultPolicy =
                        new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                            .RequireAuthenticatedUser().Build();
                });
        }
    }
}
