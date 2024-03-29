using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Infrastructure.Context;
using MyAcquisition.Api.Presentation.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.Repositories;
using MyAcquisition.Api.Application.Service;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var Configuration = builder.Configuration;

    builder.Services.AddDbContext<ApiDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
    );
    builder.Services.AddAuthentication(opt =>
    {
      opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(opt =>
    {
      opt.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true, //Who generates the token 
        ValidateAudience = true, //Who consumes the token
        ValidateLifetime = true, //Deadline
        ValidateIssuerSigningKey = true, //Validates login

        ValidIssuer = Configuration.GetValue<string>("jwt:issuer"),
        ValidAudience = Configuration.GetValue<string>("jwt:audience"),
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(Configuration.GetValue<string>("jwt:secretKey"))),
        ClockSkew = TimeSpan.Zero
      };
    });
    builder.Services.AddControllers();
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();
    builder.Services.AddScoped<IUsersServices, UsersServices>();
    builder.Services.AddAutoMapper(typeof(UsersMapping));
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
  }
}
