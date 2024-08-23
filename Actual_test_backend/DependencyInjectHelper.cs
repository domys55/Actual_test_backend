using InterfaceCollection.repository;
using InterfaceCollection.service;
using Repository;
using Service;

namespace Actual_test_backend
{
    public static class DependencyInjectHelper
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();

            services.AddScoped<IContactRepository, ContactRepository>();
            // Add other services as needed
        }
    }
}
