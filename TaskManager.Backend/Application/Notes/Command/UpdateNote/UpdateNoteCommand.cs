using MediatR;

namespace TaskManager.Application.Notes.Command.UpdateNote
{
    public class UpdateNoteCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
