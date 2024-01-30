namespace FlightInventoryTest
{
    class MenuManager
    {
        public virtual int DisplayAndRead(Menu menu)
        {
            Console.Clear();
            Console.WriteLine("************** {0} **************\n", menu.Header);

            foreach (var item in menu.Items)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nPlease enter your selection here: ");

            int userInput;
            int.TryParse(Console.ReadLine(), out userInput);

            return userInput;
        }
    }
}
