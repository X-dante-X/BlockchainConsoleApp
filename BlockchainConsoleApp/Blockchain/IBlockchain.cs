using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain;

public interface IBlockchain<T> : IEnumerable<Block<T>>
{
    Block<T> BuildBlock(T data);
    void AcceptBlock(Block<T> block);
}
