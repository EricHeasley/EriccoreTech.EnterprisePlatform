using EriccoreTech.EnterprisePlatform.Orchestration.Host;
using EriccoreTech.EnterprisePlatform.Orchestration.Service;
using EriccoreTech.EnterprisePlatform.Orchestration.Service.Contracts;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IWorkflowExecutionService, WorkflowExecutionService>();
builder.Services.AddHostedService<OrchestrationWorker>();

var host = builder.Build();

host.Run();
