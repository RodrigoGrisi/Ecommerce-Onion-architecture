using Ecommerce.Domain.Model;

namespace Ecommerce.Infrastructure.Data.Repositories;


public class CustomerRepository : ICustomerRepository
{

    private readonly IDocumentStore _documentStore;

    public CustomerRepository(IDocumentStore documentStore)
    {
        _documentStore = documentStore;
    }

    public Customer? GetByEmail(string email)
    {
        var documentSession = _documentStore.OpenSession();
        var customerEmailVerify = documentSession.Query<Customer>()
          .FirstOrDefault(c => c.Email == email);

        if (customerEmailVerify is not null) return customerEmailVerify;
        return null;
    }

    void ICustomerRepository.Delete(string id)
    {
        var documentSession = _documentStore.OpenSession();
        var customer = documentSession.Load<Customer>(id);

        if (customer is not null)
        {
            documentSession.Delete(customer);
            documentSession.SaveChanges();
        }
    }

    IEnumerable<Customer> ICustomerRepository.Get()
    {
        var documentSession = _documentStore.OpenSession();
        return documentSession.Query<Customer>().ToList();
    }

    Customer ICustomerRepository.Get(string id)
    {
        var documentSession = _documentStore.OpenSession();
        var customer = documentSession.Load<Customer>(id);
        return customer;
    }

    void ICustomerRepository.Insert(Customer customer)
    {
        var documentSession = _documentStore.OpenSession();
        documentSession.Store(customer);
        documentSession.SaveChanges();
    }

    void ICustomerRepository.Update(Customer customer)
    {
        var documentSession = _documentStore.OpenSession();

        var customerEntity = documentSession.Query<Customer>()
          .FirstOrDefault(c => c.Email == customer.Email);

        if (customerEntity is not null)
        {
            customerEntity.Name = customer.Name;
            customerEntity.LastName = customer.LastName;
            customerEntity.Email = customer.Email;
            customerEntity.Address = customer.Address;
            customerEntity.BirthDate = customer.BirthDate;
            customerEntity.Address = customer.Address;
            customerEntity.Cpf = customer.Cpf;
            customerEntity.isActive = true;
        }

        documentSession.SaveChanges();
    }
}
