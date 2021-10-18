using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.Cart.Data.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool HasDiscount { get; set; }


    }
}
