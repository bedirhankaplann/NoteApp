using NoteApp.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NoteAppCore.DAL
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetExpression(Expression<Func<T, bool>> predicate);

        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save();
    }
}
