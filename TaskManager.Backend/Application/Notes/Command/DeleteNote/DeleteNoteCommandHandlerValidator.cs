using FluentValidation;

namespace TaskManager.Application.Notes.Command.DeleteNote
{
    public class DeleteNoteCommandHandlerValidator: AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandHandlerValidator()
        {
            RuleFor(deleteNoteCommand =>
                deleteNoteCommand.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(deleteNoteCommand =>
                deleteNoteCommand.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
