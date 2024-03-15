using System;

namespace StoreServices.API.Cart.Models
{
    public class CartSessionDetail
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int SelectedProduct { get; set; }
        public int CartSessionId { get; set; }
        public CartSession CartSession { get; set; }
    }
}
