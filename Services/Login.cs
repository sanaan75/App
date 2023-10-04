using Usecases;

namespace Services;

public class Login : ILogin
{
    private readonly IDb _db;

    public Login(IDb db)
    {
        _db = db;
    }

    public async void Respond(string username, string password)
    {
        //await DisplayAlert("", "", "OK");
    }
}