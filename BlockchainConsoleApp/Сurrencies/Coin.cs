using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сurrencies;

public interface ICoin
{
    long Amount { get; set; }
}
public class Coin : ICoin
{
    public long Amount { get; set; }
}
