using Newtonsoft.Json;

namespace FlightInventoryTest
{
    class OrderRepository:IOrderRepository
    {
        public IList<Order> GetOrders()
        {
            //You have to change the file path where ever this file 'coding-assigment-orders.json' exist in your case
            var jsonString = FileReader.ReadAllText(@"C:\\Users\\User\\source\\repos\\FlightInventoryTest\\FlightInventoryTest\\coding-assigment-orders.json");

            var orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(jsonString).Select(p =>
            new Order { Code = p.Key, Destination = p.Value.Destination, Priority = int.Parse(p.Key.Substring(p.Key.LastIndexOf('-') + 1)) }).ToList();

            return orders;
        }
    }
}
