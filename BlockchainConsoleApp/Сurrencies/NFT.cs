using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сurrencies;

public interface INFT
{
    string Name { get; set; }
}

public class NFT : INFT
{
    public string Name { get; set; } = null!;
}
