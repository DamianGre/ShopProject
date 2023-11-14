using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Dtos.Users;

namespace ShopProject.WebApi.Commands
{
    public class DeleteUserCommand : IRequest<ActionResult<UserDto>>
    {
        public int UserId { get; set; }
    }
}
