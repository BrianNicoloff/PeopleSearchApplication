using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;

namespace PeopleSearchApplication
{
    public static class Dependencies
    {
        public static void Resolve(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => !t.IsAssignableTo<IAutofacActionFilter>())
                .Where(t => !t.IsAssignableTo<IAutofacExceptionFilter>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}
