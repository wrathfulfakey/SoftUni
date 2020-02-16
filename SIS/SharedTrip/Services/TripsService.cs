namespace SharedTrip.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SharedTrip.Models;
    using System.Globalization;
    using SharedTrip.ViewModels.Trips;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;

        public TripsService(ApplicationDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public void Add(string startPoint, string endPoint, string departureTime, string carImage, int seats, string description)
        {
            var parsedDateTime = DateTime.ParseExact(departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            var trip = new Trip
            {
                Id = Guid.NewGuid().ToString(),
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = parsedDateTime,
                ImagePath = carImage,
                Seats = seats,
                Description = description
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId
            };

            if (this.db.UserTrips.FirstOrDefault(x => x.UserId == userId && x.TripId == tripId) != null)
            {
                return false;
            }

            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);

            trip.Seats--;
            if (trip.Seats < 0)
            {
                return false;
            }

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<Trip> GetAll()
           => this.db.Trips.Select(x => new Trip
           {
               Id = x.Id,
               StartPoint = x.StartPoint,
               EndPoint = x.EndPoint,
               DepartureTime = x.DepartureTime,
               Seats = x.Seats
           })
            .Where(x => x.Seats > 0)
           .ToArray();

        public Trip GetById(string id)
        {
            var trip = this.db.Trips.FirstOrDefault(t => t.Id == id);

            return trip;
        }
    }
}
