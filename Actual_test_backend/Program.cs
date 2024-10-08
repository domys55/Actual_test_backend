using Repository;

using Microsoft.EntityFrameworkCore;
using Actual_test_backend;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the DbContext with the dependency injection system
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

string CORSOpenPolicy = "OpenCORSPolicy";

builder.Services.AddCors(options => {
    options.AddPolicy(
  name: CORSOpenPolicy,
  builder => {
      builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
  });
});


DependencyInjectHelper.AddCustomServices(builder.Services);

builder.Services.AddControllers();
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
app.UseCors(CORSOpenPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
