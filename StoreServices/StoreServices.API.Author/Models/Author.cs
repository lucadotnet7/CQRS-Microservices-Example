using System;
using System.Collections.Generic;

namespace StoreServices.API.Author.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? BornDate { get; set; }
        public IEnumerable<AcademicState> AcademicStates { get; set; } = new List<AcademicState>();
        public Guid AuthorRepresentative { get; set; }
    }
}
