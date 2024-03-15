using System;

namespace StoreServices.API.Book.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishAt { get; set; }
        public Guid AuthorRepresentative { get; set; }
    }
}
