using EriccoreTech.EnterprisePlatform.Integration.Host;
using EriccoreTech.EnterprisePlatform.Integration.Service;
using EriccoreTech.EnterprisePlatform.Integration.Service.Contracts;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IConnectorService, ConnectorService>();
builder.Services.AddHostedService<IntegrationWorker>();

var host = builder.Build();

host.Run();
