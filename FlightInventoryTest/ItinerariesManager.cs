
namespace FlightInventoryTest
{
    class ItinerariesManager
    {
        public static string Flight_Itinerary(Order order)
        {
            return order.IsNotLoaded() ? $"order: {order.Code}, flightNumber: not scheduled"
                : $"order: {order.Code}, flightNumber: {order.Schedule.Flight_number}, departure: {order.Schedule.Departure_city}, arrival: {order.Schedule.Arrival_city}, day: {order.Schedule.Flight_Day}";
        }
    }
}
