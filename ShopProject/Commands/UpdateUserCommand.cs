using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Dtos.Users;

namespace ShopProject.WebApi.Commands
{
    public class UpdateUserCommand : IRequest<ActionResult<UserDto>>
    {
        [FromRoute]
        //change setting in program.cs to allow camelcase
        public int UserId { get; set; }
        [FromBody]
        public UserUpdateDto User { get; set; }
    }
}
