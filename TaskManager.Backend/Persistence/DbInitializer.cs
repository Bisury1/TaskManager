namespace Persistence
{
    public class DbInitializer
    {
        public static void DbInitialize(NotesDbContext notesDbContext) => notesDbContext.Database.EnsureCreated();
    }
}
