using CryptocurrencyBank.Web.Models.BalanceModels;
using System.Net.Http.Formatting;

namespace CryptocurrencyBank.Desktop.CryptocurrencyBankApi
{
    public class BalanceHttpClient
    {
        private readonly HttpClient _client;
        
        public BalanceHttpClient(HttpClient client) 
        {
            _client = client;
        }

        public async Task<IEnumerable<Balance>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<Balance>>("GetAll");
        }

        public async Task<Balance> GetById(Guid id)
        {
            return await _client.GetFromJsonAsync<Balance>($"Get/{id}");
        }

        public async Task<HttpResponseMessage> Update(BalanceUpdateCommand updateCommand)
        {
            return await _client.PutAsync($"Update", updateCommand, new JsonMediaTypeFormatter());
        }

        public async Task<HttpResponseMessage> Create(BalanceCreateCommand createCommand)
        {
            return await _client.PostAsync($"Create", createCommand, new JsonMediaTypeFormatter());
        }

        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            return await _client.DeleteAsync($"Delete/{id}");
        }
    }
}
