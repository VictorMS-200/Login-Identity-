using System.Text;
using Entity.Auth;
using Entity.Data;
using Entity.Models;
using Entity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// Creating the webapplication with the builder and the args
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration["ConnectionStrings:UsuarioConnection"];


builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

// Add services to the container. (Dependency Injection)
builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddSingleton<IAuthorizationHandler, AgeAuth>();


// Adding AutoMapper to the services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Adding the dbcontext to the services with the connectionstring
builder.Services.AddDbContext<UserDbContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// Adding Identity to the services
builder.Services
    .AddIdentity<User, IdentityRole>() // Adding the user and the role
    .AddEntityFrameworkStores<UserDbContext>() // Adding the userdbcontext
    .AddDefaultTokenProviders(); // Adding the default token providers


// Adding the password settings to the services
builder.Services.Configure<IdentityOptions>(opts => 
{
    // Password settings. (Change to your own liking.)
    opts.Password.RequiredUniqueChars = 1; // 1 unique character (e.g. '%')
    opts.Password.RequiredLength = 5; // 5 characters long minimum 
    opts.Password.RequireDigit = true; // Require a digit (0-9)
    opts.Password.RequireNonAlphanumeric = true; // Require a non alphanumeric character (e.g. '%')
    opts.Password.RequireUppercase = true; // Require a uppercase digit
    opts.Password.RequireLowercase = true; // Require a lowercase digit 
});


builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("MinAge", policy =>
        policy.AddRequirements(new MinAge(18))
    );
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


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
