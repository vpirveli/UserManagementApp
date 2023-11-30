using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public interface IJsonHelper
    {
        Task<IEnumerable<Comment?>> GetCommentsByPostIdAsync(int postId);
        Task<IEnumerable<Photo?>> GetPhotosByAlbumIdAsync(int postId);
    }
}
