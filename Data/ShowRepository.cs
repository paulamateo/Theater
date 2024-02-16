using System.Dynamic;
using System.Text.Json;
using Theater.Models;

namespace Theater.Data {

    public class ShowRepository {
        private readonly string _fileData = "shows_data.json";
        private int nextId = 0;
        private List<Show> Shows { get; }

        private SaveToJson() {
            try {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(options);
                File.WriteAllText(_fileData, jsonString);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private List<Show> LoadFromJson() {
            if (File.Exists(_fileData)) {
                var jsonString = File.ReadAllText(_fileData);
                return JsonSerializer.Deserialize<List<Show>>(jsonString) ?? new List<Show>();
            }else {
                return new List<Show>(); 
            }
        }

        public List<Show> GetAllShows() => LoadFromJson();
        public Show? GetShowById() => ;

        public void AddShow(Show show) {
            show.ShowId = nextId++;
            Shows.Add(show);
            SaveToJson();
        }

        public void DeleteShow(int showId) {
            var show = GetShowById(showId);
            if (show is null)
                return;
            Shows.Remove(show);
            SaveToJson();
        }

        public void UpdateShow(Show show) {
            var index = Shows.FindIndex(s => s.ShowId == show.ShowId);
            if (index == -1)
                return;
            Shows[index] = show;
            SaveToJson();
        }

    }

}