namespace CryptocurrencyBank.Web.Models.BalanceModels
{
    public class BalanceCreateCommand
    {
        public string? Description { get; set; }

        public int Value { get; set; }
    }
}
