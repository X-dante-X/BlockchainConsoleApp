using Apps;
using Blockchain;

namespace Rules;

public interface IRule<T>
{
    void Execute(IEnumerable<Block<T>> previousBlocks, Block<T> newBlock);
}

public interface ISigned<T>
{
    public string FromPublicKey { get; }
    public string ToPublicKey { get; }
    public string Sign { get; }
    public T Data { get; }
}
