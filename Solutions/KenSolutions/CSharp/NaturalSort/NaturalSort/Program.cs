namespace NaturalSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static string[] SortNaturally(string[] unsorted)
        {
            string[] sorted = SortUnsorted(unsorted);
            return sorted;
        }

        private static string[] SortUnsorted(string[] unsorted)
        {
            var sortedArray = unsorted;
            Array.Sort(sortedArray, CompareStringsNaturally);
            return sortedArray;
        }

        public static int CompareStringsNaturally(string a, string b)
        {
            // if a < b return -1
            // if a == b return 0
            // if a > b return 1
            string aLeadingChars = ExtractLeadingNonNumericChars(a);
            string bLeadingChars = ExtractLeadingNonNumericChars(b);
            int aNumber = ExtractFirstNumber(a);
            int bNumber = ExtractFirstNumber(b);
            if (aNumber == -1)
            {
                if (bNumber == -1)
                {
                    return aLeadingChars.CompareTo(bLeadingChars);

                }
                else
                {
                    return 1;
                }
            }
            if (bNumber == -1)
            {
                if (aNumber == -1)
                {
                    return aLeadingChars.CompareTo(bLeadingChars);

                }
                else
                {
                    return -1;
                }
            }
            else if (string.IsNullOrEmpty(aLeadingChars))
            {
                if (string.IsNullOrEmpty(bLeadingChars))
                {
                    return aNumber.CompareTo(bNumber);
                }
                else
                {
                    return -1; // a is a number, b is not, a < b
                }
            }
            else if (string.IsNullOrEmpty(bLeadingChars))
            {
                if (string.IsNullOrEmpty(aLeadingChars))
                {
                    return aNumber.CompareTo(bNumber);
                }
                else
                {
                    return 1; // b is a number, a is not, b < a
                }
            }
            else
            {
                var compareVal = aLeadingChars.CompareTo(bLeadingChars);
                switch (compareVal)
                {
                    case -1: // aLeadingChars < bLeadingChars
                        return -1;
                        break;
                    case 0: // aLeadingChars == bLeadingChars
                        return aNumber.CompareTo(bNumber);
                        break;
                    case 1:  // aLeadingChars > bLeadingChars
                        return 1;
                        break;
                    default:
                        break;
                }
                return a.CompareTo(b);
            }


        }

        public static string ExtractLeadingNonNumericChars(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            int index = 0;
            while (index < input.Length && !char.IsDigit(input[index]))
            {
                index++;
            }

            return input.Substring(0, index);
        }

        public static int ExtractFirstNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
                return -1; // or throw an exception, depending on your error handling strategy

            int startIndex = -1;
            int endIndex = -1;

            // Find the start of the first number
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    startIndex = i;
                    break;
                }
            }

            // If no digit was found, return -1 (or another sentinel value)
            if (startIndex == -1)
                return -1;

            // Find the end of the first number
            for (int i = startIndex; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    endIndex = i;
                    break;
                }
            }

            // If the number continues to the end of the string
            if (endIndex == -1)
                endIndex = input.Length;

            string numberString = input.Substring(startIndex, endIndex - startIndex);

            // Parse the extracted string to an integer
            if (int.TryParse(numberString, out int result))
                return result;
            else
                return -1; // This should never happen if our extraction logic is correct
        }
    }
}