using String_Calculator_2.Interfaces;

namespace String_Calculator_2
{
    public class StringCalculator
    {
        private readonly INumbers _numbers;
        private readonly ICalculations _calculations;
        private readonly IDelimiters _delimiter;
        private readonly ISplit _split;

        public StringCalculator(ICalculations calculations, INumbers numbers, IDelimiters delimiters, ISplit split)
        {
            _calculations = calculations;
            _numbers = numbers;
            _delimiter = delimiters;
            _split = split;
        }

        public int Subtract(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var difference = Calculation(numbers);

            return difference;
        }

        public int Calculation(string numbers)
        {
            var delimiters = _delimiter.GetDelimiters(numbers);
            var numbersArray = _split.GetNumbers(numbers, delimiters);
            var numbersList = _numbers.ConvertStringNumberToInt(numbersArray);

            return _calculations.PerformCalculation(numbersList);
        }
    }
}