using Clareia.Domain.Interfaces;
using System.Collections.Concurrent;

public class FakeRepository<T, TKey> : IRepository<T, TKey>
    where T : class
    where TKey : struct
{
    private readonly ConcurrentDictionary<TKey, T> _store = new();
    private readonly Func<T, TKey> _keySelector;

    public FakeRepository(Func<T, TKey> keySelector)
    {
        _keySelector = keySelector;
    }

    public Task<T?> GetByIdAsync(TKey id)
        => Task.FromResult(_store.TryGetValue(id, out var item) ? item : null);

    public Task<IEnumerable<T>> GetAllAsync()
        => Task.FromResult(_store.Values.AsEnumerable());

    public Task AddAsync(T entity)
    {
        var key = _keySelector(entity);
        _store.TryAdd(key, entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(T entity)
    {
        var key = _keySelector(entity);
        _store[key] = entity;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TKey id)
    {
        _store.TryRemove(id, out _);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        => Task.FromResult(_store.Values.Where(predicate));
}
