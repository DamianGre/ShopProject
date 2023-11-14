namespace ShopProject.DBModels.Entities
{
    public class User : BaseModel
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? UserStatusId { get; set; }
        public UserStatus? UserStatus { get; set; }
    }
}
