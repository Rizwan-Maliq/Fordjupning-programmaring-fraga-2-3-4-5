using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public static class Statistics
    {
        // Array för att lagra data från data.json
        private static int[] data;

        // Statisk konstruktor för att initialisera data från data.json
        static Statistics()
        {
            try
            {
                // Försök läsa data från data.json och deserialisera till int[]
                data = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));
            }
            catch (Exception ex)
            {
                // Felhantering om det uppstår ett fel vid läsning eller deserialisering
                Console.WriteLine($"Fel vid inläsning av data: {ex.Message}");
                data = new int[0]; // Skapa en tom array om något går fel
            }
        }

        /// <summary>
        /// Beräknar och returnerar en dynamisk lista med deskriptiva statistiska värden.
        /// </summary>
        /// <returns>En dynamisk lista med deskriptiva statistiska värden.</returns>
        public static dynamic DescriptiveStatistics()
        {
            // Skapar en dictionary för att lagra de deskriptiva statistiska värdena
            Dictionary<string, dynamic> statisticsList = new Dictionary<string, dynamic>()
            {
                { "Maximum", Maximum() },
                { "Minimum", Minimum() },
                { "Medelvärde", Mean() },
                { "Median", Median() },
                { "Typvärde", Mode() },
                { "Variationsbredd", Range() },
                { "Standardavvikelse", StandardDeviation() }
            };

            // Skapar en sträng med de deskriptiva statistiska värdena
            string output =
                $"Maximum: {statisticsList["Maximum"]}\n" +
                $"Minimum: {statisticsList["Minimum"]}\n" +
                $"Medelvärde: {statisticsList["Medelvärde"]}\n" +
                $"Median: {statisticsList["Median"]}\n" +
                $"Typvärde: {string.Join(", ", statisticsList["Typvärde"])}\n" +
                $"Variationsbredd: {statisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {statisticsList["Standardavvikelse"]}";

            // Returnerar de deskriptiva statistiska värdena som en sträng
            return output;
        }

        /// <summary>
        /// Beräknar och returnerar det högsta värdet i data-arrayen.
        /// </summary>
        /// <returns>Det högsta värdet.</returns>
        public static int Maximum()
        {
            if (data.Length == 0) return 0; // Felhantering om data är tom
            return data.Max();
        }

        /// <summary>
        /// Beräknar och returnerar det lägsta värdet i data-arrayen.
        /// </summary>
        /// <returns>Det lägsta värdet.</returns>
        public static int Minimum()
        {
            if (data.Length == 0) return 0; // Felhantering om data är tom
            return data.Min();
        }

        /// <summary>
        /// Beräknar och returnerar medelvärdet av alla värden i data-arrayen.
        /// </summary>
        /// <returns>Medelvärdet.</returns>
        public static double Mean()
        {
            if (data.Length == 0) return 0; // Felhantering om data är tom
            return data.Average();
        }

        /// <summary>
        /// Beräknar och returnerar medianen av alla värden i data-arrayen.
        /// </summary>
        /// <returns>Medianen.</returns>
        public static double Median()
        {
            if (data.Length == 0) return 0; // Felhantering om data är tom
            int size = data.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)data[mid] : (data[mid - 1] + data[mid]) / 2.0;
            return median;
        }

        /// <summary>
        /// Beräknar och returnerar lägena (de värden som förekommer oftast) i data-arrayen.
        /// </summary>
        /// <returns>En array med lägena.</returns>
        public static int[] Mode()
        {
            if (data.Length == 0) return new int[0]; // Felhantering om data är tom

            // Skapar en dictionary för att lagra antalet förekomster av varje värde i data-arrayen
            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            // Loopar igenom data-arrayen och räknar antalet förekomster av varje värde
            foreach (int num in data)
            {
                if (numberCounts.ContainsKey(num))
                {
                    numberCounts[num]++;
                }
                else
                {
                    numberCounts[num] = 1;
                }
            }

            // Hittar lägena (värden med högst förekomst)
            int maxCount = numberCounts.Values.Max();
            int[] modes = numberCounts.Where(kv => kv.Value == maxCount).Select(kv => kv.Key).ToArray();
            return modes;
        }

        /// <summary>
        /// Beräknar och returnerar variationsbredden av alla värden i data-arrayen.
        /// </summary>
        /// <returns>Variationsbredden.</returns>
        public static int Range()
        {
            if (data.Length == 0) return 0; // Felhantering om data är tom
            return data.Max() - data.Min();
        }

        /// <summary>
        /// Beräknar och returnerar standardavvikelsen av alla värden i data-arrayen.
        /// </summary>
        /// <returns>Standardavvikelsen.</returns>
        public static double StandardDeviation()
        {
            if (data.Length == 0) return 0; // Felhantering om data är tom
            double average = data.Average();
            double sumOfSquaresOfDifferences = data.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / data.Length);
            return sd;
        }
    }
}
