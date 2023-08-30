using System.Text;
using ApplicationServices.CourseApplicationService;
using ApplicationServices.CourseAttendanceApplicationService;
using ApplicationServices.GenericApplicationService;
using ApplicationServices.SessionApplicationService;
using DataAccess.CategoryRepository;
using DataAccess.CourseAttendanceRepository;
using DataAccess.CourseAttendancesQueryRepository;
using DataAccess.CourseRepository;
using DataAccess.DbContext;
using DataAccess.GenericRepository;
using DataAccess.SessionAttendanceRepository;
using DataAccess.SessionRepository;
using DataAccess.UserRepository;
using Domain.Entities;
using Infrastructure.AuthService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injection registration

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericApplicationService<,>), typeof(GenericApplicationService<,>));

//USER
builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();

//COURSE
builder.Services.AddScoped<ICourseApplicationService, CourseApplicationService>();
builder.Services.AddScoped<IGenericRepository<Course>, CourseRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseAttendancesQueryRepository, CourseAttendancesQueryRepository>();

//CATEGORY
builder.Services.AddScoped<IGenericRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//SESSION
builder.Services.AddScoped<IGenericRepository<Session>, SessionRepository>();
builder.Services.AddScoped<ISessionApplicationService, SessionApplicationService >();
builder.Services.AddTransient<IAuthService, AuthService>();

//COURSE ATTENDANCE
builder.Services.AddScoped<ICourseAttendanceApplicationService, CourseAttendanceApplicationService>();
builder.Services.AddScoped<ICourseAttendanceRepository, CourseAttendanceRepository>();

//SESSION ATTENDANCE
builder.Services.AddScoped<ISessionAttendanceRepository, SessionAttendanceRepository>();

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

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


builder.Services.AddCors(options =>  
{  
          
    options.AddDefaultPolicy(  
        policy =>  
        {  
            policy.AllowAnyOrigin()  
                .AllowAnyHeader()  
                .AllowAnyMethod();  
        });  
});  

builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();