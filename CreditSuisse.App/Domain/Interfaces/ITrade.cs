
namespace CreditSuisse.App.Domain.Interfaces
{
    interface ITrade
    {
        /// <summary>
        /// indicates the transaction amount in dollars
        /// </summary>
        double Value { get; }
        /// <summary>
        /// indicates the client´s sector which can be "Public" or "Private"
        /// </summary>
        string ClientSector { get; }
        /// <summary>
        /// indicates when the next payment from the client to the bank is expected
        /// </summary>
        DateTime NextPaymentDate { get; }
    }
}
