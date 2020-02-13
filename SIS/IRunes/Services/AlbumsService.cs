using IRunes.Models;
using IRunes.ViewModels.Albums;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0M
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public IEnumerable<AlbumInfoViewModel> GetAll()
        {
            var allAlbums = this.db.Albums.Select(a => new AlbumInfoViewModel
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();

            return allAlbums;
        }
    }
}
