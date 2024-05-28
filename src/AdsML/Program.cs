using AdsML;
using AdsML.Common.Extensions;
using AdsML.Common.Shared;
using AdsML.Features.Ads.Common;
using AdsML.Features.Ads.Common.AdsMLModels;
using Microsoft.Extensions.ML;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<AppSetting>()
    .Bind(builder.Configuration.GetSection(AppSetting.ConfigurationSectionName));

builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureValidator();

builder.Services.AddPredictionEnginePool<ModelInput,ModelOutput>()
.LoadModel(builder.Configuration);

builder.Services.AddSingleton<PredictService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
