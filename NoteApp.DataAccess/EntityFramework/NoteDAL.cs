using NoteApp.Core.EntityFramework;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities;

namespace NoteApp.DataAccess.EntityFramework
{
    public class NoteDAL : RepositoryBase<Note, NoteDbContext>, INoteRepository
    {
        public NoteDAL(NoteDbContext context) : base(context)
        {

        }
    }
}
