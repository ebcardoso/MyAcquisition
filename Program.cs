using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyAcquisition.Api.Application.Mapping;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Application.Service;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Domain.Repositories;
using MyAcquisition.Api.Infrastructure.Context;

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

    // Repositories
    builder.Services.AddScoped<IAcquisitionsRepository, AcquisitionsRepository>();
    builder.Services.AddScoped<IAcquisitionProductsRepository, AcquisitionProductsRepository>();
    builder.Services.AddScoped<IAcquisitionProposalsRepository, AcquisitionProposalsRepository>();
    builder.Services.AddScoped<IBrandsRepository, BrandsRepository>();
    builder.Services.AddScoped<ICompaniesRepository, CompaniesRepository>();
    builder.Services.AddScoped<ICompanyUsersRepository, CompanyUsersRepository>();
    builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();

    // Services
    builder.Services.AddScoped<IAcquisitionsServices, AcquisitionsServices>();
    builder.Services.AddScoped<IAcquisitionProductsServices, AcquisitionProductsServices>();
    builder.Services.AddScoped<IAcquisitionProposalsServices, AcquisitionProposalsServices>();
    builder.Services.AddScoped<IAuthServices, AuthServices>();
    builder.Services.AddScoped<IBrandsServices, BrandsServices>();
    builder.Services.AddScoped<ICompaniesServices, CompaniesServices>();
    builder.Services.AddScoped<ICompanyUsersServices, CompanyUsersServices>();
    builder.Services.AddScoped<IProductsServices, ProductsServices>();
    builder.Services.AddScoped<IUsersServices, UsersServices>();

    // Mappings
    builder.Services.AddAutoMapper(typeof(DomainToDTOMapping));

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
