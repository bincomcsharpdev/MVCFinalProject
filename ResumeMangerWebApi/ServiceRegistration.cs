using ResumeMangerWebApi.Data.Repository.Interfaces;
using ResumeMangerWebApi.Data.Repository.Repository;
using ResumeMangerWebApi.Implementation.Interfaces;
using ResumeMangerWebApi.Implementation.Services;

namespace ResumeMangerWebApi
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ITaxRepository, TaxRepository>()
                .AddScoped<IPhotoRepository, PhotoRepository>()
                .AddScoped<ITaxService, TaxService>()
                .AddScoped<IPhotoService, PhotoService>();

        }
    }
}
