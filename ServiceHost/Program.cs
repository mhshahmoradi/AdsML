using AdsML.Application.UseCase.ML.Commands.Predict;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Middleware;
using Shared;
using AdsML.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<AppSetting>()
    .Bind(builder.Configuration.GetSection(AppSetting.ConfigurationSectionName));

builder.Services.RegisterService(builder.Configuration.GetConnectionString("ApplicationDbContext"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<BusinessValidationExceptionHandling>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.MapPost("/Predict", async Task<IActionResult>(ISender _mediarR, [FromBody] PredictCommand command) =>
{
    var result = await _mediarR.Send(command);
    return new OkObjectResult(result);
});

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
