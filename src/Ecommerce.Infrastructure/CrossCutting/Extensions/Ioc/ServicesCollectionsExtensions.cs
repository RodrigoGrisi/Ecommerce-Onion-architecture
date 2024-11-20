using Ecommerce.Application;

namespace Ecommerce.Infrastructure.CrossCutting.Extensions.Ioc;
public static class ServicesCollectionsExtensions
{
    public static IServiceCollection AddRavenDb(this IServiceCollection servicesCollection)
    {
        servicesCollection.TryAddSingleton<IDocumentStore>(ctx =>
        {
            var ravenDbSettings = ctx.GetRequiredService<IOptions<RavenDbSettings>>().Value;

            if (string.IsNullOrWhiteSpace(ravenDbSettings?.Url))
                throw new ArgumentNullException(nameof(ravenDbSettings.Url), "A URL do RavenDB não pode ser nula ou vazia.");

            if (string.IsNullOrWhiteSpace(ravenDbSettings.DatabaseName))
                throw new ArgumentNullException(nameof(ravenDbSettings.DatabaseName), "O nome do banco de dados não pode ser nulo ou vazio.");

            var store = new DocumentStore
            {
                Urls = new[] { ravenDbSettings.Url }, // Ajuste feito aqui
                Database = ravenDbSettings.DatabaseName,
            };

            store.Initialize();
            return store;
        });

        return servicesCollection;
    }


    public static IServiceCollection AddRepositories(this IServiceCollection servicesCollection)
    {
        servicesCollection
            .TryAddSingleton<ICustomerRepository, CustomerRepository>();
        return servicesCollection;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection servicesCollection)
    {
        servicesCollection
            .TryAddScoped<ICustomerService, CustomerService>();
        return servicesCollection;
    }

    public static IServiceCollection AddMappers(this IServiceCollection servicesCollection)
    {
        servicesCollection.TryAddScoped<IMapper<Customer, CustomerDto>, CustomerMapper>();
        servicesCollection.TryAddScoped<IMapper<CustomerDto, Customer>, CustomerMapper>();
        return servicesCollection;
    }
    public static IServiceCollection AddAplicationService(this IServiceCollection servicesCollection)
    {
        servicesCollection.TryAddScoped<ICustomerApplicationService, CustomerApplicationService>();
        return servicesCollection;
    }


}