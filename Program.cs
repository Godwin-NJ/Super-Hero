global using SuperHero.Models;
global using SuperHero.Data;
global using SuperHero.Services.SuperHeroServices;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
//builder.Services.AddSingleton<ISuperHeroService, SuperHeroService>();//this can be used inplace of the \AddScoped
//builder.Services.AddTransient<ISuperHeroService, SuperHeroService>();//this can be used inplace of the \AddScoped
//the abv syncs what has been implemented in the SuperHeroService with ISuperHeroService
builder.Services.AddDbContext<DataContext>();

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
