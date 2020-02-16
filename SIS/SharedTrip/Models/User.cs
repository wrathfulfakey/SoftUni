namespace SharedTrip.Models
{
    using SIS.MvcFramework;
    using System.Collections.Generic;

    public class User : IdentityUser<string>
    {
        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
