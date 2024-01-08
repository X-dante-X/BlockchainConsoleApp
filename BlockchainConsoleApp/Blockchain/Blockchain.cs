using Cryptography;
using Rules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blockchain;

public record Block<T>(string? ParentHash, string Hash, T Data);


public class Blockchain<T> : IBlockchain<T>
{
    private readonly List<Block<T>> _blocks = [];
    private readonly IHashFunction _hashFunction;
    private readonly BlockchainBuilder<T> _builder;
    private readonly IRule<T>[] _Rules;


    public Blockchain(IHashFunction hashFunction, params IRule<T>[] rules)
    {
        _hashFunction = hashFunction;
        _builder = new BlockchainBuilder<T>(hashFunction);
        _Rules = rules;
    }
    public void AcceptBlock(Block<T> block)
    {
        foreach (var rule in _Rules)
        {
            rule.Execute(this, block);
        }
        AddBlock(block);
    }

    private void AddBlock(Block<T> block)
    {
        var tail = _blocks.LastOrDefault();
        if (block.ParentHash == tail?.Hash)
        {
            var expectedHash = _hashFunction.GetHash(block.ParentHash + block.Data);
            if (expectedHash == block.Hash)
            {
                _blocks.Add(block);
            }
            else
            {
                throw new ApplicationException($"Block {block} has invalid hash. It should be {expectedHash}.");
            }
        }
        else
        {
            throw new ApplicationException($"{block.ParentHash} is not following the current block {tail}");
        }
    }
    public Block<T> BuildBlock(T data)
    {
        return _builder.BuildBlock(data);
    }


    public IEnumerator<Block<T>> GetEnumerator()
    {
        return _blocks.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
