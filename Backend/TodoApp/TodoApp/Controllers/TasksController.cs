using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Extensions;
using TodoApp.Models.TasksModels;
using TodoAppLibrary.TaskContext;
using TodoAppLibrary.Tools;

namespace TodoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskFacade _taskFacade;

        public TasksController(ITaskFacade taskFacade)
        {
            _taskFacade = Ensure.Any.IsNotNull(taskFacade);
        }

        /// <summary>
        ///     Получить все задачи, доступные пользователю
        /// </summary>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(GetAllUsersTasksResponseModel), 200)]
        public IActionResult GetAllUserTasks()
        {
            var currentUserId = Request.GetUserId();
            var result = _taskFacade.GetTasksForUser(new Identifier(currentUserId));

            var returnValue = new List<GetAllUsersTasksResponseItemModel>();

            result.ToList().ForEach(task =>
            {
                var memberResult = new List<GetAllUsersTasksMemberResponseModel>();

                task.Members.ToList().ForEach(m => memberResult.Add(
                    new GetAllUsersTasksMemberResponseModel(m.MemberId, m.MemberRole, m.MemberUserName)));

                var taskResult = new GetAllUsersTasksResponseItemModel(memberResult, task.Important,
                    task.Done, task.TaskTitle, task.TaskId);

                returnValue.Add(taskResult);
            });

            var response = new GetAllUsersTasksResponseModel(returnValue);

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(AddNewTaskResponseModel), 200)]
        public IActionResult AddNewTask([FromBody] AddNewTaskRequestModel model)
        {
            var userId = Request.GetUserId();

            var newTaskId = _taskFacade.AddTask(new Identifier(userId), model.TaskTitle, model.Important);

            var result = new AddNewTaskResponseModel(newTaskId);

            return Ok(result);
        }

        [Route("{taskId}/importance")]
        [HttpPut]
        [Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public IActionResult SwitchTaskImportant([FromRoute] int taskId)
        {
            var userId = Request.GetUserId();

            _taskFacade.SwitchTaskImportant(new Identifier(taskId), new Identifier(userId));

            return Ok();
        }

        [Route("{taskId}/performance")]
        [HttpPut]
        [Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public IActionResult MakeTaskDone([FromRoute] int taskId)
        {
            var userId = Request.GetUserId();

            _taskFacade.MakeTaskDone(new Identifier(taskId), new Identifier(userId));

            return Ok();
        }
    }
}