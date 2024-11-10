using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Application;
using SocialNetwork.Application.UserProfileCQ.Query;
using SocialNetwork.DAL;
using SocialNetwork.DAL.Repository;
using SocialNetwork.Domain.Interfaces;

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
        }
    }
   
}
