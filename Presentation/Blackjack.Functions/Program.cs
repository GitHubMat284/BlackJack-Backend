using Blackjack.Application.Interfaces;
using Blackjack.Application.UseCases;
using MemoryGameData;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

// Dependency Injection
builder.Services.AddSingleton<IGameDataGateway, MemoryGameDataGateway>();
builder.Services.AddSingleton<StartGame>();
builder.Services.AddSingleton<PlayerHit>();
builder.Services.AddSingleton<PlayerStand>();

builder.Build().Run();
