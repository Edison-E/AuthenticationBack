using AuthBack.src.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add connection data base
builder.Services.AddDbContext<AplicationDbContext>(options => 
      options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure Independcy Inyection

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
