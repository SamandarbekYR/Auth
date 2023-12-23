using Auth.Configurations;
using Auth.DataAccess.Data;
using Auth.DataAccess.Repository.Users;
using Auth.Services.TokenService;
using Auth.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql());
builder.Services.AddTransient<UsersRepository, UsersRepository>();
builder.Services.AddTransient<UserService, UserService>();
builder.Services.AddTransient<Token, Token>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
