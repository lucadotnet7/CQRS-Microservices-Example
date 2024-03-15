using StoreServices.API.Cart.Models.Remote;
using System;
using System.Threading.Tasks;

namespace StoreServices.API.Cart.Interfaces
{
    public interface IAuthorService
    {
        Task<(bool result, AuthorRemote authorRemote, string errorMessage)> GetAuthor(Guid authorRepresentative);
    }
}
