namespace Domain.Models;

public class Album
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<Photo> Photos { get; set; } = Enumerable.Empty<Photo>();
}
