using System;

namespace StoreServices.API.Author.Models
{
    public class AcademicState
    {
        public int Id { get; set; }
        public int AcademicDegree { get; set; }
        public string Name { get; set; }
        public string Institute { get; set; }
        public DateTime? EndAt { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid AcademicStateRepresentative { get; set; }
    }
}
