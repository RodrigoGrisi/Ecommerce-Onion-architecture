using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Model;

public class Delivery
{
    public int id { get; set; }
    public string RecipientName { get; set; } = string.Empty;
    public string RecipientLastName { get; set; } = string.Empty;
    public string? RecipientEmail { get; set; }
    public Address DeliveryAddress { get; set; } = new Address();
    public DateTime DeliveryDate { get; set; }
    public string? TrackingNumber { get; set; }
    public OrderStatusEnum OrderStatus { get; set; }


    public DateTime CreatedDate { get; set; }
}
