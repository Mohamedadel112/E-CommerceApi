namespace Dashboard.Models
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string phonenumber { get; set; }
        public IEnumerable<string> roles { get; set; }
    }
}
