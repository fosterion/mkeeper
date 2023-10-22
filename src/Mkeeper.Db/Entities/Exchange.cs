using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mkeeper.Db.Entities;

public class Exchange : Cashflow
{
    public float ExchangeRate { get; set; }

    public int SourceId { get; set; }
    public Wallet? Source { get; set; }

    public int TargetId { get; set; }
    public Wallet? Target { get; set; }
}
