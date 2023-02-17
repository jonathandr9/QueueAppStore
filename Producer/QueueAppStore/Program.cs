using Microsoft.Extensions.DependencyInjection;
using QueueAppStore.API;
using QueueAppStore.Application;
using QueueAppStore.CacheAdapter.Configuration;
using QueueAppStore.Domain.Services;
using QueueAppStore.RabbitMQAdapter.Configuration;
using QueueAppStore.SqlAdapter.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlAdapter(
                builder.Configuration.GetSection("SqlAdapterConfiguration")
                .Get<SqlAdapterConfiguration>());

builder.Services.AddCacheAdapter(
                builder.Configuration.GetSection("CacheAdapterConfiguration")
                .Get<CacheAdapterConfiguration>());

builder.Services.AddRabbitMQAdapter(
                builder.Configuration.GetSection("RabbitMQAdapterConfiguration")
                .Get<RabbitMQAdapterConfiguration>());

builder.Services.AddIdentityAdapter(builder.Configuration);

builder.Services.AddAutoMapper(typeof(ApiMapperProfile));

//Services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAppService, AppService>();
builder.Services.AddScoped<IClientService, ClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthConfiguration();

app.MapControllers();

app.Run();
