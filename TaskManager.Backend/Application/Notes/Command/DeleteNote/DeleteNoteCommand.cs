using MediatR;

namespace TaskManager.Application.Notes.Command.DeleteNote
{
    public class DeleteNoteCommand: IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
