using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models.SearchingModels;
using TodoAppLibrary.UserContext;

namespace TodoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchingController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(GetUsersByNameResponseModel), 200)]
        public IActionResult GetUsersByName([FromQuery] string namePart)
        {
            var result = _userFacade.GetUsersByUserName(namePart);

            var responseItem = new List<GetUsersByNameItemResponseModel>();

            result.ToList().ForEach(r => 
                responseItem.Add(new GetUsersByNameItemResponseModel(r.Username, r.Email, r.Identifier)));

            var response = new GetUsersByNameResponseModel(responseItem);

            return Ok(response);
        }

        private readonly IUserFacade _userFacade;

        public SearchingController(IUserFacade userFacade)
        {
            _userFacade = Ensure.Any.IsNotNull(userFacade);
        }
    }
}