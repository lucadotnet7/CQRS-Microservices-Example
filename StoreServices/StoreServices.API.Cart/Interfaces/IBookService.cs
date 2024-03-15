using StoreServices.API.Cart.Models.Remote;
using System.Threading.Tasks;

namespace StoreServices.API.Cart.Interfaces
{
    public interface IBookService
    {
        Task<(bool result, BookRemote bookRemote, string errorMessage)> GetBook(int bookId);
    }
}
