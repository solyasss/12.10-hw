using System;

class UserInterface
{
    public App settings = new App();

    public void Project()
    {
        Console.WriteLine("1 - Change background color");
        Console.WriteLine("2 - Change text color");
        Console.WriteLine("3 - Change window title");
        Console.WriteLine("4 - Change window size");
        Console.WriteLine("5 - Save");
        Console.WriteLine("6 - Exit");

        string user_choice = Console.ReadLine();

        switch (user_choice)
        {
            case "1":
                change_back_color();
                break;
            case "2":
                change_text_color();
                break;
            case "3":
                change_window_title();
                break;
            case "4":
                change_window_size();
                break;
            case "5":
                settings.save();
                break;
            case "6":
                return;
        }

        apply();
    }

    private void change_back_color()
    {
        Console.WriteLine("Enter background color: ");
        settings.background = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine(), true);
    }

    private void change_text_color()
    {
        Console.WriteLine("Enter text color: ");
        settings.text = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine(), true);
    }

    private void change_window_title()
    {
        Console.WriteLine("Enter window title: ");
        settings.title = Console.ReadLine();
    }

    private void change_window_size()
    {
        Console.WriteLine("Enter window width: ");
        settings.width = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter window height: ");
        settings.height = int.Parse(Console.ReadLine());
    }

    private void apply()
    {
        Console.BackgroundColor = settings.background;
        Console.ForegroundColor = settings.text;
        Console.Title = settings.title;
        Console.SetWindowSize(settings.width, settings.height);
        Console.Clear();
    }
}