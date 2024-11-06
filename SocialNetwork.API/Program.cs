using SocialNetwork.API.Extensions;

namespace SocialNetwork.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.RegisterService(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.RegisterPipeLine(typeof(Program));

            app.Run();

        }
    }
}
