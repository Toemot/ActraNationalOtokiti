namespace ActraNationalOtokiti
{
    public class QuestionTwo
    {
        //Time complexity of 0(n)
        public void ProductOfDigits()
        {
            const int MaxSingleDigit = 9;
            Console.Write("Please enter a number: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || !IsNumeric(input))
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }
            int number = int.Parse(input);
            int steps = 0;
            while (number > MaxSingleDigit)
            {
                int product = input.Select(c => c - '0').Aggregate((a, b) => a * b);
                number = product;
                input = product.ToString();
                Console.WriteLine(number);
                steps++;
            }
            Console.WriteLine($"Total Steps: {steps}");
        }

        static bool IsNumeric(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
