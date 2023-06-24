using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Application.Notes.Command.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _notesDbContext;

        public UpdateNoteCommandHandler(INotesDbContext notesDbContext)
        {
            _notesDbContext = notesDbContext;
        }
        public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            Note? entityNote =
                await _notesDbContext.Notes.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);

            if (entityNote == null)
            {
                throw new ArgumentNullException(nameof(entityNote));
            }

            entityNote.Description = request.Description;
            entityNote.Title = request.Title;
            entityNote.Status = request.Status;

            await _notesDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
