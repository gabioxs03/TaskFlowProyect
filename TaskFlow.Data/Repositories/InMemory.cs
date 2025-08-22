using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Data.Repositories;

public class InMemory : IRepository
{
    private List<Activity>? _tasksItems;

    public InMemory()
    {
        LoadProducts();
    }

    private List<T> GetList<T>() where T : EntityBase
    {
        if (typeof(T) == typeof(Activity)) return _tasksItems as List<T> ?? new List<T>();
        throw new NotSupportedException($"Tipo {typeof(T).Name} no soportado en InMemory.");
    }

    private void SetList<T>(List<T> list) where T : EntityBase
    {
        if (typeof(T) == typeof(Activity)) _tasksItems = list as List<Activity>;
        else throw new NotSupportedException($"Tipo {typeof(T).Name} no soportado en InMemory.");
    }

    public async Task<T?> GetById<T>(Guid id, params string[] include) where T : EntityBase
    {
        return await Task.FromResult(GetList<T>().FirstOrDefault(e => e.Id == id));
    }

    public async Task<IEnumerable<T>?> GetAll<T>(params string[] include) where T : EntityBase
    {
        return await Task.FromResult(GetList<T>());
    }

    public async Task<T?> First<T>(Expression<Func<T, bool>> predicate, params string[] include) where T : EntityBase
    {
        return await Task.FromResult(GetList<T>().FirstOrDefault(predicate.Compile()));
    }

    public async Task<IEnumerable<T>?> GetFiltered<T>(Expression<Func<T, bool>> predicate, params string[] include) where T : EntityBase
    {
        return await Task.FromResult(GetList<T>().Where(predicate.Compile()));
    }

    public async Task<T> Add<T>(T entity) where T : EntityBase
    {
        var list = GetList<T>();
        list.Add(entity);
        SetList(list);
        return await Task.FromResult(entity);
    }

    public async Task<T> Update<T>(T entity) where T : EntityBase
    {
        var list = GetList<T>();
        var index = list.FindIndex(e => e.Id == entity.Id);
        if (index >= 0)
        {
            list[index] = entity;
            SetList(list);
        }
        return await Task.FromResult(entity);
    }

    public async Task<T> Delete<T>(T entity) where T : EntityBase
    {
        var list = GetList<T>();
        list.RemoveAll(e => e.Id == entity.Id);
        SetList(list);
        return await Task.FromResult(entity);
    }

    public void LoadProducts()
    {
        var json = File.ReadAllText("../TaskFlow.Data/Sources/tasks.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        _tasksItems = JsonSerializer.Deserialize<List<Activity>>(json, options);
    }

}
