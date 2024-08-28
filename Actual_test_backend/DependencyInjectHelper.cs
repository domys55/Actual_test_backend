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

            //services.AddScoped<IAddressService, AddressService>();

            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IPhoneService, PhoneService>();

            services.AddScoped<IPhoneRepository, PhoneRepository>();

            services.AddScoped<IContactAggreagateService, ContactAggreagateService>();
            // Add other services as needed
        }
    }
}
