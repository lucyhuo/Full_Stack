using System;
using System.Collections.Generic;
using System.Data;
using Antra.CompanyApp.Data.Model;
using System.Data.SqlClient;

namespace Antra.CompanyApp.Data.Repository
{
    public class DeptRepository : IRepository<Dept>
    {
        DbContext db;
        public DeptRepository()
        {
            db = new DbContext();
        }

        public IEnumerable<Dept> GetAll()
        {
            List<Dept> lstCollection = new List<Dept>();
            DataTable dt = db.Query("SELECT Id, DName,Loc FROM Dept", null);
            if(dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Dept d = new Dept();
                    d.Id = Convert.ToInt32(item["Id"]);
                    d.DName = Convert.ToString(item["DName"]);
                    d.Loc = Convert.ToString(item["Loc"]);
                    lstCollection.Add(d);
                }
            }
            return lstCollection;
        }

        public Dept GetById(int id)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@id", id);
            DataTable dt = db.Query("SELECT Id,DName,Loc FROM Dept WHERE id=@id", p);
            if(dt != null && dt.Rows.Count > 0)
            {
                Dept d = new Dept();
                DataRow dr = dt.Rows[0];
                d.Id = Convert.ToInt32(dr["Id"]);
                d.DName = Convert.ToString(dr["DName"]);
                d.Loc = Convert.ToString(dr["Loc"]);
                return d;
            }
            return null;
        }

        public int Delete(int id)
        {
            string cmd = "DELETE FROM Dept WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return db.Execute(cmd, parameters);
        }

        public int Insert(Dept item)
        {
            string cmd = "INSERT INTO Dept VALUES (@dname, @loc)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@dname", item.DName);
            parameters.Add("@loc", item.Loc);
            return db.Execute(cmd, parameters);
        }

        public int Update(Dept item)
        {
            string cmd = "UPDATE Dept SET dname = @dname, loc = @loc WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@dname", item.DName);
            parameters.Add("@loc", item.Loc);
            parameters.Add("@id", item.Id);
            return db.Execute(cmd, parameters);
        }
    }
}
