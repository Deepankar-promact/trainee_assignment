using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceFunction
{
    class MultiplicationClassA
    {
        protected void MultiplyBy2(ref int a)
        {
            a = a * 2;
        }
    }

    class MultiplicationClassB : MultiplicationClassA
    {
        protected void MultiplyBy3(ref int a)
        {
            a = a * 3;
        }
    }

    class MultiplicationClassC : MultiplicationClassB
    {
        protected void MultiplyBy5(ref int a)
        {
            a = a * 5;
        }
    }
    
    class Multiplication : MultiplicationClassC
    {
        static void Main(string[] args)
        {
            int initialValue = 1;
            int callACount = 0;
            int callBCount = 0;
            int callCCount = 0;
            bool numberMatched = false;

            Multiplication self = new Multiplication();
            
            Console.WriteLine("Enter a final value (It should be a factor of 2, 3 & 5):");
            int finalValue = int.Parse(Console.ReadLine());
            int tempValue = finalValue;

            while (!numberMatched)
            {
                if(tempValue % 2 == 0)
                {
                    self.MultiplyBy2(ref initialValue);
                    tempValue /= 2;
                    callACount++;
                }else if(tempValue % 3 == 0)
                {
                    self.MultiplyBy3(ref initialValue);
                    tempValue /= 3;
                    callBCount++;
                }else if(tempValue % 5 == 0)
                {
                    self.MultiplyBy5(ref initialValue);
                    tempValue /= 5;
                    callCCount++;
                }else
                {
                    break;
                }

                if (initialValue == finalValue)
                {
                    numberMatched = true;
                }
            }

            if (numberMatched)
            {
                Console.WriteLine("A's function is called: " + callACount);
                Console.WriteLine("B's function is called: " + callBCount);
                Console.WriteLine("C's fuSnction is called: " + callCCount);
            }else
            {
                Console.WriteLine("The number given is not a factor of 2, 3, 5");
            }

            Console.Read();
        }
    }
}
