using AutoDoc.DataBase.ContextDb;
using AutoDoc.Infrastructure.Application.Commands.Tasks.AddTask;
using AutoDoc.Infrastructure.Application.Queries.Files;
using AutoDoc.Infrastructure.Application.Queries.Tasks;
using AutoDoc.Utils.AspNet.Extensions;
using AutoDoc.Utils.AspNet.Middlewares;
using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using AutoDoc.Utils.TraceHolder.TraceHolder.Models;
using AutoDoc.Utils.Validation.ValidationBehaviours;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTraceHolder();
builder.Services.AddGuidGenerator();

builder.Services.AddMediatR(typeof(Program), typeof(AddTaskCommandHandler), typeof(AddTaskCommand));

builder.Services.AddDbContext<AutoDocContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutoDocConnectionString"), e =>
    {

    });
});

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("*")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add<FluentValidationExceptionFilter>();
    }).AddNewtonsoftJson(options =>
    {
        var serializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = new List<JsonConverter>() { new StringEnumConverter() },
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        JsonConvert.DefaultSettings = () => serializerSettings;

        options.SerializerSettings.Formatting = serializerSettings.Formatting;
        options.SerializerSettings.Converters.Add(serializerSettings.Converters.First());
        options.SerializerSettings.ContractResolver = serializerSettings.ContractResolver;
    })
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        //fv.RegisterValidatorsFromAssemblyContaining<Program>();
        fv.LocalizationEnabled = true;
    });

builder.Services.AddScoped<ITaskQueries, TaskQueries>();
builder.Services.AddScoped<IFileQueries, FileQueries>();

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
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<TraceHolderMiddleware>();
app.UseMiddleware<HttpGlobalExceptionMiddleware>();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
