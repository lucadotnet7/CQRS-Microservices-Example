using System;

namespace StoreServices.API.Cart.Dtos
{
    public class CartDetailDto
    {
        public int? BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthorName { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
