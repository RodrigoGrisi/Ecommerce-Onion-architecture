namespace Ecommerce.Domain.Model;

public class Customer
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty ;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    
    public  Address Address { get; set; }

    public string Cpf {  get; set; }
    public bool isActive { get; set; }

}
