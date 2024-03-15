using System;
using System.Collections.Generic;

namespace StoreServices.API.Cart.Dtos
{
    public class CartDto
    {
        public int CartId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<CartDetailDto> Details { get; set; } = new List<CartDetailDto>();
    }
}
