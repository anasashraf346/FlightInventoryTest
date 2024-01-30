namespace FlightInventoryTest
{
    class InventoryManager
    {
        public IList<Order>? Orders { get; set; }
        public IList<Flight> FlightsScheduled { get; set; }
        public IList<Schedule> Schedules { get; set; }

        public InventoryManager()
        {
            FlightsScheduled = new List<Flight>();
            Schedules = new ScheduleRepository().GetSchedules();
        }

        public void ProcessFlightScheduleMenuUserSelection(int userSelectedNumber)
        {
            if (userSelectedNumber > 0 && userSelectedNumber <= Schedules.Count)
            {
                var selectedSchedule = Schedules.FirstOrDefault(s => !s.IsFlightLoaded && s.Flight_number == userSelectedNumber);
                if (selectedSchedule != null)
                {
                    var scheduledFlight = new Flight(20, selectedSchedule);
                    FlightsScheduled.Add(scheduledFlight);
                    FlightsScheduled = FlightsScheduled.OrderBy(f => f.Schedule.Flight_number).ToList();
                    DisplayScheduleLoadedMessage(selectedSchedule);
                }
            }
        }

        public void DisplayScheduleLoadedMessage(Schedule schedule)
        {
            var menu = new Menu()
            {
                Items = new List<string>()
            {
                $"{ScheduleManager.LoadedMessage(schedule)}"
            }
            };

            new InformationManager().DisplayAndRead(menu);
        }

        public void DisplayLoadedSchedules()
        {
            var menu = new Menu()
            {
                Header = "\n************ Loaded schedules ************\n"
            };
            
            foreach (var flight in FlightsScheduled)
            {
                menu.Items.Add(flight.FlightSchedule());
            }
            if (FlightsScheduled.Count == 0)
            {
                Console.WriteLine("No Schedule Loaded Yet....!");
            }

            new InformationManager().DisplayAndRead(menu);
        }

        public void DisplayFlightItineraries()
        {
            LoadOrdersInFlights();

            var menu = new Menu()
            {
                Header = "\n************ Flight itineraries ************\n"
            };

            foreach (var order in Orders)
            {
                menu.Items.Add(ItinerariesManager.Flight_Itinerary(order));
            }

            new InformationManager().DisplayAndRead(menu);
        }

        private void LoadOrdersInFlights()
        {
            Orders = new OrderRepository().GetOrders().OrderBy(o => o.Priority).ToList();

            foreach (var schedule in Schedules)
            {
                if (schedule.IsFlightLoaded)
                {
                    var loadedFlights = FlightsScheduled.Where(f => f.Schedule == schedule).ToList();

                    foreach (var flight in loadedFlights)
                    {
                        var flightOrders = Orders.Where(o => o.IsNotLoaded() && o.Destination == schedule.Arrival_city).Take(flight.Capacity).Select(o => { o.Schedule = schedule; return o; }).ToList();
                        flight.Orders = flightOrders;
                    }
                }
            }
        }

        public Menu GetFlightScheduleMenu()
        {
            var menu = new Menu
            {
                Header = "Choose a schedule to load"
            };

            foreach (var item in Schedules)
            {
                if (!item.IsFlightLoaded)
                {
                    menu.Items.Add(item.ToString());
                }
            }

            menu.ExitValue = Schedules.Count + 1;
            menu.Items.Add($"{menu.ExitValue}. Main menu");

            return menu;
        }
    }
}
