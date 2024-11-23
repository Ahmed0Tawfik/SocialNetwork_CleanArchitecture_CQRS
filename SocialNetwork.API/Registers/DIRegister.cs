using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.API.Configuration;
using SocialNetwork.Application;
using SocialNetwork.Application.UserProfileCQ.Query;
using SocialNetwork.DAL;
using SocialNetwork.DAL.Repository;
using SocialNetwork.Domain.Interfaces;
using System.Text;

namespace SocialNetwork.API.Registers
{
    public class DIRegister : IAppBuilderRegister
    {
        public void RegisterService(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SocialContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ApplicationMediatorEntryPoint).Assembly));
            builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllUserProfileQuery));
            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JWTConfig"));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JWTConfig:SecretKey").Value);
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, //for dev
                    ValidateAudience = false,//for dev
                    RequireExpirationTime = false,//for dev when refresh tokens is add 
                    ValidateLifetime = true
                };
            });
        }
    }
   
}
