var builder = DistributedApplication.CreateBuilder(args);

string launchMode = builder.Configuration["LAUNCH_MODE"] ?? "Local";

if (launchMode == "Local")
{
    var sql = builder.AddSqlServer("sql")
        .AddDatabase("sqldata");

    var grafana = builder.AddContainer("grafana", "grafana/grafana")
        .WithBindMount("../grafana/config", "/etc/grafana", isReadOnly: true)
        .WithBindMount("../grafana/dashboards", "/var/lib/grafana/dashboards", isReadOnly: true)
        .WithHttpEndpoint(targetPort: 3000, name: "grafana-http");

    var prometheus = builder.AddContainer("prometheus", "prom/prometheus")
        .WithBindMount("../prometheus", "/etc/prometheus", isReadOnly: true)
        .WithHttpEndpoint(port: 9090, targetPort: 9090);

    builder.AddProject<Projects.AspireDatabaseSample_Service>("aspiredatabasesample-service")
        .WithEnvironment("GRAFANA_URL", grafana.GetEndpoint("grafana-http"))
        .WithReference(sql);
} 
else 
{
    var logs = builder.AddAzureLogAnalyticsWorkspace("logs");
    var appInsights = builder.AddAzureApplicationInsights("insights", logs);

    var sql = builder.AddSqlServer("sql")
        .WithReference(appInsights)
        .AddDatabase("sqldata");


    builder.AddProject<Projects.AspireDatabaseSample_Service>("aspiredatabasesample-service")
        .WithReference(appInsights)
        .WithReference(sql);
}

builder.Build().Run();

