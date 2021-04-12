using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Trims the text to a provided maximum length
        /// </summary>
        /// <param name="value">The input string</param>
        /// <param name="maxLength">Maximum length</param>
        /// <returns>Trimmed string</returns>
        public static string TrimToMaxLength(this string value, int maxLength)
        {
            return (value == null || value.Length <= maxLength ? value : value.Substring(0, maxLength));
        }

        /// <summary>
        /// 	Trims the text to a provided maximum length and adds a suffix if required.
        /// </summary>
        /// <param name = "value">The input string.</param>
        /// <param name = "maxLength">Maximum length.</param>
        /// <param name = "suffix">The suffix.</param>
        /// <returns></returns>
        public static string TrimToMaxLength(this string value, int maxLength, string suffix)
        {
            return (value == null || value.Length <= maxLength ? value : string.Concat(value.Substring(0, maxLength), suffix));
        }

        /// <summary>
        /// 	Reverses / mirrors a string.
        /// </summary>
        /// <param name = "value">The string to be reversed.</param>
        /// <returns>The reversed string</returns>
        public static string Reverse(this string value)
        {
            if (string.IsNullOrEmpty(value) || (value.Length == 1))
                return value;

            var chars = value.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        /// <summary>
        /// 	Repeats the specified string value as provided by the repeat count.
        /// </summary>
        /// <param name = "value">The original string.</param>
        /// <param name = "repeatCount">The repeat count.</param>
        /// <returns>The repeated string</returns>
        public static string Repeat(this string value, int repeatCount)
        {
            if (value.Length == 1)
                return new string(value[0], repeatCount);

            var sb = new StringBuilder(repeatCount * value.Length);
            while (repeatCount-- > 0)
                sb.Append(value);
            return sb.ToString();
        }

        /// <summary>
        /// 	Extracts all digits from a string.
        /// </summary>
        /// <param name = "value">string containing digits to extract</param>
        /// <returns>
        /// 	All digits contained within the input string
        /// </returns>
        public static string ExtractDigits(this string value)
        {
            return value.Where(Char.IsDigit).Aggregate(new StringBuilder(value.Length), (sb, c) => sb.Append(c)).ToString();
        }

        /// <summary>
        /// 	Gets the string before the given string parameter.
        /// </summary>
        /// <param name = "value">The default value.</param>
        /// <param name = "x">The given string parameter.</param>
        /// <returns></returns>
        public static string GetBefore(this string value, string x)
        {
            var xPos = value.IndexOf(x);
            return xPos == -1 ? string.Empty : value.Substring(0, xPos);
        }

        /// <summary>
        /// 	Gets the string between the given string parameters.
        /// </summary>
        /// <param name = "value">The source value.</param>
        /// <param name = "x">The left string sentinel.</param>
        /// <param name = "y">The right string sentinel</param>
        /// <returns></returns>
        public static string GetBetween(this string value, string x, string y)
        {
            var xPos = value.IndexOf(x);
            var yPos = value.LastIndexOf(y);

            if (xPos == -1 || xPos == -1)
                return string.Empty;

            var startIndex = xPos + x.Length;
            return startIndex >= yPos ? string.Empty : value.Substring(startIndex, yPos - startIndex).Trim();
        }

        /// <summary>
        /// 	Gets the string after the given string parameter.
        /// </summary>
        /// <param name = "value">The default value.</param>
        /// <param name = "x">The given string parameter.</param>
        /// <returns></returns>
        public static string GetAfter(this string value, string x)
        {
            var xPos = value.LastIndexOf(x);

            if (xPos == -1)
                return string.Empty;

            var startIndex = xPos + x.Length;
            return startIndex >= value.Length ? string.Empty : value.Substring(startIndex).Trim();
        }

        /// <summary>
        /// 	Remove any instance of the given character from the current string.
        /// </summary>
        /// <param name = "value">
        /// 	The input.
        /// </param>
        /// <param name = "removeCharc">
        /// 	The remove char.
        /// </param>
        public static string Remove(this string value, params char[] removeCharc)
        {
            var result = value;
            if (!string.IsNullOrEmpty(result) && removeCharc != null)
                Array.ForEach(removeCharc, c => result = result.Remove(c.ToString()));

            return result;
        }

        /// <summary>
        /// Remove any instance of the given string pattern from the current string.
        /// </summary>
        /// <param name="value">The input.</param>
        /// <param name="strings">The strings.</param>
        /// <returns></returns>
        public static string Remove(this string value, params string[] strings)
        {
            return strings.Aggregate(value, (current, c) => current.Replace(c, string.Empty));
        }

        /// <summary>Uppercase First Letter</summary>
        /// <param name = "value">The string value to process</param>
        public static string FirstLetterUp(this string value)
        {
            if (value == null) return null;
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;

            char[] valueChars = value.ToCharArray();
            valueChars[0] = Char.ToUpper(valueChars[0]);

            return new string(valueChars);
        }

        /// <summary>
        /// Returns the left part of the string.
        /// </summary>
        /// <param name="value">The original string.</param>
        /// <param name="characterCount">The character count to be returned.</param>
        /// <returns>The left part</returns>
        public static string Left(this string value, int characterCount)
        {
            if (value == null || characterCount >= value.Length)
                return value;
            return value.Substring(0, characterCount);
        }

        /// <summary>
        /// Returns the Right part of the string.
        /// </summary>
        /// <param name="value">The original string.</param>
        /// <param name="characterCount">The character count to be returned.</param>
        /// <returns>The right part</returns>
        public static string Right(this string value, int characterCount)
        {
            if (value == null || characterCount >= value.Length)
                return value;
            return value.Substring(value.Length - characterCount);
        }

        /// <summary>
        /// Removes Prefix from the end of the string.
        /// </summary>
        /// <param name="value">The original string.</param>
        /// <param name="prefix">The prefix to be removed.</param>
        /// <returns>The cut string</returns>
        public static string RemovePrefix(this string value, string prefix)
        {
            if (value.StartsWith(prefix))
                return value.Substring(prefix.Length);
            return value;
        }

        /// <summary>
        /// Removes Suffix from the end of the string.
        /// </summary>
        /// <param name="value">The original string.</param>
        /// <param name="suffix">The suffix to be removed.</param>
        /// <returns>The cut string</returns>
        public static string RemoveSuffix(this string value, string suffix)
        {
            if (value.EndsWith(suffix))
                return value.Substring(0, value.Length - suffix.Length);
            return value;
        }

        /// <summary>Convert text's case to a title case</summary>
        /// <remarks>UppperCase characters is the source string after the first of each word are lowered, unless the word is exactly 2 characters</remarks>
        public static string ToTitleCase(this string value, CultureInfo culture = null)
        {
            return (culture ?? CultureInfo.CurrentCulture).TextInfo.ToTitleCase(value);
        }

        /// <summary>
        /// Return the string with the leftmost number_of_characters characters removed.
        /// </summary>
        /// <param name="str">The string being extended</param>
        /// <param name="number_of_characters">The number of characters to remove.</param>
        /// <returns></returns>
        public static string CutLeft(this string str, int number_of_characters)
        {
            if (str.Length <= number_of_characters) return "";
            return str.Substring(number_of_characters);
        }

        /// <summary>
        /// Return the string with the rightmost number_of_characters characters removed.
        /// </summary>
        /// <param name="str">The string being extended</param>
        /// <param name="number_of_characters">The number of characters to remove.</param>
        /// <returns></returns>
        public static string CutRight(this string str, int number_of_characters)
        {
            if (str.Length <= number_of_characters) return "";
            return str.Substring(0, str.Length - number_of_characters);
        }

        /// <summary>
        /// Convert a byte array into a hexadecimal string representation.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToHexstring(this byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes)
                result += " " + b.ToString("X").PadLeft(2, '0');

            if (result.Length > 0) result = result.Substring(1);
            return result;
        }

        /// <summary>
        /// Convert this string containing hexadecimal into a byte array.
        /// </summary>
        /// <param name="str">The hexadecimal string to convert.</param>
        /// <returns></returns>
        public static byte[] HexstringToBytes(this string str)
        {
            str = str.Replace(" ", "");
            int max_byte = str.Length / 2 - 1;
            var bytes = new byte[max_byte + 1];
            for (int i = 0; i <= max_byte; i++)
                bytes[i] = byte.Parse(str.Substring(2 * i, 2), NumberStyles.AllowHexSpecifier);

            return bytes;
        }

        public static string ToBase64(this string source)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
        }

        public static string SplitCamelCase(this string source)
        {
            if (source.Length < 2)
                return source;

            string result = source[0].ToString();
            for (int i = 1; i < source.Length; i++)
            {
                if (char.IsUpper(source[i]) && !char.IsUpper(source[i - 1]))
                    result += " ";
                result += source[i].ToString();
            }
            return result;
        }

        public static string CommonString(string[] stringArray)
        {
            string result = stringArray.FirstOrDefault();
            foreach (string aItem in stringArray)
                result = CommonString(result, aItem);
            return result;
        }

        public static string CommonString(string stringA, string stringB)
        {
            int size = stringA.Length;
            if (stringB.Length < size)
                size = stringB.Length;

            int i = 0;
            while (i < size && stringA[i] == stringB[i])
                i++;

            return stringA.Substring(0, i);
        }

        public static string Transliterate(string rusText)
        {
            char[] AllowedChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890 -.".ToArray();

            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                { "й", "j" }, { "ц", "ts" }, { "у", "u" }, { "к", "k" }, { "е", "e" }, { "ё", "jo" }, { "н", "n" }, { "г", "g" }, { "ш", "sh" }, { "щ", "sh" }, { "з", "z" }, { "х", "h" }, { "ъ", "" }, { "ф", "f" }, { "ы", "i" }, { "в", "v" }, { "а", "a" }, { "п", "p" }, { "р", "r" }, { "о", "o" }, { "л", "l" }, { "д", "d" }, { "ж", "zh" }, { "э", "e" }, { "я", "ja" }, { "ч", "ch" }, { "с", "s" }, { "м", "m" }, { "и", "i" }, { "т", "t" }, { "ь", "" }, { "б", "b" }, { "ю", "u" },
                { "Й", "J" }, { "Ц", "Ts" }, { "У", "U" }, { "К", "K" }, { "Е", "E" }, { "Ё", "Jo" }, { "Н", "N" }, { "Г", "G" }, { "Ш", "Sh" }, { "Щ", "Sh" }, { "З", "Z" }, { "Х", "H" }, { "Ъ", "" }, { "Ф", "F" }, { "Ы", "I" }, { "В", "V" }, { "А", "A" }, { "П", "P" }, { "Р", "R" }, { "О", "O" }, { "Л", "L" }, { "Д", "D" }, { "Ж", "Zh" }, { "Э", "E" }, { "Я", "Ja" }, { "Ч", "Ch" }, { "С", "S" }, { "М", "M" }, { "И", "I" }, { "Т", "T" }, { "Ь", "" }, { "Б", "B" }, { "Ю", "U" }
            };

            foreach (KeyValuePair<string, string> kvp in dictionary)
                rusText = rusText.Replace(kvp.Key, kvp.Value);

            string result = new string(rusText.Where(s => AllowedChars.Contains(s)).ToArray());

            //  result = result.Trim().Replace(".", "-").Replace(" ", "-");

            while (result.Contains("--"))
                result = result.Replace("--", "-");
            return result;
        }

        public static string UrlTransliterate(string rusText)
        {
            char[] AllowedChars = "qwertyuiopasdfghjklzxcvbnm1234567890 ".ToArray();

            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                { "й", "j" },
                { "ц", "c" },
                { "у", "u" },
                { "к", "k" },
                { "е", "e" },
                { "ё", "yo" },
                { "н", "n" },
                { "г", "g" },
                { "ш", "sh" },
                { "щ", "shch" },
                { "з", "z" },
                { "х", "h" },
                { "ъ", "" },
                { "ф", "f" },
                { "ы", "y" },
                { "в", "v" },
                { "а", "a" },
                { "п", "p" },
                { "р", "r" },
                { "о", "o" },
                { "л", "l" },
                { "д", "d" },
                { "ж", "zh" },
                { "э", "eh" },
                { "я", "ya" },
                { "ч", "ch" },
                { "с", "s" },
                { "м", "m" },
                { "и", "i" },
                { "т", "t" },
                { "ь", "" },
                { "б", "b" },
                { "ю", "yu" }
            };


            Dictionary<string, string> extra = new Dictionary<string, string>()
            {
                { "кх", "kkh" },
                { "зх", "zkh" },
                { "цх", "ckh" },
                { "сх", "skh" },
                { "ех", "ekh" },
                { "шх", "shkh" },
                { "щх", "shchkh" },
                { "хх", "khhkh" },
                { "жх", "zhkh" },
                { "эх", "ehkh" },
                { "чх", "chkh" }
            };

            rusText = rusText.ToLower();

            foreach (KeyValuePair<string, string> kvp in extra)
                rusText = rusText.Replace(kvp.Key, kvp.Value);

            foreach (KeyValuePair<string, string> kvp in dictionary)
                rusText = rusText.Replace(kvp.Key, kvp.Value);

            string result = new string(rusText.Select(s => AllowedChars.Contains(s) ? s : '-').ToArray());// rusText.Where(s => AllowedChars.Contains(s)).ToArray());

            result = result.Trim().Replace(".", "-").Replace(" ", "-");

            while (result.Contains("--"))
                result = result.Replace("--", "-");

            return result.Trim('-');
        }
    }
}
