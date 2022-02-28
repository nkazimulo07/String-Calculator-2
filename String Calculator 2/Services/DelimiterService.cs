using String_Calculator_2.Interfaces;

namespace String_Calculator_2.Services
{
    public class DelimiterService : IDelimiters
    {
        const string HashTag = "#";
        const string NewLine = "\n";
        const char LeftSquareBracket = '[';
        const char RightSquareBracket = ']';
        const string SquareBrackets = "][";
        const string LeftFlag = "<";
        const string RightFlag = ">";


        public List<string> GetDelimiters(string numbers)
        {
            var delimiters = new List<string>() { ",", "\n" };
            string delimiter = "";
            string delimiterSeperators = "";

            if (numbers.Contains(HashTag))
            {
                delimiter = numbers.Substring(2, numbers.IndexOf(NewLine) - 2);

                if (numbers.StartsWith(LeftFlag))
                {
                    delimiterSeperators = numbers.Substring(0, numbers.IndexOf(HashTag));
                    delimiters.AddRange(FlagDelimiters(numbers, delimiterSeperators));
                }
                else if (delimiter.StartsWith(LeftSquareBracket) && delimiter.EndsWith(RightSquareBracket))
                {
                    delimiters.AddRange(GetMultipleDelimiters(delimiter));
                }
                else
                {
                    delimiters.Add(delimiter);
                }

            }

            return delimiters;
        }

        public List<string> GetMultipleDelimiters(string delimiter)
        {
            char[] charsToTrim = { LeftSquareBracket, RightSquareBracket };
            string cleanDelimiter = delimiter.Trim(charsToTrim);
            string[] delimiters = cleanDelimiter.Split(new string[] { SquareBrackets }, StringSplitOptions.RemoveEmptyEntries);

            return delimiters.ToList();
        }

        public List<string> FlagDelimiters(string numbers, string delimiterSeperators)
        {
            var customStartingPoint = numbers.IndexOf(HashTag) + 2;
            var customEndingPoint = numbers.IndexOf(NewLine) - 6;
            var delimiter = numbers.Substring(customStartingPoint, customEndingPoint);
            var firstDelimiterSeperator = delimiterSeperators[1].ToString();
            var lastDelimiterSeperator = delimiterSeperators[delimiterSeperators.Length - 1].ToString();
            char[] charsToTrim = { char.Parse(firstDelimiterSeperator), char.Parse(lastDelimiterSeperator) };
            string cleanDelimiter = delimiter.Trim(charsToTrim);
            string[] delimiters = cleanDelimiter.Split(new string[] { firstDelimiterSeperator, lastDelimiterSeperator }, StringSplitOptions.RemoveEmptyEntries);

            return delimiters.ToList();
        }
    }
}
