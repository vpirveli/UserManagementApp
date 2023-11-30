namespace Domain.Models
{
    public partial class User
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }

        public virtual UserProfile UserProfile { get; set; } = null!;
    }
}
