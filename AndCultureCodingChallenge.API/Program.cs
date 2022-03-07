using AndCultureCodingChallenge.BL.Interface;
using AndCultureCodingChallenge.BL.Services;
using AndCultureCodingChallenge.Data.Models;
using Microsoft.EntityFrameworkCore;

var JamesZackaOrigins = "_jamesZackaOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: JamesZackaOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:7009/*",
                                                "https://localhost:7009/*")
                                                .AllowAnyOrigin();
                      });
});

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OpenBreweryDBContext>(options => {

	#if DEBUG
		options.UseSqlServer(
			builder.Configuration.GetConnectionString("DefaultLocalConnection"));
	#elif RELEASE
		options.UseNpgsql(
			builder.Configuration["Heroku:AndCulture:Postgres:ConnectionString"]);
	#endif
});
builder.Services.AddScoped<IOpenBreweryService, OpenBreweryService>();

var app = builder.Build();

app.UseCors(JamesZackaOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapControllerRoute(
//	name: "getByCity",
//	pattern: "api/{controller}/{action}/{city}",
//	defaults: new { controller = "Breweries", action = "GetBreweriesByCity" }
//);

app.Run();
