var builder = DistributedApplication.CreateBuilder(args);

var keyVault = builder.AddAzureKeyVault("mysecrets");

var apiService = builder.AddProject<Projects.AspireWeatherSample_ApiService>("apiservice")
    .WithReplicas(2)
    .WithReference(keyVault);

builder.AddProject<Projects.AspireWeatherSample_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
