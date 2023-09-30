using System.ComponentModel.DataAnnotations;
using Research.Abstractions;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Research.Entities;

[Table("ToDos")]
public class ToDo : IEntity
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    // [ForeignKey(typeof(Person))] public int PersonId { get; set; }
    // public Person Person { get; set; }
    public string Title { get; set; }
    public DateTime CreateDate { get; set; }
}