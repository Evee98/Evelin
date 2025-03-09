using Microsoft.Extensions.Options;
using OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;
using OperationOOP.Core.Services;

namespace OperationOOP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // L�gger till tj�nster i containern
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
            });

            // Registrerar IDatabase och BonsaiManager som tj�nster
            builder.Services.AddSingleton<IDatabase, Database>();
            builder.Services.AddScoped<BonsaiManager>(); // Ny

            var app = builder.Build();

            // Konfigurerar HTTP-request-pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapEndpoints<Program>();
            app.Run();
        }
    }
}