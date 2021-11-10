using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Antra.Hotel.Data.Models;
using Dapper;


namespace Antra.Hotel.Data.Repository
{
    public class RTRepository : IRepository<Roomtypes>
    {
        CompanyDbContext db;
        public RTRepository()
        {
            db = new CompanyDbContext();
        }
        public int Delete(int id)
        {
            //throw new NotImplementedException();
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("DELETE FROM Roomtypes WHERE id=@rtid", new { rtid = id });
            }
        }

        public IEnumerable<Roomtypes> GetAll()
        {
            string query = "SELECT * FROM Roomtypes rt ";
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Query<Roomtypes>(query);
            }
        }

        public Roomtypes GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Roomtypes item)
        {
            //throw new NotImplementedException();
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("INSERT INTO Roomtypes VALUES (@RTDESC,@Rent)", item);
            }
        }

        public int Update(Roomtypes item)
        {
            //throw new NotImplementedException();
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("UPDATE Roomtypes SET RTDESC=@RTDESC,Rent=@Rent WHERE id=@Id)", item);
            }
        }
    }
}
