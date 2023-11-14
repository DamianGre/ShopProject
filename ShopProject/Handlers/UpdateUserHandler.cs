using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Converters.Interfaces;
using ShopProject.Dtos.Users;
using ShopProject.Repositories;
using ShopProject.WebApi.Commands;

namespace ShopProject.WebApi.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ActionResult<UserDto>>
    {
        private readonly IShopProjectUnitOfWork _unitOfWork;
        private readonly IUserConverter _userConverter;

        public UpdateUserHandler(IShopProjectUnitOfWork unitOfWork, IUserConverter userConverter)
        {
            _unitOfWork = unitOfWork;
            _userConverter = userConverter;
        }

        public async Task<ActionResult<UserDto>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(command.UserId);
                if (user == null)
                    return new NotFoundObjectResult($"User with Id: {command.UserId} don't exist in database!");

                if (!string.IsNullOrEmpty(command.User.Name))
                    user.Name = command.User.Name;
                if (!string.IsNullOrEmpty(command.User.Email))
                    user.Email = command.User.Name;
                if (!string.IsNullOrEmpty(command.User.Password))
                    user.Password = command.User.Password;

                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.SaveChangesAsync();

                return new NoContentResult();
            }
        }
    }
}
