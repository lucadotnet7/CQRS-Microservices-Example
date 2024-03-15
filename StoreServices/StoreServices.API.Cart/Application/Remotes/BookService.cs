using Microsoft.Extensions.Logging;
using StoreServices.API.Cart.Interfaces;
using StoreServices.API.Cart.Models.Remote;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreServices.API.Cart.Application.Remotes
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BookService> _logger;
        
        public BookService(IHttpClientFactory httpClientFactory, ILogger<BookService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool result, BookRemote bookRemote, string errorMessage)> GetBook(int bookId)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("Books");
                HttpResponseMessage response = await client.GetAsync($"/api/Book/GetById?id={bookId}");

                if (!response.IsSuccessStatusCode)
                    return (false, null, response.ReasonPhrase);

                string content = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                BookRemote result = JsonSerializer.Deserialize<BookRemote>(content, options);
                return (true, result, null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred in method GetBook - MessageError = {ex.Message}");
                return (false, null, ex.Message);
            }
        }
    }
}
