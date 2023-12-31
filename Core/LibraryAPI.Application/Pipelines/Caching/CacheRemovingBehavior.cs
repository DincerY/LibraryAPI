﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace LibraryAPI.Application.Pipelines.Caching;

public class CacheRemovingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICacheRemoverRequest
{
    private readonly IDistributedCache _cache;
    public CacheRemovingBehavior(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request.BypassCache)
        {
            return await next();
        }

        TResponse response = await next();

        if (request.CacheKey != null)
        {
            await _cache.RemoveAsync(request.CacheKey, cancellationToken);
        }
        return response;
    }
}