using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public interface IJsonPlaceHolderRepository
    {
        Task<IEnumerable<Post>> GetPostsByIdAsync(int userId);
        Task<IEnumerable<Album>> GetAlbumsByIdAsync(int userId);
        Task<IEnumerable<ToDo>> GetToDoAsync(int userId);
    }
}
