using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notes.Command.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _notesDbContext;

        public UpdateNoteCommandHandler(INotesDbContext notesDbContext)
        {
            this._notesDbContext = notesDbContext;
        }
        public Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
