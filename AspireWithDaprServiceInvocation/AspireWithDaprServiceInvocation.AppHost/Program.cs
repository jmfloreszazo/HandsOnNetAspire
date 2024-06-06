using Aspire.Hosting.Dapr;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AspireWithDaprServiceInvocation_ApiService>("apiservice")
    .WithDaprSidecar("api");

builder.AddProject<Projects.AspireWithDaprServiceInvocation_Web>("webfrontend")
    .WithDaprSidecar("web");

// Workaround for https://github.com/dotnet/aspire/issues/2219
if (builder.Configuration.GetValue<string>("DAPR_CLI_PATH") is { } daprCliPath)
{
    builder.Services.Configure<DaprOptions>(options =>
    {
        options.DaprPath = daprCliPath;
    });
}

builder.Build().Run();