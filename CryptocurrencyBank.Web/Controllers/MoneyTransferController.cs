using CryptocurrencyBank.Desktop.CryptocurrencyBankApi;
using CryptocurrencyBank.Web.Models.MoneyTransferModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptocurrencyBank.Web.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    public class MoneyTransferController : Controller
    {
        private readonly MoneyTransferHttpClient _transferClient;

        public MoneyTransferController(MoneyTransferHttpClient transferClient)
            => _transferClient = transferClient;

        public async Task<ActionResult> Index()
        {
            var model = await _transferClient.GetAll() ?? new List<MoneyTransfer>();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(MoneyTransferCreateCommand model)
        {
            var response = await _transferClient.Create(model);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var response = await _transferClient.Get(id);

            if (response is not null)
            {
                var model = new MoneyTransferUpdateCommand();
                (model.Id, model.From, model.To, model.HowMany, model.Date, model.TransferType, model.Client) = response;
                
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(MoneyTransferUpdateCommand model)
        {
            var response = await _transferClient.Update(model);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            if (Guid.Empty != id)
            {
                var response = await _transferClient.Delete(id);
                var a = response;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
