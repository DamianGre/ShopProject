using ShopProject.Converters.Interfaces;
using ShopProject.DBModels.Entities;
using ShopProject.Dtos.Users;

namespace ShopProject.Converters
{
    public class UserConverter : IUserConverter
    {
        public UserDto Convert(User user) 
        { 
            if(user == null)
                return null;
            return new UserDto() 
            { 
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        //couting logic example for all orders that user did in all history
        //allHistoryCosts = user.Orders.SelectMany(x => x.Item).Sum(y => y.Price);

        public IEnumerable<UserDto> Convert(IEnumerable<User> users)
        {
            return users.Select(x => Convert(x));
        }
    }
}
