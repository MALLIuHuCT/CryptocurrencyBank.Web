using CryptocurrencyBank.Web.Models.Enumaretions;
using System.ComponentModel.DataAnnotations;

namespace CryptocurrencyBank.Web.Models.MoneyTransferModels
{
    public class MoneyTransferCreateCommand
    {
        public MoneyTransferCreateCommand() { }

        [Required]
        public Guid From { get; set; }
        [Required]
        public Guid To { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int HowMany { get; set; }
        public DateTime Date { get; init; } = DateTime.Now;
        [Required]
        public TransferType TransferType { get; set; }
        public ClientType Client { get; init; } = ClientType.Web;

    }
}
