namespace IRunes.Services
{
    using System;
    using System.Collections.Generic;

    using IRunes.Models;
    using IRunes.ViewModels.Albums;

    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IEnumerable<T> GetAll<T>(Func<Album, T> selectFunc);

        AlbumDetailsViewModel GetDetails(string id);
    }
}
