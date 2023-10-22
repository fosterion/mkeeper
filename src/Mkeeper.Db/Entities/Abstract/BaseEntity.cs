using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mkeeper.Db.Entities.Abstract;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
}
