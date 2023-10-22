using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mkeeper.Db.Entities.Abstract;
using Mkeeper.Db.Enums;

namespace Mkeeper.Db.Entities;

public class Wallet : BaseEntity
{
    public float InitialBalance { get; set; }

    public float Balance { get; set; }

    public CurrencyCode CurrencyCode { get; set; }
}
