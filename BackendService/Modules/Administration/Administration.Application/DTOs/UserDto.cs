namespace Administration.Application.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public bool? IsActive { get; set; }

        public List<string> Roles { get; set; }
    }
}
