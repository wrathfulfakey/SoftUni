using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class GetAllCarViewModel
    {
        public string Id { get; set; }

        public int Seats { get; set; }

        public string DepartureTime { get; set; }

        public string EndPoint { get; set; }

        public string StartPoint { get; set; }
    }
}
