namespace Dashboard.Models
{
    public class UserRoleVM
    {
        public string Id { get; set; }
        public string UserName{ get; set; }
        public List<RoleEditVM> Roles { get; set; }
    }
}
