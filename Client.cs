using System;

class Client
{
    static void Main(string[] args)
    {
        UserInterface user_interface = new UserInterface();

        user_interface.settings.load_saving();

        while (true)
        {
            Console.Clear();
            user_interface.Project();

            Console.WriteLine("Continue? : Yes or no ");
            string continue_ch = Console.ReadLine();
            if (continue_ch.ToLower() != "y")
            {
                break;
            }
        }
        Console.WriteLine("Exiting");
    }
}