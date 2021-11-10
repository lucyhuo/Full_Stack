using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Antra.Hotel.Data.Models;
using Dapper;

namespace Antra.Hotel.Data.Repository
{
    public class RoomsRepository : IRepository<Rooms>
    {
        CompanyDbContext db;
        public RoomsRepository()
        {
            db = new CompanyDbContext();

        }
        public int Delete(int id)
        {
            //throw new NotImplementedException();
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("DELETE FROM Rooms WHERE id=@rid", new { rtid = id });
            }
        }

        public IEnumerable<Rooms> GetAll()
        {
            string query = "SELECT * FROM Rooms r ";
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Query<Rooms>(query);
            }
        }

        public Rooms GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Rooms item)
        {
            //throw new NotImplementedException();
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("INSERT INTO Rooms VALUES (@RTCODE,@Status)", item);
            }
        }

        public int Update(Rooms item)
        {
            //throw new NotImplementedException();
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("UPDATE Rooms SET RTCODE=@RTCODE,Status=@Status WHERE id=@Id)", item);
            }
        }
    }
}
