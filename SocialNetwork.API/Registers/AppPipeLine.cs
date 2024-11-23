
namespace SocialNetwork.API.Registers
{
    public class AppPipeLine : IAppRegister
    {
        public void RegisterPipeLine(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();


        }
    }
}
