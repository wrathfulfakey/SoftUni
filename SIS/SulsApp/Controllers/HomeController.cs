namespace SulsApp.Controllers
{
    using System;
    using System.Linq;
    using SIS.HTTP;
    using SIS.HTTP.Logging;
    using SIS.MvcFramework;
    using SulsApp.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly ILogger logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger logger, ApplicationDbContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var problems = db.Problems.Select(p => new IndexProblemViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Count = p.Submissions.Count()
                })
                .ToList();

                var loggedInViewModel = new LoggedInViewModel()
                {
                    Problems = problems
                };

                return this.View(loggedInViewModel, "IndexLoggedIn");
            }

            var request = this.Request;
            this.logger.Log("Hello from Index");
            var viewModel = new IndexViewModel()
            {
                Message = "Welcome to SULS Platform!",
                Year = DateTime.UtcNow.Year
            };

            return this.View(viewModel);
        }
    }
}
