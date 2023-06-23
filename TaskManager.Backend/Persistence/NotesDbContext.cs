using Application;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    internal class NotesDbContext: DbContext, INoteDbContext
    {
        public DbSet<Note> Notes { get; set; }

    }
}
