using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Mkeeper.Db.Entities.Abstract;
using Mkeeper.Db.Enums;

namespace Mkeeper.Db.Entities;

public class Category : Entity
{
    public TransactionType Type { get; init; }
    public required string Name { get; init; }
    public bool Deleted { get; init; }

    #region Navigation
    public ICollection<Transaction>? Transactions { get; init; }
    #endregion
}
