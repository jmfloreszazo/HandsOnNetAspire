var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireAndAZD_ApiService>("apiservice");

builder.AddProject<Projects.AspireAndAZD_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
