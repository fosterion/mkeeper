using System.ComponentModel.DataAnnotations.Schema;
using Mkeeper.Db.Entities.Abstract;
using Mkeeper.Db.Enums;

namespace Mkeeper.Db.Entities;

[Table("wallets")]
public class Wallet : BaseEntity
{
    public float InitialBalance { get; set; }

    public float Balance { get; set; }

    public CurrencyCode CurrencyCode { get; set; }
}
