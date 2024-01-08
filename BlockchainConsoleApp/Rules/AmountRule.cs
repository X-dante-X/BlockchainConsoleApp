using Apps;
using Blockchain;
using Сurrencies;

namespace Rules;

public class AmountRule<T> : IRule<TransactionBlock<T>> where T : ICoin
{
    public void Execute(IEnumerable<Block<TransactionBlock<T>>> previousBlocks, Block<TransactionBlock<T>> newBlock)
    {
        if (newBlock.Data.FromPublicKey == newBlock.Data.ToPublicKey)
            return;

        long balance = 100;
        var transaction = newBlock.Data;
        var from = transaction.FromPublicKey;
        foreach (var block in previousBlocks)
        {
            var signedTransaction = block.Data;
            if (signedTransaction.FromPublicKey == from)
                balance -= signedTransaction.Data.Value.Amount;
            else
                balance += signedTransaction.Data.Value.Amount;
        }

        if (balance < transaction.Data.Value.Amount)
            throw new ApplicationException(
                $"User {transaction.FromPublicKey} does not have {transaction.Data.Value.Amount} coins. It has only {balance} coins.");
    }
}
