using Theater.Models;
using Theater.Data;

namespace Theater.Business {
    
    public class ShowService : IShowService {
        private readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository) {
            _showRepository = showRepository;
        } 

        public List<Show> GetAllShows() => _showRepository.GetAllShows();

        public Show? GetShowById(int showId) => _showRepository.GetShowById(showId);

        public void AddShow(Show show) => _showRepository.AddShow(show);

        public void DeleteShow(int showId) => _showRepository.DeleteShow(showId);

        public void UpdateShow(Show show) => _showRepository.UpdateShow(show);

    }

}