namespace Ecommerce.Domain.Core.CustomExceptions;

public class DuplicateEmailException : Exception
{
    public DuplicateEmailException(string Email) : base($"Email {Email} is already in use.") { }

}
