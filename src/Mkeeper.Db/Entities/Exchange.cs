using System.ComponentModel.DataAnnotations.Schema;

namespace Mkeeper.Db.Entities;

[Table("exchanges")]
public class Exchange : Cashflow
{
    public float ExchangeRate { get; set; }

    public int SourceId { get; set; }
    public Wallet? Source { get; set; }

    public int TargetId { get; set; }
    public Wallet? Target { get; set; }
}
