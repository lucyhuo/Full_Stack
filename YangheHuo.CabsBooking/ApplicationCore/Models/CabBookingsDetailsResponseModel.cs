using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CabBookingsDetailsResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BookingsModel> Bookings { get; set; }
    }
}
