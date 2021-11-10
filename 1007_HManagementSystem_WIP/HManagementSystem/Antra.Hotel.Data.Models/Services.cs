using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.Hotel.Data.Models
{
    public class Services
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public string SDESC { get; set; }
        public double Money { get; set; }
        public DateTime ServiceDate { get; set; }
        public Rooms Room { get; set; }
    }
}
