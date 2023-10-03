using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mkeeper.Core.WorkContext;

public interface IWorkContext : IDisposable
{
    Task Commit();
    Task Rollback();
}
