using System.ComponentModel.DataAnnotations.Schema;

namespace Mkeeper.Db.Entities;

[Table("transactions")]
public class Transaction : Cashflow
{
    public string? Description { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
