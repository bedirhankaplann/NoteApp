using NoteApp.Business.Abstract;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NoteApp.Business
{
    public class NoteManager : INoteService
    {

        INoteRepository repo;

        public NoteManager(INoteRepository repo)
        {
            this.repo = repo;
        }

        public void Add(Note entity)
        {
            repo.Add(entity);
        }

        public void Delete(Note entity)
        {
            repo.Delete(entity);
        }

        public List<Note> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public Note GetById(int id)
        {
            return repo.GetById(id);
        }

        public List<Note> GetExpression(Expression<Func<Note, bool>> predicate)
        {
            return repo.GetExpression(predicate).ToList();
        }

        public void Update(Note entity)
        {
            repo.Update(entity);
        }
    }
}
