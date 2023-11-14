using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ShopProject.WebApi.Querries
{
    public class GetUsersByNameKeywordQuery : IRequest<ActionResult<IEnumerable<string>>>
    {
        public string? Name { get; set; }
    }
}
