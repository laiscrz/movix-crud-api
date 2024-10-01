using Data;
using Microsoft.Extensions.Options;
using Models;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));


builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);


builder.Services.AddSingleton<MongoDbFactory>();

builder.Services.AddScoped<IRepository<MovieModel>>(sp =>
{
    var mongoDbFactory = sp.GetRequiredService<MongoDbFactory>();
    var mongoDbSettings = sp.GetRequiredService<MongoDbSettings>();
    return new MovieRepository(mongoDbFactory, mongoDbSettings);
});

builder.Services.AddControllers();

var app = builder.Build();


app.UseAuthorization();
app.MapControllers();

app.Run();
