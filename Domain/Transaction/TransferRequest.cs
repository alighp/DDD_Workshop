public class TransferRequest : ValueObject
{
    public TransactionParties Parties { get; }
    public Money Amount { get; }
    public TransferRequest(TransactionParties parties, Money amount)
    {
        Parties = parties;
        Amount = amount;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Parties;
        yield return Amount;
    }
}