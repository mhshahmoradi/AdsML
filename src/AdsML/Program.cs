using AdsML.Common.Extensions;
using AdsML.Common.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<AppSetting>()
    .Bind(builder.Configuration.GetSection(AppSetting.ConfigurationSectionName));

builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureValidator();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
