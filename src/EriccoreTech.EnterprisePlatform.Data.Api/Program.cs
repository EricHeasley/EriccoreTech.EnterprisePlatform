using EriccoreTech.EnterprisePlatform.Data.Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PlatformData")
    ?? throw new InvalidOperationException("Connection string 'PlatformData' is not configured.");

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddRecordServices(connectionString);

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
