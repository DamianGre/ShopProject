using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Dtos.Users;

namespace ShopProject.WebApi.Commands
{
    public class CreateUserCommand : IRequest<ActionResult<UserDto>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
