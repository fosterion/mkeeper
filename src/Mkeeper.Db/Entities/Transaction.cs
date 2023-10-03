using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mkeeper.Db.Entities.Abstract;
using Mkeeper.Db.Enums;

namespace Mkeeper.Db.Entities;

public class Transaction : Entity
{
    public string? Description { get; init; }
    public int CategoryId { get; init; }
    public int SourceId { get; init; }
    public int TargetId { get; init; }
    public DateTime Date { get; init; }
    public bool Deleted { get; init; }

    #region Navigation
    public Category? Category { get; init; }
    public Wallet? Source { get; init; }
    public Wallet? Target { get; init; }
    #endregion
}
