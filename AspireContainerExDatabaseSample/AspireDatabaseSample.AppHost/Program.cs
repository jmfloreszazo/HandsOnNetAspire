var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
    .WithImage("mssql/server", "2019-latest")
    .WithImageRegistry("mcr.microsoft.com")
    .WithEnvironment("ACCEPT_EULA", "Y")
    .WithEnvironment(context => 
        context.EnvironmentVariables["MSSQL_SA_PASSWORD"] = "<YourStrong@Passw0rd>")
    .AddDatabase("sqldata");

builder.AddProject<Projects.AspireDatabaseSample_Api>("aspiredatabasesample-api")
    .WithReference(sql);

builder.Build().Run();
