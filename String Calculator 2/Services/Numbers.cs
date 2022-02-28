using String_Calculator_2.Interfaces;

namespace String_Calculator_2
{
    public class Numbers
    {
        private IErrorHandling _errorHandling;
        
        bool isNumeric= true;
        public Numbers(IErrorHandling errorHandling)
        {
             _errorHandling = errorHandling;
        }

        public List<int> ConvertStringArrayNumberToInt(string[] numbers)
        {
            var numbersList = new List<int>();
            var numbersToAdd = 0;
           
            foreach (var number in numbers)
            {
                isNumeric = int.TryParse("number", out int _);

                if (!isNumeric)
                {
                    numbersToAdd = ConvertCharacterToNumber(char.Parse(number));
                }
                else
                {
                    numbersToAdd = Math.Abs(Convert.ToInt32(numbers));
                }
                
                numbersList.Add(numbersToAdd);
            }

            return numbersList;
        }

        public void NumbersBiggerThanOneThousand(List<int> numbersList)
        {
            var bigNumbers = "";

            foreach (var number in numbersList)
            {
                if (number > 1000)
                {
                    bigNumbers += number + " ";
                }
            }

            if (!string.IsNullOrEmpty(bigNumbers))
            {
                _errorHandling.ThrowException("You can't subtract numbers greater than 1000 :" + bigNumbers);
            }
        }

        public int ConvertCharacterToNumber(char alphabet)
        {
            var number = char.ToUpper(alphabet) - 65;

            if(number > 9)
            {
                return 0;
            }

            return Convert.ToInt32(number);
        }
    }
}
