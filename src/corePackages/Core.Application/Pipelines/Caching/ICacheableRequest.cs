namespace Core.Application.Pipelines.Caching;

public interface ICacheableRequest
{
    bool BypassCache { get; }
    string CacheKey { get; }
    TimeSpan? SlidingExpiration { get; }
}
