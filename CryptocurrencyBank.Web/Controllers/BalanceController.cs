using CryptocurrencyBank.Desktop.CryptocurrencyBankApi;
using CryptocurrencyBank.Web.Models.BalanceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptocurrencyBank.Web.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    public class BalanceController : Controller
    {
        private readonly BalanceHttpClient _client;

        public BalanceController(BalanceHttpClient client)
            => _client = client;

        public async Task<ActionResult> Index()
        {
            var response = await _client.GetAll();

            return View(response ?? new List<Balance>());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(BalanceCreateCommand model)
        {
            var response = await _client.Create(model);

            if(response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));
            
            return View(model);
        }
         
        public async Task<ActionResult> Edit(Guid id)
        {
            var response = await _client.GetById(id);

            var update = new BalanceUpdateCommand();

            (update.Id, update.Description, _) = response;

            return View(update);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BalanceUpdateCommand command)
        {
            var response = await _client.Update(command);

            if(response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(command);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _client.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
