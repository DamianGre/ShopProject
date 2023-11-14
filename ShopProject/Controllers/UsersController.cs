using Microsoft.AspNetCore.Mvc;
using MediatR;
using ShopProject.Dtos.Users;
using ShopProject.WebApi.Querries;
using ShopProject.WebApi.Commands;
using System.Data;

namespace ShopProject.WebApi.Controllers
{
    [ApiController]
    [Route("v1/controller")]
    public class UsersController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieve all users
        /// <summary>
        /// <returns>Returns UserDto List</returns>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers([FromQuery] GetAllUsersQuerry query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Names array to autocomplete
        /// <summary>
        /// <returns>Array of string - user names</returns>
        [HttpGet("names")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<string>>> GetUsersNames([FromQuery] GetUsersByNameKeywordQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Create new user
        /// <summary>
        /// <returns>Returns UserDto</returns>
        [HttpPost()]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }
        /// <summary>
        /// Update user by id
        /// <summary>
        /// <returns>Returns UserDto</returns>
        [HttpPut("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserDto>> Update([FromBody] UpdateUserCommand command)
        {
            return await _mediator.Send(command);
        }
        /// <summary>
        /// Delete user by id
        /// <summary>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserDto>> Delete([FromRoute] DeleteUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
