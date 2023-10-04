using Entities;
using Research.Utilities;
using Services;

namespace Research;

public partial class MainPage : ContentPage
{
    private readonly IDb _db;

    public MainPage(IDb db)
    {
        _db = db;
        InitializeComponent();
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

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await DisplayAlert("عنوان پیام", "متن نمونه", "تایید");
    }
}