using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Antra.Hotel.Data.Models;
using Dapper;


namespace Antra.Hotel.Data.Repository
{

    public class CustomerRepository : IRepository<Customers>
    {
        CompanyDbContext db;
        public CustomerRepository()
        {
            db = new CompanyDbContext();
        }

        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("DELETE FROM Customers WHERE Id =@customerId", new { customerId = id });
            }

        }

        public IEnumerable<Customers> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Query<Customers>("SELECT * FROM Customers");
            }
        }
        public Customers GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.QueryFirstOrDefault<Customers>("SELECT * FROM Customer WHERE Id=@CustomerId", new { CustomerId = id });
            }
        }

        public int Insert(Customers item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("INSERT INTO Customers VALUES (@RoomNo,@CName,@Address,@Phone,@Email,@CheckIn,@TotalPersons,@BookingDays,@Money)", item);

            }
        }


        public int Update(Customers item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("UPDATE Customers SET (RoomNo=@RoomNo,CName=@CName,Address=@Address,Phone=@Phone,Email=@Email,CheckIn=@CheckIn,TotalPersons=@TotalPersons,BookingDays=@BookingDays,Money=@Money) WHERE id=@id", item);
            }
        }
    }
}
