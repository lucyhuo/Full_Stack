using System;
using System.Collections.Generic;
using System.Text;
using Antra.Cart.Data.Repository;
using Antra.Cart.Data.Models;

namespace Antra.Cart.Services
{
    public class CartService
    {
        IRepository<Order> orderRepository;
        IRepository<OrderDetail> odRepository;

        public CartService()
        {
            orderRepository = new OrderRepository();
            odRepository = new OrderDetailRepository();
        }

        public int SendData(Order o)
        {
            int oid = orderRepository.Insert(o);

            if (oid == 0)
                return 0;


            OrderDetail od = new OrderDetail();
            od.OrderId = oid;
            if (o.AppleNo > 0)
            {
                od.ProductId = 1;
                od.Quantity = o.AppleNo;
                od.UnitPrice = 0.45M;
                odRepository.Insert(od);
            }
            if (o.OrangeNo > 0)
            {
                od.ProductId = 2;
                od.Quantity = o.OrangeNo;
                od.UnitPrice = 0.65M;
                odRepository.Insert(od);
            }
            return 1;
        }

        public decimal CalculateTotal(int appleNo, int orangeNo, bool discount)
        {
            if(discount)
            {
                return (appleNo / 2 + appleNo % 2) * 0.45M + orangeNo / 3 * 1.3M + (orangeNo % 3) * 0.65M;
            }
            return appleNo * 0.45M + orangeNo * 0.65M;
        }

    }
}
