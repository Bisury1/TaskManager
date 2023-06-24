using FluentValidation;

namespace TaskManager.Application.Notes.Command.UpdateNote
{
    public class UpdateNoteCommandHandlerValidator: AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandHandlerValidator()
        {
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Title).NotEmpty().MinimumLength(250);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Status).NotEmpty();
        }
    }
}
