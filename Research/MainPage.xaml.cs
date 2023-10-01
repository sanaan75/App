using Entities;
using Persistence;
using Research.Utilities;

namespace Research;

public partial class MainPage : ContentPage
{
    private readonly IRepository _db;
    
    public MainPage(IRepository db)
    {
        _db = db;
        InitializeComponent();
    }

    public MainPage()
    {
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        try
        {
            var items = _db.Query<Person>();
            _db.Set<Person>().Add(new Person
            {
                Name = RandomHelper.StringRandom(6),
                Username = "user" + RandomHelper.RandomNumber(1, 1000),
                Password = "pass"
            });
            _db.Save();
            PersonList.ItemsSource = items.ToList();
        }
        catch (Exception ex)
        {
        }
    }
}