using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using LanguageLearningAPI.Data;
using LanguageLearningAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Serialize/accept enums as strings (e.g. "Word", "Learner") so the JSON wire
// format matches the string values persisted in Postgres and the API spec.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core + PostgreSQL (connection string in appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DatabaseRepository>();

var app = builder.Build();

// Apply EF Core migrations on startup so the database schema is provisioned automatically on deploy.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
    DbSeeder.Seed(db);
}

// Swagger is exposed in all environments to allow smoke-testing the deployed API.
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS redirect only locally; Railway terminates TLS at its edge and forwards plain HTTP,
// so redirecting in production causes redirect loops.
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Serve the static frontend from wwwroot (index.html is the SPA entry point).
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
