using Data;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Repositories;
using Mapping;
using Data.Settings;

var builder = WebApplication.CreateBuilder(args);

// Configuração do MongoDB
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

builder.Services.AddSingleton<MongoDbFactory>();

builder.Services.AddScoped<IMovieRepository>(sp =>
{
    var mongoDbFactory = sp.GetRequiredService<MongoDbFactory>();
    var mongoDbSettings = sp.GetRequiredService<MongoDbSettings>();
    return new MovieRepository(mongoDbFactory, mongoDbSettings);
});

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MovieMappingProfile)); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Movix API",
        Version = "v1",
        Description = "A Movix API permite gerenciar um catálogo de filmes, oferecendo operações de criação, leitura, atualização e exclusão. Utiliza MongoDB e suporta operações assíncronas para maior eficiência e escalabilidade.\n\n" +
                      "Acesse o código fonte: [Repositório](https://github.com/laiscrz/movix-crud-api)",
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://github.com/laiscrz/movix-crud-api/blob/main/LICENSE")
        }
    });

    options.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movix API v1");
        c.RoutePrefix = ""; 
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
