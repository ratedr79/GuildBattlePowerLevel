using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace GBPowerLevel.Extensions
{
    public static class Extensions
    {
        public static string OnlyNumbers(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            else if (value == "5 Star")
            {
                return "0";
            }
            else
            {
                string pattern = "[^0-9]";

                string onlyNumbers = Regex.Replace(value, pattern, "");

                return onlyNumbers;
            }
        }

        public static double GetMultipler(this string value, double ob0 = 1.0, double ob6 = 1.0, double ob10 = 1.0)
        {
            var level = value.OnlyNumbers();

            if (!string.IsNullOrEmpty(level))
            {
                if (int.Parse(level) > 9)
                {
                    return ob10;
                }
                else if (int.Parse(level) > 5)
                {
                    return ob6;
                }
                else
                {
                    return ob0;
                }
            }

            return 0.0;
        }

        public static bool IsOwned(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            else if (value.ToLower().Trim() == "own")
            {
                return true;
            }
            else
            {
                var level = value.OnlyNumbers();

                return !string.IsNullOrEmpty(level);
            }
        }
    }
}
