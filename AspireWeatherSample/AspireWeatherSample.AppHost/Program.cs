var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireWeatherSample_ApiService>("apiservice")
    .WithReplicas(2);

builder.AddProject<Projects.AspireWeatherSample_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
