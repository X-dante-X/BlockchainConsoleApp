using Blockchain;
using Apps;
using Сurrencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules;

public class OwningRule<T> : IRule<TransactionBlock<T>> where T : INFT
{
    public void Execute(IEnumerable<Block<TransactionBlock<T>>> previousBlocks, Block<TransactionBlock<T>> newBlock)
    {
        var block = newBlock.Data;
        if (block.Data.From == block.Data.To)
        {
            // Verify that nobody else has registered this WorkOfArt
            if (previousBlocks.Any(x => x.Data.Data.Value.Name == block.Data.Value.Name))
                throw new ApplicationException(
                    "You are trying to register the work of art that is already registered.");
        }
        else
        {
            foreach (var b in previousBlocks.Reverse())
            {
                if (b.Data.Data.Value.Name == newBlock.Data.Data.Value.Name)
                {
                    if (b.Data.Data.To == block.Data.From)
                        return;
                    throw new ApplicationException(
                        "You are trying to transfer the work of art that you are not owning.");
                }
            }

            throw new ApplicationException("You are trying- to transfer the work of art that has not been yet registered.");
        }
    }
}