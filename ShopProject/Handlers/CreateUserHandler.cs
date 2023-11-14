using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Converters.Interfaces;
using ShopProject.Dtos.Users;
using ShopProject.Repositories;
using ShopProject.WebApi.Commands;

namespace ShopProject.WebApi.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand ,ActionResult<UserDto>>
    {
        private readonly IShopProjectUnitOfWork _unitOfWork;
        private readonly IUserConverter _userConverter;

        public CreateUserHandler(IShopProjectUnitOfWork unitOfWork, IUserConverter userConverter)
        { 
            _unitOfWork = unitOfWork;
            _userConverter = userConverter;
        }

        public async Task<ActionResult<UserDto>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var user = new DBModels.Entities.User()
                {
                    Name = command.Name,
                    Email = command.Email,
                    Password = command.Password
                };

                await _unitOfWork.UserRepository.CreateAsync(user);
                await _unitOfWork.SaveChangesAsync();

                return new OkObjectResult(_userConverter.Convert(user))
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }
        }
    }
}
