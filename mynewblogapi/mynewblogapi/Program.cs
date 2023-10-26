using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog API", Version = "v1" });
});

// Configure the database connection string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
AppContext.SetSwitch("Switch.System.Net.DontEnableSchUseStrongCrypto", true);

builder.Services.AddScoped<BlogRepository>(_ => new BlogRepository(connectionString));
builder.Services.AddScoped<BlogProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API v1"));
}

app.UseRouting(); // Add this line to enable routing

// Use CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
