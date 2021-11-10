using System;
using System.Collections.Generic;
using System.Data;
using Antra.CompanyApp.Data.Model;

namespace Antra.CompanyApp.Data.Repository
{
    public class CustomerRepository : IRepository<Customer>

    {
        DbContext db;

        public CustomerRepository()
        {
            db = new DbContext();
        }

        public int Delete(int id)
        {
            string cmd = "DELETE FROM Customer WHERE Id=@id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@id", id);
            return db.Execute(cmd, p);
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> lstCollection = new List<Customer>();
            DataTable dt = db.Query("SELECT Id, FullName,Mobile,Email,City,Country FROM Customer", null);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Customer c = new Customer();
                    c.Id = Convert.ToInt32(item["Id"]);
                    c.FullName = Convert.ToString(item["FullName"]);
                    c.Mobile = Convert.ToString(item["Mobile"]);
                    c.Email = Convert.ToString(item["Email"]);
                    c.City = Convert.ToString(item["City"]);
                    c.Country = Convert.ToString(item["Country"]);
                    lstCollection.Add(c);
                }
            }
            return lstCollection;
        }

        public Customer GetById(int id)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@id", id);
            DataTable dt = db.Query("SELECT Id, FullName,Mobile,Email,City,Country FROM Customer", p);
            if (dt != null && dt.Rows.Count > 0)
            {
                Customer c = new Customer();
                DataRow dr = dt.Rows[0];
                c.Id = Convert.ToInt32(dr["Id"]);
                c.FullName = Convert.ToString(dr["FullName"]);
                c.Mobile = Convert.ToString(dr["Mobile"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.City = Convert.ToString(dr["City"]);
                c.Country = Convert.ToString(dr["Country"]);
                return c;
            }
            return null;
        }

        public int Insert(Customer item)
        {
            string cmd = "INSERT INTO Customer VALUES (@FullName, @Mobile, @Email, @City, @Country) ";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@FullName", item.FullName);
            p.Add("@Mobile", item.Mobile);
            p.Add("@Email", item.Email);
            p.Add("@City", item.City);
            p.Add("@Country", item.Country);
            return db.Execute(cmd, p);
        }

        public int Update(Customer item)
        {
            string cmd = @"UPDATE Customer SET FullName=@FullName, 
                                Mobile=@Mobile, Email=@Email, City=@City, Country=@Country 
                                WHERE Id = @id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@FullName", item.FullName);
            p.Add("@Mobile", item.Mobile);
            p.Add("@Email", item.Email);
            p.Add("@City", item.City);
            p.Add("@Country", item.Country);
            return db.Execute(cmd, p);
        }
    }
}
