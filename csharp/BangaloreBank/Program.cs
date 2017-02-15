using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangaloreBank
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits;

            Console.WriteLine("Enter a bank account number: ");
            string bankAccountNumber = Console.ReadLine();

            digits = new int[bankAccountNumber.Length];

            //String to integer array
            for (int i = 0; i < bankAccountNumber.Length; i++)
            {
                digits[i] = int.Parse(bankAccountNumber.ElementAt(i)+"");
                if(digits[i] == 0)
                {
                    digits[i] = 10;
                }
            }

            int leftIndex = digits.Min();
            int rightIndex = digits.Max();

           

            int currentDigit, timeTaken = 0, closeKey;

            for(int i = 0; i < digits.Length; i++)
            {
                currentDigit = digits[i];

                closeKey = FindCloseKey(rightIndex, currentDigit, leftIndex);

                timeTaken += Math.Abs(closeKey - currentDigit) + 1; //+1 second for key press

                if (closeKey == rightIndex)
                    rightIndex = currentDigit;
                else
                    leftIndex = currentDigit;

            }

            Console.WriteLine("It would take " + timeTaken + " seconds to type the bank account");


            Console.Read();
            

        }

        private static int FindCloseKey(int rightIndex, int currentDigit, int leftIndex)
        {
            return (Math.Abs(currentDigit - rightIndex) < Math.Abs(leftIndex - currentDigit)) ? rightIndex : leftIndex;
        }
    }
}
