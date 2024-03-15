using System;
using System.Collections;
using System.Collections.Generic;

namespace StoreServices.API.Cart.Models
{
    public class CartSession
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ICollection<CartSessionDetail> Details { get; set; } = new List<CartSessionDetail>();
    }
}
