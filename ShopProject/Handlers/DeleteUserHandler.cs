using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Dtos.Users;
using ShopProject.Repositories;
using ShopProject.WebApi.Commands;

namespace ShopProject.WebApi.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ActionResult<UserDto>>
    {
        private readonly IShopProjectUnitOfWork _unitOfWork;

        public DeleteUserHandler(IShopProjectUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<UserDto>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var user = await _unitOfWork.UserRepository.GetByIdAsync(command.UserId);

                if (user == null)
                    return new NotFoundObjectResult($"User with Id: {command.UserId} don't exist in database!");

                _unitOfWork.UserRepository.Delete(user);
                await _unitOfWork.SaveChangesAsync();

                return new NoContentResult();
            }            
        }
    }
}
