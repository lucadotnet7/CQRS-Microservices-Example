using System;

namespace StoreServices.API.Cart.Models.Remote
{
    public class AuthorRemote
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? BornDate { get; set; }
        public Guid AuthorRepresentative { get; set; }
    }
}
