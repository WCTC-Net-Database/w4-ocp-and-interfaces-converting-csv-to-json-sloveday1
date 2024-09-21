namespace W4_assignment_template.Services;

public class CsvFileHandler : IFileHandler
{
    
    public List<Character> ReadCharacters(string filePath)
    {
        // TODO: Implement CSV reading logic
        List<Character> characters = new List<Character>();
        string[] lines = File.ReadAllLines(filePath);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string name;
            int commaIndex = line.IndexOf(",");

            if (line.StartsWith("\""))
            {
                var firstQuote = line.IndexOf("\"");
                line = line.Substring(firstQuote + 1);
                var lastQuote = line.IndexOf("\"");
                commaIndex = line.IndexOf(",", lastQuote);
                name = line.Substring(0, commaIndex - 1);
            }
            else
            {
                name = line.Substring(0, commaIndex);
            }

            string[] fields = line.Split(',');
            string characterClass = fields[fields.Length - 4];
            int level = Convert.ToInt32(fields[fields.Length - 3]);
            int hitPoints = Convert.ToInt32(fields[fields.Length - 2]);

            List<string> equipment = new List<string>(fields[fields.Length - 1].Split("|"));

            Character character = new Character()
                { Name = name, Class = characterClass, Level = level, HP = hitPoints, Equipment = equipment };
            
            characters.Add(character);
        }

        return characters;
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        // TODO: Implement CSV writing logic
        string[] lines = new string[characters.Count];

        foreach (var character in characters)
        {
            for (int i = 1; i < characters.Count; i++)
            {
                string line =
                    $"{character.Name},{character.Class},{character.Level},{character.HP},{character.Equipment}";
                lines[i] = line;
            }
        }

        File.WriteAllLines(filePath, lines);
    }
}
