using System;
using System.IO;

class App
{
    private ConsoleColor background_color = ConsoleColor.Yellow;
    private ConsoleColor text_color = ConsoleColor.Red;
    private string window_title = "Application";
    private int window_width = 90;
    private int window_height = 30;

    public ConsoleColor background
    {
        get { return background_color; }
        set { background_color = value; }
    }

    public ConsoleColor text
    {
        get { return text_color; }
        set { text_color = value; }
    }

    public string title
    {
        get { return window_title; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                window_title = value;
            else
                Console.WriteLine("The window title cannot be empty");
        }
    }

    public int width
    {
        get { return window_width; }
        set
        {
            if (value > 0)
                window_width = value;
            else
                Console.WriteLine("Window width > 0 ");
        }
    }

    public int height
    {
        get { return window_height; }
        set
        {
            if (value > 0)
                window_height = value;
            else
                Console.WriteLine("Window height > 0 ");
        }
    }

    private string settings_file = "app.dat";

    public void save()
    {
        try
        {
            FileStream file = new FileStream(settings_file, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            writer.Write((int)background_color);
            writer.Write((int)text_color);
            writer.Write(window_title);
            writer.Write(window_width);
            writer.Write(window_height);

            writer.Close();
            file.Close();

            Console.WriteLine("Saved to file!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error saving: " + e.Message);
        }
    }
    public void load_saving()
    {
        try
        {
            if (File.Exists(settings_file))
            {
                FileStream file = new FileStream(settings_file, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(file);

                background_color = (ConsoleColor)reader.ReadInt32();
                text_color = (ConsoleColor)reader.ReadInt32();
                window_title = reader.ReadString();
                window_width = reader.ReadInt32();
                window_height = reader.ReadInt32();

                reader.Close();
                file.Close();

                Console.WriteLine("Saving loaded from file!");
            }
            else
            {
                Console.WriteLine("Saving not found");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error loading: " + e.Message);
        }
    }
}