using System.Text.RegularExpressions;

namespace ActivationCodeValidator_LIB
{
    public class ActivationCode
    {
        public static bool CheckCodeValidity(string code)
        {
            code = code.ToUpper();

            if (code.Length != 12 && code.Length != 14) return false;
            string[] parts = code.Split("-");

            if (parts.Length != 3)
            {
                int length = parts[0].Length;
                for (int i = 0; i < parts.Length; i++)
                {
                    if (parts[i].Length != length) return false;
                }
            }

            if (!code.Contains("G")) return false;
            if (!code.Contains("C")) return false;

            int jOccurences = 0;
            foreach(var c in code)
            {
                if (c.ToString() == "J") jOccurences++;
            }

            if (jOccurences != 1) return false;

            if (!code.Any(char.IsDigit)) return false;

            if (!Regex.IsMatch(code, @"^[A-Z0-9-]+$")) return false;

            return true;
        }
    }
}
