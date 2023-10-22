using System.ComponentModel.DataAnnotations.Schema;
using Mkeeper.Db.Entities.Abstract;
using Mkeeper.Db.Enums;

namespace Mkeeper.Db.Entities;

[Table("cashflows")]
public abstract class Cashflow : BaseEntity
{
    public CashflowType Type { get; set; }

    public float Amount { get; set; }

    public bool Deleted { get; set; }
}
