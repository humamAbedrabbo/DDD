
using DDD.Application;
using DDD.Application.Features.Companies.GetById;
using DDD.Domain.Entities.Companies;
using DDD.Infrastructure;
using MediatR;

namespace DDD.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/company", async (HttpContext httpContext, ISender sender) =>
            {
                return await sender.Send(
                    new GetByIdAsyncQuery(new CompanyId(1)));
            })
            .WithName("GetCompany")
            .WithOpenApi();

            app.Run();
        }
    }
}