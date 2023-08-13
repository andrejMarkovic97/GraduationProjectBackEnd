using System.Text;
using Application.GenericService;
using DataAccess.DbContext;
using DataAccess.GenericRepository;
using DataAccess.UserRepository;
using Domain.Entities;
using Infrastructure.AuthenticationService;
using Infrastructure.AuthService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injection registration

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddTransient<IAuthService, AuthService>();
//Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//DbContext
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer("name=ConnectionStrings:DefaultConnection"));


//Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();