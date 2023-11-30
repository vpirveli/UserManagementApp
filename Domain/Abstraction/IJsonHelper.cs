using Domain.Models;

namespace Domain.Abstraction;

public interface IJsonHelper
{
    Task<IEnumerable<Comment?>> GetCommentsByPostIdAsync(int postId);
    Task<IEnumerable<Photo?>> GetPhotosByAlbumIdAsync(int postId);
}
