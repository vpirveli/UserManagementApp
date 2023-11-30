using Domain.Abstraction;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonPlaceHolderController(IJsonPlaceHolderRepository JsonRepository) : Controller
    {
        private readonly IJsonPlaceHolderRepository _jsonRepository = JsonRepository;

        // GET posts from JsonPlaceHolder
        [HttpGet("posts")]
        public async Task<IEnumerable<Post>> GetPostsByUserId([FromQuery] int id)
        {
            return await _jsonRepository.GetPostsByIdAsync(id);
        }

        // GET ToDos from JsonPlaceHolder
        [HttpGet("todos")]
        public async Task<IEnumerable<ToDo>> GetToDosByUserId([FromQuery] int id)
        {
            return await _jsonRepository.GetToDoAsync(id);
        }

        [HttpGet("albums")]
        public async Task<IEnumerable<Album>> GetAlbumByUserId([FromQuery] int id)
        {
            return await _jsonRepository.GetAlbumsByIdAsync(id);
        }


    }
}
