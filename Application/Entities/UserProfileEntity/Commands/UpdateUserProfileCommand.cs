using MediatR;

namespace Application.Entities.UserProfileEntity.Commands;

public class UpdateUserProfileCommand : IRequest
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PersonalNumber { get; set; } = null!;
}
