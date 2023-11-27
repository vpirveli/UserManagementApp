namespace Domain.Models
{
    public partial class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }

        public virtual UserProfile IdNavigation { get; set; } = null!;
    }
}
