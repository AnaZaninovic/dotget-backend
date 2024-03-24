using dotget_backend.Requests;
using DotGetBackend.Application;
using DotGetBackend.Application.Features.Professors.Commands;
using DotGetBackend.Application.Features.Students.Commands;
using DotGetBackend.Infrastructure;
using DotGetBackend.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme()
        {
            Description = @"JWT Authorization token using the Bearer scheme. <br>
                      Enter 'Bearer' [space] and then your token in the text input below. <br>
                      Example: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Authorization",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(p =>
    {
        p.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
await db.Database.MigrateAsync();

app.UseCors();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(c => { c.InjectStylesheet("/swagger-ui/SwaggerDark.css"); });

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger/index.html"));


app.Run();
