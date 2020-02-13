﻿namespace SulsApp.Controllers
{
    using System;
    using System.Linq;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using SulsApp.Services;
    using SulsApp.ViewModels.Submissions;

    public class SubmissionsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ApplicationDbContext db, ISubmissionsService submissionsService)
        {
            this.db = db;
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => new CreateFormViewModel
                {
                    Name = x.Name,
                    ProblemId = x.Id
                })
                .FirstOrDefault();

            if (problem == null)
            {
                return this.Error("Problem not found!");
            }

            return this.View(problem);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (code == null || code.Length < 30)
            {
                return this.Error("Please provide code with at least 30 characters.");
            }

            this.submissionsService.Create(this.User, problemId, code);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.Delete(id);

            return this.Redirect("/");
        }
    }
}

