using CreditSuisse.App.Domain.Interfaces;

namespace CreditSuisse.App.Domain.Repository
{
    public class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
    }
}
