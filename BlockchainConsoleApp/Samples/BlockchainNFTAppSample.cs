using Apps;
using Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сurrencies;

namespace Samples;

public static class BlockchainNFTAppSample
{
    public static void DoSample()
    {
        var signRule = new SignRule<TransactionBlock<NFT>, Transaction<NFT>>();
        var owningRule = new OwningRule<NFT>();
        var NFTApp = new BlockchainApp<NFT>(rules: [signRule, owningRule]);
        var user1 = NFTApp.GenerateKeys();
        var user2 = NFTApp.GenerateKeys();
        var user3 = NFTApp.GenerateKeys();


        var someNFT = new NFT { Name = "Astro/IVOXYGEN.mp3" };
        NFTApp.Register(user1, someNFT);
        NFTApp.PerformTransaction(user1, user2.PublicKey, someNFT);

        NFTApp.View();
    }
}
