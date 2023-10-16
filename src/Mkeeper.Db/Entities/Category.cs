using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Mkeeper.Db.Enums;

namespace Mkeeper.Db.Entities;

public class Category : BaseEntity
{
    public TransactionType Type { get; set; }
    public string Name { get; set; } = default!;
    public bool Deleted { get; set; }

    #region Navigation
    public List<Transaction> Transactions { get; set; } = new();
    #endregion
}
