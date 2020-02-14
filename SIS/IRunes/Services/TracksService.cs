using IRunes.Models;
using IRunes.ViewModels.Tracks;
using System.Linq;

namespace IRunes.Services
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string albumId, string name, string link, decimal price)
        {
            var track = new Track
            {
                AlbumId = albumId,
                Name = name,
                Link = link,
                Price = price
            };

            this.db.Tracks.Add(track);

            var allTrackPricesSum = this.db.Tracks
                .Where(t => t.AlbumId == albumId)
                .Sum(t => t.Price) + price;

            var album = this.db.Albums.Find(albumId);
            album.Price = allTrackPricesSum * 0.87M;

            this.db.SaveChanges();
        }

        public DetailsViewModel GetDetails(string id)
        {
            var track = this.db.Tracks
                .Where(x => x.Id == id)
                .Select(t => new DetailsViewModel 
                { 
                    Name = t.Name,
                    Link = t.Link,
                    AlbumId = t.AlbumId,
                    Price = t.Price
                }).FirstOrDefault();

            return track;
        }
    }
}
