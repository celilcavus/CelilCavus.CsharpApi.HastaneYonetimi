using CelilCavus.Contexts;
using CelilCavus.Entites;
using CelilCavus.Interfaces;
using CelilCavus.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddScoped<IBaseDbContext,dbContext>();
        builder.Services.AddScoped<IRepository<Hastane>,HastaneRepository>();
        builder.Services.AddScoped<IRepository<Hasta>,HastaRepository>();
        builder.Services.AddScoped<IRepository<Doktor>,DoktorRepository>();
        builder.Services.AddScoped<IRepository<Randevu>,RandevuRepository>();
        builder.Services.AddScoped<IRepository<Tedavi>,TedaviRepository>();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}