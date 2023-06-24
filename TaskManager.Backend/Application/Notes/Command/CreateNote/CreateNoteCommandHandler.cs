using Domain;
using MediatR;

namespace TaskManager.Application.Notes.Command.CreateNote
{
    public class CreateNoteCommandHandler 
        : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _notesDbContext;

        public CreateNoteCommandHandler(INotesDbContext notesDbContext)
        {
            _notesDbContext = notesDbContext;
        }
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note()
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                CreationTime = DateTime.UtcNow,
                Description = request.Description,
                EditTime = null,
                Title = request.Title,
                Status = request.Status
            };

            await _notesDbContext.Notes.AddAsync(note, cancellationToken);
            await _notesDbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
