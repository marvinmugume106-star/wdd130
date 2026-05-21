using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        while (true)
        {
            ShowMenu();
            string choice = ReadInput("Choose an option: ");

            if (choice == "1")
            {
                string prompt = generator.GetRandomPrompt();
                Console.WriteLine();
                Console.WriteLine(prompt);
                string response = ReadInput("Your response: ");

                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Entry cannot be empty.");
                }
                else
                {
                    string date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(date, prompt, response));
                    Console.WriteLine("Entry saved.");
                }
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                string filename = GetFilename();
                if (!string.IsNullOrEmpty(filename)) journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                string filename = GetFilename();
                if (!string.IsNullOrEmpty(filename)) journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again.");
            }

            Console.WriteLine();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Journal Menu:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display journal");
        Console.WriteLine("3. Save journal to file");
        Console.WriteLine("4. Load journal from file");
        Console.WriteLine("5. Quit");
    }

    static string ReadInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }

    static string GetFilename()
    {
        string filename = ReadInput("Enter filename: ").Trim();
        if (string.IsNullOrEmpty(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return string.Empty;
        }

        if (!Path.HasExtension(filename))
        {
            filename += ".json";
        }

        return filename;
    }
}
