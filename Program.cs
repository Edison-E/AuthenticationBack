using AuthBack.src.Application.Service;
using AuthBack.src.Domain.Interface;
using AuthBack.src.Infrastructure.Data;
using AuthBack.src.Infrastructure.Repositorios;
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

// Configure Independcy Inyection
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



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
