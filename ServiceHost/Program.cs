using Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<AppSetting>()
    .Bind(builder.Configuration.GetSection(AppSetting.ConfigurationSectionName));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
