using Rules;

namespace Apps;


public record Transaction<T>(string From, string To, T Value);


public record TransactionBlock<T>(Transaction<T> Data, string Sign) : ISigned<Transaction<T>>
{
    public string FromPublicKey => Data.From;
    public string ToPublicKey => Data.To;
}
