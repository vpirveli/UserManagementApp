using Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Infrastructure.Repositories;

internal class JsonPlaceHolderRepository(IHttpClientFactory httpClientFactory, IJsonHelper jsonHelper) : IJsonPlaceHolderRepository
{
    private const string baseUrl = "https://jsonplaceholder.typicode.com";
    private readonly IJsonHelper _jsonHelper = jsonHelper;
    public async Task<IEnumerable<Album>> GetAlbumsByIdAsync(int userId)
    {
        string albumUrl = baseUrl + "/albums/?userId=" + userId;

        using HttpClient _httpClient = httpClientFactory.CreateClient();

        using var response = await _httpClient.GetAsync(albumUrl);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();


        IEnumerable<Album> albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(json);

        if (albums.IsNullOrEmpty())
        {
            throw new NotFoundException("The record has not been found");
        }

        foreach (Album album in albums)
        {
            album.Photos = await _jsonHelper.GetPhotosByAlbumIdAsync(album.Id);
        }

        return albums;
    }

    public async Task<IEnumerable<Post>?> GetPostsByIdAsync(int userId)
    {
        string postUrl = baseUrl + "/posts/?userId=" + userId;

        using HttpClient _httpClient = httpClientFactory.CreateClient();

        using var response = await _httpClient.GetAsync(postUrl);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();


        IEnumerable<Post> posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(json);

        if (posts.IsNullOrEmpty())
        {
            throw new NotFoundException("The record has not been found");
        }

        foreach (Post post in posts)
        {
            post.Comments = await _jsonHelper.GetCommentsByPostIdAsync(post.Id);
        }

        return posts;
    }

    public async Task<IEnumerable<ToDo>> GetToDoAsync(int userId)
    {
        string toDoUrl = baseUrl + "/todos/?userId=" + userId;

        using HttpClient _httpClient = httpClientFactory.CreateClient();

        using var response = await _httpClient.GetAsync(toDoUrl);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();


        IEnumerable<ToDo> toDo = JsonConvert.DeserializeObject<IEnumerable<ToDo>>(json);

        if (toDo.IsNullOrEmpty())
        {
            throw new NotFoundException("The record has not been found");
        }

        return toDo;
    }
}

