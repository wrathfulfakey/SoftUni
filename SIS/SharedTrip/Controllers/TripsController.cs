namespace SharedTrip.Controllers
{
    using SharedTrip.Models;
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Trips;

    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var allTrips = this.tripsService.GetAll();

            return this.View(allTrips);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Description.Length > 80)
            {
                return this.Redirect("/Trips/Add");
            }

            if (!input.ImagePath.StartsWith("https://"))
            {
                return this.Redirect("/Trips/Add");
            }

            this.tripsService.Add(input.StartPoint, input.EndPoint, input.DepartureTime, input.ImagePath, input.Seats, input.Description);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.tripsService.GetById(tripId);

            if (viewModel == null)
            {
                return this.Error("Trip not found.");
            }

            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.AddUserToTrip(this.User, tripId);

            if (trip == false)
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }

            return this.Redirect("All");
        }
    }
}
