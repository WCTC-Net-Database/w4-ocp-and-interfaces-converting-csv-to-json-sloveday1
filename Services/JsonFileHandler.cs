using System.Text.Json;
using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;

namespace W4_assignment_template.Services;

public class JsonFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath)
    {
        // TODO: Implement JSON reading logic
        
        var json = File.ReadAllText(filePath);
        var characters = JsonConvert.DeserializeObject<List<Character>>(json);

        return characters;
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        // TODO: Implement JSON writing logic
        string json = JsonConvert.SerializeObject(characters);
        File.WriteAllText(filePath, json);
    }
}
