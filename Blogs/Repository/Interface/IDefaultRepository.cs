using System;
using System.Collections.Generic;

namespace Blogs.Repository.Interface
{
    /// <summary>
    /// interface of base repository for all repositories
    /// </summary>
    public interface IDefaultRepository<T>
    {
        IEnumerable<T> Get();

        void Add(T data);

        void Remove(T data);

        T Get(Guid id);
    }
}
