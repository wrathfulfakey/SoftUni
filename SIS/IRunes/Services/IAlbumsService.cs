namespace IRunes.Services
{
    using IRunes.ViewModels.Albums;
    using System.Collections.Generic;

    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IEnumerable<AlbumInfoViewModel> GetAll();
    }
}
