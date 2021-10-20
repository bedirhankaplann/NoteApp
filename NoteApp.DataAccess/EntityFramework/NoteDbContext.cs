using Microsoft.EntityFrameworkCore;
using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.DataAccess.EntityFramework
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
