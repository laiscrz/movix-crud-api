using Data; 
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoDbSettings>(sp =>
    sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

builder.Services.AddSingleton<MongoDbFactory>(); 

builder.Services.AddControllers();

var app = builder.Build();

// Configuração do pipeline HTTP
app.UseAuthorization();
app.MapControllers();

app.Run();
