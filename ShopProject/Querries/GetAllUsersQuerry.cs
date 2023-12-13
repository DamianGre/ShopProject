using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Dtos.Users;

namespace ShopProject.WebApi.Querries
{
    public class GetAllUsersQuerry : IRequest<ActionResult<IEnumerable<UserDto>>>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
