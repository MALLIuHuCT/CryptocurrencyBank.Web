
using CryptocurrencyBank.Web.Models.Enumaretions;
using System.ComponentModel.DataAnnotations;

namespace CryptocurrencyBank.Web.Models.MoneyTransferModels
{
    public class MoneyTransferUpdateCommand
    {
        public MoneyTransferUpdateCommand() { }
        
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public Guid From { get; set; }
        
        [Required]
        public Guid To { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int HowMany { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TransferType TransferType { get; set; }
        
        [Required]
        public ClientType Client { get; set; }
    }
}
