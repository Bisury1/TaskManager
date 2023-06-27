using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Notes.Command.CreateNote;
using TaskManager.Application.Notes.Command.DeleteNote;
using TaskManager.Application.Notes.Command.UpdateNote;
using TaskManager.Application.Notes.Queries.GetNoteList;
using TaskManager.WebApi.Models;

namespace TaskManager.WebApi.Controllers
{
    public class TaskController: BaseTaskController
    {
         private readonly IMapper _mapper;

        public TaskController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Redirect("api/Task/GetAll");
        }

       
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            await Mediator.Send(command);
            return Redirect("api/Task/GetAll");
        }

        
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return Redirect("api/Task/GetAll");
        }
    }
}
