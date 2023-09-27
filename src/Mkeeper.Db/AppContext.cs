using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mkeeper.Db.Models;

namespace Mkeeper.Db;

public class AppContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();

    public AppContext(DbContextOptions<AppContext> options) : base(options) { }
}
