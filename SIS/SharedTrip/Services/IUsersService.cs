namespace SharedTrip.Services
{
    public interface IUsersService
    {
        void Register(string username, string email, string password);

        bool EmailExists(string email);

        bool UsernameExists(string username);

        string GetUserId(string username, string password);
    }
}
