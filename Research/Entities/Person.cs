using Research.Abstractions;
using SQLite;

namespace Research.Entities;

[SQLite.Net.Attributes.Table("Persons")]
public class Person : IEntity
{
    [SQLite.PrimaryKey, SQLite.AutoIncrement] public int Id { get; set; }
    [SQLite.Net.Attributes.MaxLength(50)] 
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    // [OneToMany(CascadeOperations = CascadeOperation.None)]
    // public ICollection<ToDo> ToDos { get; set; }
}