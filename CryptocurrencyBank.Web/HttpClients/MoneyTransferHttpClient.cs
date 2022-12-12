using CryptocurrencyBank.Web.Models.MoneyTransferModels;
using System.Net.Http.Formatting;

namespace CryptocurrencyBank.Desktop.CryptocurrencyBankApi
{
    public class MoneyTransferHttpClient
    {
        private readonly HttpClient _client;

        public MoneyTransferHttpClient(HttpClient client) 
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> Create(MoneyTransferCreateCommand createCommand)
        {
            return await _client.PostAsync($"Create", createCommand, new JsonMediaTypeFormatter());
        }

        public async Task<HttpResponseMessage> Update(MoneyTransferUpdateCommand updateCommand)
        {
            return await _client.PutAsync($"Update", updateCommand, new JsonMediaTypeFormatter());
        }

        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            return await _client.DeleteAsync($"Delete/{id}");
        }

        public async Task<IEnumerable<MoneyTransfer>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<MoneyTransfer>>($"GetAll");
        }

        public async Task<IEnumerable<MoneyTransfer>> GetByDate(DateTime date)
        {
            return await _client.GetFromJsonAsync<IEnumerable<MoneyTransfer>>($"GetByDate/{date}");
        }

        public async Task<MoneyTransfer> Get(Guid id)
        {
            return await _client.GetFromJsonAsync<MoneyTransfer>($"Get/{id}");
        }
    }
}
