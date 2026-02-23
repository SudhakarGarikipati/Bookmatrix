namespace WebClient.Models
{
    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool? IsActive { get; set; }

        public string Token { get; set; }

        public List<string> Roles { get; set; }
    }
}
