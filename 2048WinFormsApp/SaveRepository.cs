using Newtonsoft.Json;

namespace _2048WinFormsApp
{
    public static class SaveRepository
    {
        private const string path = "Result.json";

        public static SaveData Load()
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<SaveData>(json);
            }

            return new SaveData();
        }

        public static void Save(SaveData data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
