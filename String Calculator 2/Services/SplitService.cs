using String_Calculator_2.Interfaces;

namespace String_Calculator_2.Services
{
    public class SplitService : ISplit
    {
        string hashTags = "##";
        public string[] GetNumbers(string numbers, List<string> delimiters)
        {
            if (numbers.StartsWith(hashTags))
            {
                numbers = numbers.Substring(numbers.LastIndexOf('\n') + 1);
            }

            string[] numbersArray = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);

            return numbersArray;
        }

    }
}
