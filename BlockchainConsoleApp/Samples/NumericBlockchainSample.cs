using Blockchain;
using Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples;

public static class NumericBlockchainSample
{
    public static void DoSample()
    {
        var crc = new CRC32Hash();
        var data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var blockchain = new Blockchain<string>(crc);

        foreach (var item in data)
        {
            var block = blockchain.BuildBlock(item.ToString());
            blockchain.AcceptBlock(block);
        }

        foreach (var block in blockchain)
        {
            Console.WriteLine(block);
        }
    }
}
