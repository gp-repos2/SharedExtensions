using System;
using System.Text;

public static class StaticRandomizer
{
    static Random random;

    const int DEFAULT_MIN_PASSWORD_LENGTH = 8;
    const int DEFAULT_MAX_PASSWORD_LENGTH = 16;

    const string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
    const string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
    const string PASSWORD_CHARS_NUMERIC = "0123456789";
    const string PASSWORD_CHARS_SPECIAL = "!#$%&'()*+,-./:;<=>?@[]^_`{|}~";

    static StaticRandomizer()
    {
        random = new Random();
    }

    public static int RandomInt()
    {
        return random.Next();
    }

    public static int RandomInt(int maxValue)
    {
        return random.Next(maxValue);
    }

    public static int RandomInt(int minValue, int maxValue)
    {
        return random.Next(minValue, maxValue);
    }

    public static double RandomDouble()
    {
        return random.NextDouble();
    }

    public static void FillBytes(byte[] bytes)
    {
        random.NextBytes(bytes);
    }

    public static string RandomString(int Length, RandomStringOptions options = RandomStringOptions.Letters)
    {
        if (Length == 0)
            return "";

        StringBuilder dictionary = new StringBuilder();
        if ((options & RandomStringOptions.Letters) == RandomStringOptions.Letters) dictionary.Append(PASSWORD_CHARS_UCASE);
        if ((options & RandomStringOptions.Numbers) == RandomStringOptions.Numbers) dictionary.Append(PASSWORD_CHARS_NUMERIC);
        if ((options & RandomStringOptions.SpecialChars) == RandomStringOptions.SpecialChars) dictionary.Append(PASSWORD_CHARS_SPECIAL);
        if ((options & RandomStringOptions.Letters) == RandomStringOptions.Letters) dictionary.Append(PASSWORD_CHARS_LCASE);
        if ((options & RandomStringOptions.Numbers) == RandomStringOptions.Numbers) dictionary.Append(PASSWORD_CHARS_NUMERIC);

        char[] result = new char[Length];
        for (int i = 0; i < Length; i++)
            result[i] = dictionary[random.Next(dictionary.Length)];

        return new string(result);
    }

    public static string RandomString(RandomStringOptions options = RandomStringOptions.Letters)
    {
        return RandomString(random.Next(DEFAULT_MIN_PASSWORD_LENGTH, DEFAULT_MAX_PASSWORD_LENGTH), options);
    }

    public enum RandomStringOptions { Letters = 1, Numbers = 2, SpecialChars = 4 }

}
