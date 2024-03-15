using System;

namespace StoreServices.API.Cart.Models.Remote
{
    public class BookRemote
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishAt { get; set; }
        public Guid AuthorRepresentative { get; set; }
    }
}
