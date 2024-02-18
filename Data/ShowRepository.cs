using System.Text;
using System.Text.Json;
using Theater.Models;

namespace Theater.Data {

    public class ShowRepository : IShowRepository {
        private List<Show> Shows { get; }
        private readonly string _fileData = "shows_data.json";
        private int nextId = 1;

        public ShowRepository() {
            Shows = LoadFromJson();
        }


        private void SaveToJson() {
            try {
                var options = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
                string jsonString = JsonSerializer.Serialize(Shows, options);
                File.WriteAllText(_fileData, jsonString, Encoding.UTF8);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private List<Show> LoadFromJson() {
            try {
                if (File.Exists(_fileData)) {
                    var jsonString = File.ReadAllText(_fileData, Encoding.UTF8);
                    return JsonSerializer.Deserialize<List<Show>>(jsonString) ?? new List<Show>();
                }else {
                    return new List<Show>(); 
                }
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
                return new List<Show>();
            }
        }

        public List<Show> GetAllShows() => Shows;

        public Show? GetShowById(int showId) => Shows.FirstOrDefault(s => s.ShowId == showId);

        public void AddShow(Show show) {
            show.ShowId = nextId++;
            show.Seats = 135;
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