﻿using MediatR;

namespace TaskManager.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQuery: IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}
