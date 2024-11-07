using Microsoft.EntityFrameworkCore;
using SocialNetwork.DAL;

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
        }
    }
   
}
