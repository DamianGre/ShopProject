using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Converters.Interfaces;
using ShopProject.Dtos.Users;
using ShopProject.Repositories;
using ShopProject.WebApi.Querries;

namespace ShopProject.WebApi.Handlers
{
    public class GetUsersHandlers : IRequestHandler<GetAllUsersQuerry, ActionResult<IEnumerable<UserDto>>>
    {
        private readonly IShopProjectUnitOfWork _unitOfWork;
        private readonly IUserConverter _userConverter;

        public GetUsersHandlers(IShopProjectUnitOfWork unitOfWork, IUserConverter userConverter)
        {
            _unitOfWork = unitOfWork;
            _userConverter = userConverter;
        }

        public async Task<ActionResult<IEnumerable<UserDto>>> Handle(GetAllUsersQuerry querry, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var users = await _unitOfWork.UserRepository.GetUsersAsync(querry.Name);

                return new OkObjectResult(users.Select(x => _userConverter.Convert(x)));
            }
        }
    }
}
