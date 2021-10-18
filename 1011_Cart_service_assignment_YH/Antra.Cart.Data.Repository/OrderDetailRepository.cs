using System;
using System.Collections.Generic;
using System.Text;
using Antra.Cart.Data.Models;
using Dapper;
using System.Data;


namespace Antra.Cart.Data.Repository
{
    public class OrderDetailRepository : IRepository<OrderDetail>
    {
        DBContext db;
        public OrderDetailRepository()
        {
            db = new DBContext();
        }
        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute("delete from OrderDetails where OrderId = @orderid", new { orderid = id });
            }
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Query<OrderDetail>("Select OrderId,ProductId, Quantity, UnitPrice, HasDiscount from OrderDetails");
            }

        }

        public OrderDetail GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.QueryFirstOrDefault<OrderDetail>("Select OrderId,ProductId, Quantity, UnitPrice, HasDiscount from OrderDetails where OrderId = @orderid", new { orderid = id });
            }
        }

        public int Insert(OrderDetail item)
        {
            //throw new NotImplementedException();
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute(@"insert into OrderDetails values(@OrderId,@ProductId, 
                                                        @Quantity, @UnitPrice, @HasDiscount)", item);
            }
        }


        public int Update(OrderDetail item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Execute(@"update OrderDetails set OrderId = @OrderId,ProductId = @ProductId, Quantity = @Quantity, UnitPrice = @UnitPrice, HasDiscount = @Discount where OrderId = @OrderId", item);
            }
        }
    }
}
