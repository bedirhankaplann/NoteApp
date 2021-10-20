using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NoteApp.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        List<Category> GetExpression(Expression<Func<Category, bool>> predicate);

        Category GetById(int id);
        void Add(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}
