using EriccoreTech.EnterprisePlatform.Data.Service;
using EriccoreTech.EnterprisePlatform.Data.Service.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<IRecordService, RecordService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
