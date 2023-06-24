using Domain;
using MediatR;

namespace TaskManager.Application.Notes.Command.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _notesDbContext;

        public DeleteNoteCommandHandler(INotesDbContext notesDbContext)
        {
            _notesDbContext = notesDbContext;
        }
        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            Note? entityNote = 
                await _notesDbContext.Notes.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entityNote == null || entityNote.UserId != request.UserId)
            {
                throw new ArgumentNullException(nameof(entityNote));
            }

            _notesDbContext.Notes.Remove(entityNote);
            await _notesDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
