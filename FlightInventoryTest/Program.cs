using FlightInventoryTest;
class Program
{
    static void Main(string[] args)
    {
        var inventory = new InventoryManager();

        ReadUserSelection(inventory);
    }

    private static void ReadUserSelection(InventoryManager inventory)
    {
        int userSelectedNumber;
        Menu menu = GetMainMenu();

        do
        {
            userSelectedNumber = new MenuManager().DisplayAndRead(menu);
            ProcessUserSelection(userSelectedNumber, inventory);
        } while (userSelectedNumber != menu.ExitValue);
    }

    private static void ProcessUserSelection(int userSelectedNumber, InventoryManager inventory)
    {
        switch (userSelectedNumber)
        {
            case 1:
                ReadFlightScheduleMenuUserSelection(inventory);
                break;
            case 2:
                inventory.DisplayLoadedSchedules();
                break;
            case 3:
                inventory.DisplayFlightItineraries();
                break;
            case 4:
                Environment.Exit(0);
                break;
        }
    }


    private static void ReadFlightScheduleMenuUserSelection(InventoryManager inventory)
    {
        int userEnteredNumber;
        Menu menu;

        do
        {
            menu = inventory.GetFlightScheduleMenu();
            userEnteredNumber = new MenuManager().DisplayAndRead(menu);
            inventory.ProcessFlightScheduleMenuUserSelection(userEnteredNumber);
        } while (userEnteredNumber != menu.ExitValue);
    }

    private static Menu GetMainMenu()
    {
        var menu = new Menu
        {
            Header = "SpeedyAir.ly",
            Items = new List<string>()
            {
                "1. Display flight schedule  (from UseCase # 1)",
                "2. Display loaded flight schedules (from UseCase # 2)",
                "3. Generate flight itineraries (from UseCase # 2)",
            }
        };

        menu.ExitValue = menu.Items.Count + 1;
        menu.Items.Add($"{menu.ExitValue}. Exit");

        return menu;
    }
}