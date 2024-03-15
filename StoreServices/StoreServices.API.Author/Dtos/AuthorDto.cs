using System;

namespace StoreServices.API.Author.Dtos
{
    public class AuthorDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? BornDate { get; set; }
        public Guid AuthorRepresentative { get; set; }
    }
}
