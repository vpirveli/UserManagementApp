using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class UserProfile
{
    [ForeignKey("User")]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PersonalNumber { get; set; } = null!;

    public virtual User? User { get; set; }
}