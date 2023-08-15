using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActraNationalOtokiti
{
    public class QuestionThree
    {
        public void ProductofLargerNumbers()
        {
            Console.Write("Please enter a number: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || !IsNumeric(input))
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            int steps = 0;
            while (input.Length > 1)
            {
                double logProduct = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    logProduct += Math.Log10(input[i] - '0');
                }
                int product = (int)Math.Pow(10, logProduct);
                input = product.ToString();

                Console.WriteLine(input);
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
