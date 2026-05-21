using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private readonly List<Entry> entries = new();

    public void AddEntry(Entry entry) => entries.Add(entry);

    public void DisplayAll()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        Console.WriteLine("\nJournal Entries:");
        Console.WriteLine(new string('-', 40));
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine(new string('-', 40));
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
            Console.WriteLine($"Journal saved to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to save journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File not found: {filename}");
                return;
            }

            string json = File.ReadAllText(filename);
            List<Entry>? loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json);
            if (loadedEntries == null)
            {
                Console.WriteLine("No entries were loaded from the file.");
                return;
            }

            entries.Clear();
            entries.AddRange(loadedEntries);
            Console.WriteLine($"Journal loaded from '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load journal: {ex.Message}");
        }
    }
}
