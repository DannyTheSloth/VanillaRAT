namespace VanillaRat.Classes
{
    internal class Functions
    {
        //Substring Function By Artful Hacker
        public static string GetSubstringByString(string a, string b, string c)
        {
            try
            {
                return c.Substring(c.IndexOf(a) + a.Length, c.IndexOf(b) - c.IndexOf(a) - a.Length);
            }
            catch
            {
            }

            return "";
        }

        //From Quasar Rat
        public static string RemoveLastChars(string input, int amount = 2)
        {
            if (input.Length > amount)
                input = input.Remove(input.Length - amount);
            return input;
        }
    }
}