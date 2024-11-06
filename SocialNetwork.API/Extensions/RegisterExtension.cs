using SocialNetwork.API.Registers;

namespace SocialNetwork.API.Extensions
{
    public static class RegisterExtension
    {
        public static void RegisterPipeLine(this WebApplication app, Type scanningType)
        {
            var registrars = GetRegistrars<IAppRegister>(scanningType);
            foreach (var registrar in registrars)
            {
                registrar.RegisterPipeLine(app);
            }
        }

        public static void RegisterService(this WebApplicationBuilder builder, Type scanningType)
        {
            var registrars = GetRegistrars<IAppBuilderRegister>(scanningType);

            foreach (var registrar in registrars)
            {
                registrar.RegisterService(builder);
            }
        }

        private static IEnumerable<T> GetRegistrars<T>(Type scanningType)
        {
            return scanningType.Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<T>();
        }
    }
}
