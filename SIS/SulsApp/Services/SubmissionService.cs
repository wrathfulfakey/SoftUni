namespace SulsApp.Services
{
    using System;
    using System.Linq;

    using SulsApp.Models;

    public class SubmissionService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string userId, string problemId, string code)
        {
            var problem = this.db.Problems
                .FirstOrDefault(x => x.Id == problemId);

            var submission = new Submission
            {
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
                ProblemId = problemId,
                Code = code,
                AchievedResult = random.Next(0, problem.Points + 1)
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.Find(id);

            this.db.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
