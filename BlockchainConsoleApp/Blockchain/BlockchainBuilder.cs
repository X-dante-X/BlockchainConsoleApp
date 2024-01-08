using Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain;

public class BlockchainBuilder<T>
{
    private readonly IHashFunction _hashFunction;
    private string? _tail;

    public BlockchainBuilder(IHashFunction hashFunction, string? tail = null)
    {
        _hashFunction = hashFunction;
        _tail = tail;
    }

    public Block<T> BuildBlock(T data)
    {
        var hash = _hashFunction.GetHash(_tail + data);
        var block = new Block<T>(_tail, hash, data);
        _tail = hash;
        return block;
    }
}
