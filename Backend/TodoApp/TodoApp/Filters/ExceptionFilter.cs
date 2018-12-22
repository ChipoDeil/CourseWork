using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoAppLibrary.TaskContext.Exceptions;
using TodoAppLibrary.UserContext.Exceptions;

namespace TodoApp.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case UserNotFoundException exception:
                    context.Result = new BadRequestObjectResult(exception.Message);
                    break;
                case UserAlreadyExistsException exception:
                    context.Result = new BadRequestObjectResult(exception.Message);
                    break;
                case AlreadyMemberException exception:
                    context.Result = new BadRequestObjectResult(exception.Message);
                    break;
                case MemberHasNoPermissionsException exception:
                    context.Result = new BadRequestObjectResult(exception.Message);
                    break;
                case MemberNotFoundException exception:
                    context.Result = new BadRequestObjectResult(exception.Message);
                    break;
                case TaskNotFoundException exception:
                    context.Result = new BadRequestObjectResult(exception.Message);
                    break;
                default:
                    context.Result = new ObjectResult("Unknown error occured")
                    {
                        StatusCode = 500
                    };
                    break;
            }
        }
    }
}
