using Domain.Models;

namespace Domain.Abstraction;

public interface IJsonPlaceHolderRepository
{
    Task<IEnumerable<Post>> GetPostsByIdAsync(int userId);
    Task<IEnumerable<Album>> GetAlbumsByIdAsync(int userId);
    Task<IEnumerable<ToDo>> GetToDoAsync(int userId);
}
