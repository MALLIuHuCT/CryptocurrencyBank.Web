namespace CryptocurrencyBank.Web.Models.BalanceModels
{
    public class Balance
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public int Value { get; set; }

        public void Deconstruct(out Guid id, out string? description, out int value)
        {
            id = Id;
            description = Description;
            value = Value;
        }
    }
}
