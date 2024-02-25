using AdsML.Application.UseCase.ML.Commands.Predict;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Middleware;
using Shared;
using AdsML.Infrastructure.Configuration;
using Hangfire;
using Hangfire.Storage.SQLite;
using AdsML.Application.Notification.Retrain;
using System.Reflection;
using Hangfire.Common;
using ServiceHost.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<AppSetting>()
    .Bind(builder.Configuration.GetSection(AppSetting.ConfigurationSectionName));

builder.Services.RegisterService(builder.Configuration.GetConnectionString("ApplicationDbContext"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(configuration => configuration
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSQLiteStorage("hangfire.db"));

builder.Services.AddHangfireServer();

builder.Services.AddExceptionHandler<BusinessValidationExceptionHandling>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.MapPost("/Predict", async Task<IActionResult> (ISender _mediarR, [FromBody] PredictCommand command) =>
{
    var result = await _mediarR.Send(command);
    return new OkObjectResult(result);
});

app.Services.GetService<IRecurringJobManager>().AddOrUpdate<BackgroundTask>(
    "RetrainTask",
    service => service.Retrain(),
    Cron.Daily(4)
    );

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();