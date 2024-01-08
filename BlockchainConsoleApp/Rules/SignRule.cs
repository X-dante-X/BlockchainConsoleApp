using Blockchain;
using Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Rules;


public class SignRule<TBlockData, TSignedData> : IRule<TBlockData> where TBlockData : ISigned<TSignedData>
{ 
    private readonly IEncryptor _encryptor;

    public SignRule(IEncryptor? encryptor = null)
    {
        encryptor ??= new RSAEncryptor();
        _encryptor = encryptor;
    }

    public void Execute(IEnumerable<Block<TBlockData>> previousBlocks, Block<TBlockData> newBlock)
    {
        var dataBlock = newBlock.Data;
        var signed = dataBlock.Data;
        var transacrionString = JsonSerializer.Serialize(signed);
        if (!_encryptor.VerifySign(dataBlock.FromPublicKey, transacrionString, dataBlock.Sign))
            throw new ApplicationException("Block sign is incorrect.");
    }
}

