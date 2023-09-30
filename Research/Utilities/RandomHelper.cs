namespace Research.Utilities;

public static class RandomHelper
{
    static Random random;

    public static int RandomNumber(int min, int max)
    {
        random = new Random();
        return random.Next(min, max);
    }

    public static string StringRandom(int length)
    {
        random = new Random();

        String b = "abcdefghijklmnopqrstuvwxyz0123456789";

        string result = "";

        for (int i = 0; i < length; i++)
        {
            int a = random.Next(26);
            result = result + b.ElementAt(a);
        }

        return result;
    }
}