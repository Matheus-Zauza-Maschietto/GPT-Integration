using System.Net.Http.Headers;
using gpt_integration;
using gpt_integration.Enums;
using gpt_integration.Extensions;
using gpt_integration.Models;
using gpt_integration.Repositories;
using gpt_integration.Repositories.Interfaces;
using gpt_integration.Services;
using gpt_integration.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient(nameof(HttpClients.GPT), (httpClient) => {
    httpClient.BaseAddress = new Uri("https://api.openai.com/");
    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {builder.Configuration["ChatGpt:Token"]}" ?? "Token gpt api not found");
    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

});

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGPTRepository, GPTRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
builder.Services.AddScoped<IChatMessageService, ChatMessageService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.ApplyMigrations();

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();

