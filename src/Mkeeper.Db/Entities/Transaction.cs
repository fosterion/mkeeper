using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mkeeper.Db.Entities;

public class Transaction : Cashflow
{
    public float Amount { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
