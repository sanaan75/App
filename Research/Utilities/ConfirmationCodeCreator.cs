namespace Entities.Utilities;

public static class ConfirmationCodeCreator
{
    private static readonly Random Random = new();
    public static int GetRandomCode()
    {
        var code = Random.Next(11111, 99999);
        return code;
    }
}