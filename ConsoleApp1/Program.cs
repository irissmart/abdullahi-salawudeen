using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string EvadingSolution(int[] A, int[] B, int[] K)
        {

            string response = string.Empty;
            int returnValue = 1;

            int lengthOfB = B.Length;
            foreach(var item in K)
            {
                if (item < 0 || item > lengthOfB)
                {
                    return "Invalid value for K";
                    break;
                }
                if (A[item] == 0 && B[item] == 1)
                    returnValue *= 3;
                if (A[item] == 1 && B[item] == 1)
                    returnValue *= 3;
                if (A[item] == 1 && B[item] == 2)
                    returnValue *= 3;
                if (A[item] == 3 && B[item] == 4)
                    returnValue *= 5;

                response = returnValue.ToString();
            }

            return response;

        }
    }

}


