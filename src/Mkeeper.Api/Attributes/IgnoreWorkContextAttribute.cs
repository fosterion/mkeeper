using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mkeeper.Api.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class IgnoreWorkContextAttribute : Attribute { }
