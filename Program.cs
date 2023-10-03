using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<CustomersAPIDbContext>(options => options.UseInMemoryDatabase("CustomerDb"));
//builder.Services.AddDbContext<MoviesAPIDbContext>(options => options.UseInMemoryDatabase("MovieDb"));
//builder.Services.AddDbContext<RentalAPIDbContext>(options => options.UseInMemoryDatabase("RentalDb"));
//builder.Services.AddDbContext<RentalAPIDbContext>(options => 
//options.UseSqlServer(builder.Configuration.GetConnectionString("RentalVideoAPIConnection")));
builder.Services.AddDbContext<CustomersAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentalVideoAPIConnection")));
builder.Services.AddDbContext<MoviesAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentalVideoAPIConnection")));
builder.Services.AddDbContext<RentalAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentalVideoAPIConnection")));

var app = builder.Build();

app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

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
