﻿namespace Ecommerce.Domain.Model;

public class Address
{
    public string? Street { get; set; }
    public int AddressNumber { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PostalCode { get; set; }


    public bool isActive { get; set; }
    public DateTime? Created { get; set; }

}