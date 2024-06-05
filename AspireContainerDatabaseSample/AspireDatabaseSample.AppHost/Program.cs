var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
    .AddDatabase("sqldata");

builder.AddProject<Projects.AspireDatabaseSample_Api>("aspiredatabasesample-api")
    .WithReference(sql);

builder.Build().Run();
