using ShopProject.DBModels.Entities;
using ShopProject.Dtos.Users;

namespace ShopProject.Converters.Interfaces
{
    public interface IUserConverter
    {
        UserDto Convert(User user);
        IEnumerable<UserDto> Convert(IEnumerable<User> user);
    }
}
