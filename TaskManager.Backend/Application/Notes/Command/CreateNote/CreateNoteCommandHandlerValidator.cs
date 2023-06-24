using FluentValidation;

namespace TaskManager.Application.Notes.Command.CreateNote
{
    public class CreateNoteCommandHandlerValidator: AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandHandlerValidator()
        {

            RuleFor(createNoteCommand =>
                createNoteCommand.Title).NotEmpty().MinimumLength(200);
            RuleFor(createNoteCommand =>
                createNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Status).NotEmpty();
        }
    }
}
