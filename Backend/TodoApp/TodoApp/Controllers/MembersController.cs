using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TodoApp.Extensions;
using TodoApp.Models.MembersModels;
using TodoAppLibrary.TaskContext;
using TodoAppLibrary.Tools;

namespace TodoApp.Controllers
{
    [Route("Tasks/{taskId}/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        [Route("viewers")]
        [HttpPost]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult AddNewViewer(
            [FromRoute] int taskId,
            [FromBody] AddNewViewerRequestModel model)
        {
            var currentUserId = Request.GetUserId();

            _taskFacade.AddTaskViewer(new Identifier(taskId),
                new Identifier(currentUserId), model.AddingUserId);

            return Ok();
        }

        [Route("redactor")]
        [HttpPost]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult AddNewRedactor(
            [FromRoute] int taskId,
            [FromBody] AddNewRedactorRequestModel model)
        {
            var currentUserId = Request.GetUserId();

            _taskFacade.AddTaskRedactor(new Identifier(taskId),
                new Identifier(currentUserId), model.RedactorId);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult DeleteTaskMember(
            [FromRoute] int taskId,
            [FromBody] DeleteTaskMemberRequestModel model)
        {
            var currentUserId = Request.GetUserId();

            _taskFacade.DeleteTaskMember(new Identifier(taskId),
                new Identifier(currentUserId), model.DeletingUserId);

            return Ok();
        }

        public MembersController(ITaskFacade taskFacade)
        {
            _taskFacade = Ensure.Any.IsNotNull(taskFacade);
        }

        private readonly ITaskFacade _taskFacade;
    }
}