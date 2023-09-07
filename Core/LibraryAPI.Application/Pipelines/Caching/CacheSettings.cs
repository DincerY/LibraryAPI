using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Pipelines.Caching;

public class CacheSettings
{
    public int SlidingExpiration { get; set; }
}