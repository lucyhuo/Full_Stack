using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.CompanyApp.Data.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
