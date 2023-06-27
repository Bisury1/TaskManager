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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Redirect("/api/Auth/Login");
            }
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return RedirectToAction("GetAll", "Task");
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Redirect("/api/Auth/Login");
            }
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            await Mediator.Send(command);
            return Redirect("api/Task/GetAll");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Redirect("/api/Auth/Login");
            }
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
