namespace Entities;

public class Post: IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime? CreateDate { get; set; }
}