namespace OrderApi.Models;

public class Order
{
    public Guid Id { get; set; }

    public string CustomerName { get; set; } = "";

    public string ProductName { get; set; } = "";

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalAmount =>
        Quantity * UnitPrice;

    public DateTime CreatedDate { get; set; }
}