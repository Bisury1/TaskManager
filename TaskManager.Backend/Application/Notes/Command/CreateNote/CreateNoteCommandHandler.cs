using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notes.Command.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _notesDbContext;

        public CreateNoteCommandHandler(INotesDbContext notesDbContext)
        {
            this._notesDbContext = notesDbContext;
        }
        public Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
