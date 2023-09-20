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
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public IEnumerable<UserDto> Convert(IEnumerable<User> users)
        {
            return users.Select(x => Convert(x));
        }
    }
}
