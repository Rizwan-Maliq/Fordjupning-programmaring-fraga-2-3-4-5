using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Skapa en lista med några ord för teständamål
        List<string> elements = new List<string> { "Apple", "Ant", "Banana", "Cat", "Dog", "Elephant" };

        // Anropa metoden för att spara listan med element som börjar med varje bokstav i alfabetet i separata filer
        SaveElementsToDirectories(elements);
    }

    /// <summary>
    /// Skapar kataloger för varje unik bokstav i listan och sparar listor med element som börjar med respektive bokstav i motsvarande filer.
    /// </summary>
    /// <param name="elements">Listan med element att filtrera och spara</param>
    static void SaveElementsToDirectories(List<string> elements)
    {
        // Loopa igenom varje unik bokstav (första bokstav i varje element) i listan
        foreach (char startingLetter in elements.Select(e => e.ToLower()[0]).Distinct())
        {
            // Filtrera element som börjar med den aktuella bokstaven och sortera dem
            List<string> filteredElements = elements
                .Where(e => char.ToLower(e[0]) == startingLetter)
                .OrderBy(e => e)
                .ToList();

            // Skapa katalogen för den specifika bokstaven (görs i stora bokstäver för tydlighet)
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), startingLetter.ToString().ToUpper());
            Directory.CreateDirectory(directoryPath);

            // Skapa filen och spara de filtrerade elementen
            string filePath = Path.Combine(directoryPath, $"{startingLetter}_elements.txt");
            File.WriteAllLines(filePath, filteredElements);

            // Skriv ut meddelande till konsolen för att bekräfta att processen är klar
            Console.WriteLine($"Lista med element som börjar med bokstaven '{startingLetter}' har sparats i filen: {filePath}");
        }
    }
}
