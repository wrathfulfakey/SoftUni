namespace SharedTrip.Services
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;

    using SharedTrip.Models;
    using SIS.MvcFramework;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = this.Hash(password);

            var user = this.db.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public bool EmailExists(string email)
        {
            return this.db.Users.Any(u => u.Email == email);
        }

        public bool UsernameExists(string username)
        {
            return this.db.Users.Any(u => u.Username == username);
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Password = this.Hash(password),
                Email = email,
                Role = IdentityRole.User
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
