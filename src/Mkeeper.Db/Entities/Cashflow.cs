using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mkeeper.Db.Entities.Abstract;
using Mkeeper.Db.Enums;

namespace Mkeeper.Db.Entities;

public class Cashflow : BaseEntity
{
    public CashflowType Type { get; set; }

    public bool Deleted { get; set; }
}
