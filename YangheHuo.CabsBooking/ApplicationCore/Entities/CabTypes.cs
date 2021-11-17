using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class CabTypes
    {
        public int CabTypeId { get; set; }
        public string? CabTypeName { get; set; }

        // nav
        public ICollection<Bookings> Bookings { get; set; }
        public ICollection<BookingsHistories> BookingsHistories { get; set; }
    }
}
