using AdsML.Common.Extensions;
using AdsML.Common.Shared;
using Microsoft.Extensions.ML;
using Carter;
using ServiceCollector.Core;
using AdsML.Features.Ads.Common.AdsMLModels;
using AdsML.Features.Ads.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();
builder.Services.AddServiceDiscovery();

builder.Services.AddOptions<AppSetting>()
    .Bind(builder.Configuration.GetSection(AppSetting.ConfigurationSectionName));

builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureValidator();

builder.Services.AddPredictionEnginePool<ModelInput, ModelOutput>()
.LoadModel(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapCarter();

app.Run();
