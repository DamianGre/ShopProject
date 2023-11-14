using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Repositories;
using ShopProject.WebApi.Querries;

namespace ShopProject.WebApi.Handlers
{
    public class GetUsersByNameKeywordHandler : IRequestHandler<GetUsersByNameKeywordQuery, ActionResult<IEnumerable<string>>>
    {
        private readonly IShopProjectUnitOfWork _unitOfWork;

        public GetUsersByNameKeywordHandler(IShopProjectUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<IEnumerable<string>>> Handle(GetUsersByNameKeywordQuery query, CancellationToken cancellationToken)
        {
            var names = await _unitOfWork.UserRepository.GetUsersByNameKeywordAsync(query.Name);

            return new OkObjectResult(names);
        }
    }
}
