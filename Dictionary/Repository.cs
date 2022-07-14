using System.Text.Json;

namespace Dictionary
{
    public class Repository : IRepository
    {
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json");

        public Dictionary<string, string> Load(Dictionary<string, string> dictionary)
        {
            if (!File.Exists(path))
                Save(dictionary);

            var content = File.ReadAllText(path);

            return JsonSerializer.Deserialize<Dictionary<string, string>>(content)!;
        }

        public void Save(Dictionary<string, string> dictionary)
        {
            var content = JsonSerializer.Serialize(dictionary);

            File.WriteAllText(path, content);
        }
    }
}
