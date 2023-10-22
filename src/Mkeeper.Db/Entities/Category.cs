using System.ComponentModel.DataAnnotations.Schema;
using Mkeeper.Db.Entities.Abstract;
using Mkeeper.Db.Enums;

namespace Mkeeper.Db.Entities;

[Table("categories")]
public class Category : BaseEntity
{
    public TransactionType Type { get; set; }

    public string Name { get; set; } = default!;

    public bool Deleted { get; set; }

    public List<Transaction> Transactions { get; set; } = new();
}
