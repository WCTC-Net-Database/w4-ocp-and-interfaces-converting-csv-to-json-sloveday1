using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;
using W4_assignment_template.Services;

namespace W4_assignment_template;

class Program
{
    static IFileHandler fileHandler;
    static List<Character> characters;

    static void Main()
    {
        string filePath = "Files/input.csv"; // Default to CSV file
        fileHandler = new CsvFileHandler(); // Default to CSV handler
        characters = fileHandler.ReadCharacters(filePath);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllCharacters();
                    break;
                case "2":
                    AddCharacter();
                    break;
                case "3":
                    LevelUpCharacter();
                    break;
                case "4":
                    fileHandler.WriteCharacters(filePath, characters);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayAllCharacters()
    {
        foreach (var character in characters)
        {
            Console.WriteLine($"Name: {character.Name}, Class: {character.Class}, Level: {character.Level}, HP: {character.HP}, Equipment: {string.Join(", ", character.Equipment)}");
        }
    }

    static void AddCharacter()
    {
        // TODO: Implement logic to add a new character
        // Prompt for character details (name, class, level, hit points, equipment)
        // Add the new character to the characters list
        
        Console.WriteLine("What is the characters name:");
        string name = Console.ReadLine();
        Console.WriteLine("What is the characters class:");
        string characterClass = Console.ReadLine();
        Console.WriteLine("What is the characters level:");
        int level = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("What is the characters hit points:");
        int hitPoints = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Equipment 1:");
        string equipment1 = Console.ReadLine();
        Console.WriteLine("Equipment 2:");
        string equipment2 = Console.ReadLine();
        Console.WriteLine("Equipment 3:");
        string equipment3 = Console.ReadLine();

        List<string> equipment = new List<string>(){equipment1, equipment2, equipment3};
        
        Character character = new Character()
            { Name = name, Class = characterClass, Level = level, HP = hitPoints, Equipment = equipment };
            
        characters.Add(character);
    }

    static void LevelUpCharacter()
    {
        Console.Write("Enter the name of the character to level up: ");
        string nameToLevelUp = Console.ReadLine();

        var character = characters.Find(c => c.Name.Equals(nameToLevelUp, StringComparison.OrdinalIgnoreCase));
        if (character != null)
        {
            // TODO: Implement logic to level up the character
            character.Level++;
            Console.WriteLine($"Character {character.Name} leveled up to level {character.Level}!");
        }
        else
        {
            Console.WriteLine("Character not found.");
        }
    }
}
