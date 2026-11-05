using OrderApi.Models;

namespace OrderApi.Repositories;

public static class OrderRepository
{
    private static readonly List<Order> Orders = new();

    public static List<Order> GetAll()
    {
        return Orders;
    }

    public static Order? Get(Guid id)
    {
        return Orders.FirstOrDefault(x => x.Id == id);
    }

    public static Order Add(Order order)
    {
        Orders.Add(order);
        return order;
    }

    public static bool Delete(Guid id)
    {
        var order = Get(id);

        if (order == null)
            return false;

        Orders.Remove(order);
        return true;
    }
}