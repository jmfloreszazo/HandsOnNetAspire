var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
    .AddDatabase("sqldata");

builder.AddProject<Projects.AspireDatabaseSample_Service>("aspiredatabasesample-service")
    .WithReference(sql);

builder.Build().Run();
