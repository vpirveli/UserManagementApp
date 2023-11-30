using Newtonsoft.Json;

namespace Infrastructure.Services;

internal class JsonHelper : IJsonHelper
{
    public async Task<IEnumerable<Comment?>> GetCommentsByPostIdAsync(int postId)
    {
        using var httpClient = new HttpClient();

        using var commentResponse = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/" + postId + "/comments/");

        commentResponse.EnsureSuccessStatusCode();

        var json = await commentResponse.Content.ReadAsStringAsync();
        IEnumerable<Comment> comments = JsonConvert.DeserializeObject<IEnumerable<Comment>>(json);

        return comments;
    }

    public async Task<IEnumerable<Photo?>> GetPhotosByAlbumIdAsync(int postId)
    {
        using var httpClient = new HttpClient();

        using var photoResponse = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/albums/" + postId + "/photos/");

        photoResponse.EnsureSuccessStatusCode();

        var json = await photoResponse.Content.ReadAsStringAsync();
        IEnumerable<Photo> photos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(json);

        return photos;
    }
}
