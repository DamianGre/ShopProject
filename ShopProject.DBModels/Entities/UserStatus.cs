namespace ShopProject.DBModels.Entities
{
    public class UserStatus : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<User>? Users { get;}
    }
}
