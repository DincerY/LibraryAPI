using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Pipelines.Caching;

public interface ICachableRequest
{
    string CacheKey { get;}
    bool ByPassCache { get;}
    TimeSpan? SlidingExpiration { get; }
}