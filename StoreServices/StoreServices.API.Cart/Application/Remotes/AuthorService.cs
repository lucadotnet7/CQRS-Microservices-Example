using Microsoft.Extensions.Logging;
using StoreServices.API.Cart.Interfaces;
using StoreServices.API.Cart.Models.Remote;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreServices.API.Cart.Application.Remotes
{
    public class AuthorService : IAuthorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IHttpClientFactory httpClientFactory, ILogger<AuthorService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool result, AuthorRemote authorRemote, string errorMessage)> GetAuthor(Guid authorRepresentative)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("Authors");
                HttpResponseMessage response = await client.GetAsync($"/api/Author/GetById?representative={authorRepresentative}");

                if (!response.IsSuccessStatusCode)
                    return (false, null, response.ReasonPhrase);

                string content = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                AuthorRemote result = JsonSerializer.Deserialize<AuthorRemote>(content, options);
                return (true, result, null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error ocurred in method GetAuthor - MessageError = {ex.Message}");
                return (false, null, ex.Message);
            }
        }
    }
}
