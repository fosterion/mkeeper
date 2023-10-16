using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mkeeper.Db.Enums;

namespace Mkeeper.Db.Entities;

public class Transaction : BaseEntity
{
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public int SourceId { get; set; }
    public int? TargetId { get; set; }
    public bool Deleted { get; set; }

    #region Navigation
    public Category? Category { get; set; }
    public Wallet? Source { get; set; }
    public Wallet? Target { get; set; }
    #endregion
}
