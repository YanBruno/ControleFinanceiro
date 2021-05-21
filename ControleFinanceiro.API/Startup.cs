using ControleFinanceiro.Domain.Handlers;
using ControleFinanceiro.Domain.Repositories.Contracts;
using ControleFinanceiro.Domain.Services.Contracts;
using ControleFinanceiro.Infra.DataContexts;
using ControleFinanceiro.Infra.Repository;
using ControleFinanceiro.Infra.Services;
using ControleFinanceiro.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ControleFinanceiro.API
{
    public class Startup
    {       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddResponseCompression();

            services.AddScoped<ControleFinanceiroContext, ControleFinanceiroContext>();

            //Handlers
            services.AddTransient<CustomerHandler, CustomerHandler>();
            services.AddTransient<InputHandler, InputHandler>();

            //Services
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<ITokenService, TokenService>();

            //Repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICodeRepository, CodeRepository>();
            services.AddTransient<IInputRepository, InputRepository>();
            services.AddTransient<IStatementRepository, StatementRepository>();

            //Token configuration
            var key = Encoding.ASCII.GetBytes(Settings.SecretToken);
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x => {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
