namespace FlightInventoryTest
{
     class Schedule
    {
        public int? Flight_number { get; set; }
        public string? Departure_city { get; set; }
        public string? Arrival_city { get; set; }
        public int Flight_Day { get; set; }
        public bool IsFlightLoaded { get; set; }

        public override string ToString()
        {
            return $"{Flight_number}. Flight:{Flight_number}, Departure: {Departure_city},  Arrival: {Arrival_city}, Day: {Flight_Day}";
        }

    }
}
