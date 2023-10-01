namespace Entities;

public class Person : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    //public DateTime? BirthDate { get; set; }
}