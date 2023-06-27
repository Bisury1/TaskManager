using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandlerValidator: AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryHandlerValidator()
        {
            RuleFor(note => note.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
