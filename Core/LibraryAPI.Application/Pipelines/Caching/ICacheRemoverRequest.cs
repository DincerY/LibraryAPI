﻿namespace LibraryAPI.Application.Pipelines.Caching;

public interface ICacheRemoverRequest   
{
    string? CacheKey { get; }
    bool BypassCache { get; }
}