
using Arti.Client.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectArti.Api.Data;
using ProjectArti.Api.Service;
using System.Drawing.Imaging;
using System.Text;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var cont = builder.Configuration.GetConnectionString("Defaultconnection");
builder.Services.AddDbContext<My_dbContext>(options => options.UseSqlServer(cont));
builder.Services.AddControllers().AddJsonOptions(options =>

{
    options.JsonSerializerOptions.Converters.Add(new EnumToStringConverter<Gender>());
    options.JsonSerializerOptions.Converters.Add(new EnumToStringConverter<StatuApplicant>());
    options.JsonSerializerOptions.Converters.Add(new EnumToStringConverter<StatusProperty>());
    options.JsonSerializerOptions.Converters.Add(new EnumToStringConverter<StatusRequest>());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
builder.Services.AddSingleton(jwtOptions);
builder.Services.AddScoped<IGetToken, GetToken>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
options=> options.TokenValidationParameters = new TokenValidationParameters

{
    ValidateIssuer = true,
    ValidIssuer=jwtOptions.Issuer,

  
    ValidateAudience = true,
    ValidAudience=jwtOptions.Audiences,
    ValidateLifetime = true,
    
    ValidateIssuerSigningKey = true,
    IssuerSigningKey= new  SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.SecretKey))
});


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(

    options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(1);
        options.Cookie.HttpOnly = true; // xss + csrf
        options.Cookie.IsEssential = true;
    }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireRoleAdmin", builder => builder.RequireRole("Admin"));
    options.AddPolicy("RequireRoleUser", builder => builder.RequireRole("User"));
    options.AddPolicy("RequireRoleCraftsman", builder => builder.RequireRole("Craftsman"));
    options.AddPolicy("RequireRoleEmployee", builder => builder.RequireRole("Employee"));
    options.AddPolicy("RequireRoleProperty", builder => builder.RequireRole("Property"));
  
}
);
var app = builder.Build();
// GET  progrm
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
