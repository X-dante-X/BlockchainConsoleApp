using Blockchain;
using Cryptography;
using System.Text.Json;
using Rules;

namespace Apps;


public class BlockchainApp<T>
{
    private readonly IBlockchain<TransactionBlock<T>> _blockchain;
    private readonly IEncryptor _encryptor;

    public BlockchainApp(
            IHashFunction? hashFunction = null,
            IEncryptor? encryptor = null,
            params IRule<TransactionBlock<T>>[] rules
        )
    {
        hashFunction ??= new CRC32Hash();
        encryptor ??= new RSAEncryptor();

        _encryptor = encryptor;

        _blockchain = new Blockchain<TransactionBlock<T>>(
            hashFunction,
            rules
        );
    }

    public KeyPair GenerateKeys() => _encryptor.GenerateKeys();

    public void AcceptTransaction(TransactionBlock<T> transactionBlock)
    {
        var block = _blockchain.BuildBlock(transactionBlock);
        _blockchain.AcceptBlock(block);
    }
    public void Register(KeyPair author, T obj)
        => PerformTransaction(author, author.PublicKey, obj);

    public void PerformTransaction(KeyPair fromKeys, string to, T obj)
    {
        var transaction = new Transaction<T>(fromKeys.PublicKey, to, obj);
        var transactionString = JsonSerializer.Serialize(transaction);
        var sign = _encryptor.Sign(transactionString, fromKeys.PrivateKey);
        var transactionBlock = new TransactionBlock<T>(transaction, sign);

        AcceptTransaction(transactionBlock);
    }
    public void View()
    {
        foreach(var item in _blockchain)
        {
            Console.WriteLine(item);
        }
    }
}