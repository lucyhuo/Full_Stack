using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.Hotel.Data.Models
{
    public class Customers
    {
        // Id int primary key identity, RoomNo int , CName varchar(20), Address varchar(100), 
        // Phone varchar(20), Email varchar(40), CheckIn datetime, TotalPersons int, BookingDays int, Advance money
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public string CName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public int TotalPersons { get; set; }
        public int BookingDays { get; set; }
        public double Money { get; set; }
    }
}
