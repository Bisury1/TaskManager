using TaskManager.Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityNoteConfiguration;

namespace Persistence
{
    public class NotesDbContext: DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NotesDbContext(DbContextOptions<NotesDbContext> dbContextOptions)
            : base(dbContextOptions) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
