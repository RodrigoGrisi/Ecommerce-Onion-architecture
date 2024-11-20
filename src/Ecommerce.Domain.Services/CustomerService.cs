namespace Ecommerce.Domain.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public void SaveCustomer(Customer customer)
    {
        ValidateEmail(customer.Email);
        _customerRepository.Insert(customer);
    }

    private void ValidateEmail(string email)
    {
        var existEmailCustomer = _customerRepository.GetByEmail(email);

        if (!IsEmailValid(email))
        {
            throw new DuplicateEmailException(email);
        }

        if (existEmailCustomer is not null)
        {
            throw new DuplicateEmailException(email);
        };

    }

    private bool IsEmailValid(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;

        try
        {
            var emailAddres = new MailAddress(email);
            if (emailAddres.Address != email) return false;

            return CheckDomain(email);
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckDomain(string email)
    {
        var domain = email.Split("@")[1];
        var domainParts = domain.Split('.');
        if (domainParts.Length < 2)
            return false;
        return true;
    }

}
