var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DeliveryApp_Web>("web");

builder.Build().Run();