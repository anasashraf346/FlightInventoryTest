namespace FlightInventoryTest
{
    class ScheduleRepository:IScheduleRepository
    {
        public IList<Schedule> GetSchedules()
        {
            var flightNumber = 1;
            var day = 1;
            var schedules = new List<Schedule>();

            schedules.Add(new Schedule { Flight_number = flightNumber++, Departure_city = "YUL", Arrival_city = "YYZ", Flight_Day = day, IsFlightLoaded = false });
            schedules.Add(new Schedule { Flight_number = flightNumber++, Departure_city = "YUL", Arrival_city = "YYC", Flight_Day = day, IsFlightLoaded = false });
            schedules.Add(new Schedule { Flight_number = flightNumber++, Departure_city = "YUL", Arrival_city = "YVR", Flight_Day = day, IsFlightLoaded = false });

            day++;
            schedules.Add(new Schedule { Flight_number = flightNumber++, Departure_city = "YUL", Arrival_city = "YYZ", Flight_Day = day, IsFlightLoaded = false });
            schedules.Add(new Schedule { Flight_number = flightNumber++, Departure_city = "YUL", Arrival_city = "YYC", Flight_Day = day, IsFlightLoaded = false });
            schedules.Add(new Schedule { Flight_number = flightNumber++, Departure_city = "YUL", Arrival_city = "YVR", Flight_Day = day, IsFlightLoaded = false });

            return schedules;
        }
    }
}
