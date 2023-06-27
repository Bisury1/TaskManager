using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TaskManager.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public abstract class BaseTaskController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
