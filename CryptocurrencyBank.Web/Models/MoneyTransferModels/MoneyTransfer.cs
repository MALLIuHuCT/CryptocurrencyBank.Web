using CryptocurrencyBank.Web.Models.Enumaretions;

namespace CryptocurrencyBank.Web.Models.MoneyTransferModels
{
    public class MoneyTransfer
    {
        public Guid Id { get; set; }
        public Guid From { get; set; }
        public Guid To { get; set; }
        public int HowMany { get; set; }
        public DateTime Date { get; set; }
        public TransferType TransferType { get; set; }
        public ClientType Client { get; set; }

        public void Deconstruct(out Guid id, 
            out Guid from, 
            out Guid to, 
            out int howMany, 
            out DateTime date, 
            out TransferType transferType,
            out ClientType clientType)
        {
            id = Id;
            from = From; 
            to = To;
            howMany = HowMany;
            date = Date;
            transferType = TransferType;
            clientType = Client;
        }
    }
}
