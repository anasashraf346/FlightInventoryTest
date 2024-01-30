namespace FlightInventoryTest
{
    class Flight
    {
        public int Capacity { get; set; }
        public Schedule Schedule { get; set; }
        public IList<Order> Orders { get; set; }

        public Flight(int capacity, Schedule schedule)
        {
            Capacity = capacity;
            schedule.IsFlightLoaded = true;
            Schedule = schedule;
            Orders = new List<Order>();
        }

        public string FlightSchedule()
        {
            return $"Flight: {Schedule.Flight_number}, departure: {Schedule.Departure_city}, arrival: {Schedule.Arrival_city}, day: {Schedule.Flight_Day}";
        }
    }
}
