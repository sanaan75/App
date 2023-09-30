using Research.DB;
using Research.Entities;
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

    private void OnCounterClicked(object sender, EventArgs e)
    {
        try
        {
            var items = _db.GetQuery<Person>();
            _db.Add<Person>(new Person
            {
                Name = RandomHelper.StringRandom(6),
                BirthDate = DateTime.Now.AddYears(-1 * RandomHelper.RandomNumber(15, 50))
            });
            PersonList.ItemsSource = items.ToList();
            var d = items.Where(i => i.Id > 4).ToList();
            var f = items.GroupBy(i => i.Name).Count();
            var xx = Costants.DbPath;
        }
        catch (Exception ex)
        {
        }
    }
}