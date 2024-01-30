namespace FlightInventoryTest
{
    interface IOrderRepository
    {
        IList<Order> GetOrders();
    }
}
