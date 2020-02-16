namespace SharedTrip.Services
{
    using System.Collections.Generic;

    using SharedTrip.Models;

    public interface ITripsService
    {
        IEnumerable<Trip> GetAll();

        void Add(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description);

        Trip GetById(string id);

        bool AddUserToTrip(string userId, string tripId);
    }
}
