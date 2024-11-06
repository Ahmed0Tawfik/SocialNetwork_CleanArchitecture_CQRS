
namespace SocialNetwork.API.Registers
{
    public class MvcAppRegister : IAppBuilderRegister
    {
        public void RegisterService(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
   
}
