using System;
using Newtonsoft.Json;
using System.IO;
using Statistics;

class Program
{
    public static void Main()
    {
        try
        {
            // Läs in nummer från data.json och lagra dem i en datamängd
            int[] data = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));

            // Anropa DescriptiveStatistics() metoden för att beräkna statistiska värden
            Console.WriteLine(Statistics.Statistics.DescriptiveStatistics(data));

            // Anropa Mode() metoden för att beräkna lägena
            int[] modes = Statistics.Statistics.Mode(data);

            // Skriv ut resultaten för lägena
            Console.WriteLine("Lägena är:");
            foreach (int mode in modes)
            {
                Console.WriteLine(mode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade: {ex.Message}");
        }

        Console.ReadKey();
    }
}
