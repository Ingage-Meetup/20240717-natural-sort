using System.Text.RegularExpressions;

namespace NaturalSortingC3
{
    public class Program
    {
        public class ParseResult
        {
           public string? LeadingChars { get; set; }
           public int Number { get; set; }
           public string? TrailingChars { get; set; }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static string[] SortNaturally(string[] unsorted, Boolean sortDescending = false)
        {
            string[] sorted = SortUnsorted(unsorted);
            if (sortDescending)
            {
                Array.Reverse(sorted);
            }
            return sorted;
        }

        private static string[] SortUnsorted(string[] unsorted)
        {
            var sortedArray = unsorted;
            Array.Sort(sortedArray, CompareStringsNaturally);
            return sortedArray;
        }

        public static ParseResult? ParseString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            string pattern = @"^(\D*)(\d*)(.*)";
            Match match = Regex.Match(input, pattern);
            ParseResult pr = new ParseResult();
            pr.LeadingChars = match.Groups[1].Value;
            pr.Number = string.IsNullOrEmpty(match.Groups[2].Value) ? -1: int.Parse(match.Groups[2].Value);
            pr.TrailingChars = string.IsNullOrEmpty(match.Groups[3].Value) ? "" : match.Groups[3].Value;

            return pr;

        }


        public static int CompareStringsNaturally(string? a, string? b)
        {
            // if a < b return -1
            // if a == b return 0
            // if a > b return 1
            var aLeadingChars = ParseString(a);
            var bLeadingChars = ParseString(b);

            if (aLeadingChars == null && bLeadingChars == null)
                return 0;

            if (aLeadingChars == null)
            {
                return -1;
            }

            if (bLeadingChars == null)
            {
                return 1;
            }

            if (aLeadingChars.LeadingChars != bLeadingChars.LeadingChars)
            {
                return string.Compare(aLeadingChars.LeadingChars, bLeadingChars.LeadingChars);
            }

            if (aLeadingChars.Number != bLeadingChars.Number)
            {
                return aLeadingChars.Number.CompareTo(bLeadingChars.Number);
            }

            return CompareStringsNaturally(aLeadingChars.TrailingChars, bLeadingChars.TrailingChars);

        }

    }
}
