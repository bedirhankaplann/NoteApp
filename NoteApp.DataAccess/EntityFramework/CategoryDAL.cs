using NoteApp.Core.EntityFramework;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.DataAccess.EntityFramework
{
    public class CategoryDAL : RepositoryBase<Category, NoteDbContext>, ICategoryRepository
    {
        public CategoryDAL(NoteDbContext context) : base(context)
        {

        }
    }
}
