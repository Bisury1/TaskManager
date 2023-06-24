using MediatR;

namespace TaskManager.Application.Notes.Command.CreateNote
{
    public class CreateNoteCommand: IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
