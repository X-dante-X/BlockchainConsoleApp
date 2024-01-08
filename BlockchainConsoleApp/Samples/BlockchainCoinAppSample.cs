using Apps;
using Blockchain;
using Cryptography;
using Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сurrencies;

namespace Samples;

public static class BlockchainCoinAppSample
{
    public static void DoSample()
    {
        var signRule = new SignRule<TransactionBlock<Coin>, Transaction<Coin>>();
        var amountRule = new AmountRule<Coin>();
        var coinApp = new BlockchainApp<Coin>(rules: [signRule, amountRule]);
        var user1 = coinApp.GenerateKeys();
        var user2 = coinApp.GenerateKeys();
        var user3 = coinApp.GenerateKeys();

        coinApp.PerformTransaction(user1, user2.PrivateKey, new Coin { Amount = 10 });
        coinApp.PerformTransaction(user2, user3.PublicKey, new Coin { Amount = 30 });

        coinApp.View();
    }
}
