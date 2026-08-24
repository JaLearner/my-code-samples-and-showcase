namespace Rosetta_Code__3_10001th_Prime
{    
    internal class Program
    {
        //Finished on August/20/2026.
        //Find and show on this page the 10001st prime number.
        //https://rosettacode.org/wiki/10001th_prime
        //Output should be 104743.

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.ReturnAPrime(10001));
        }

        public int ReturnAPrime(int targetPrimeAmount)
        {
            int primeCounter = 0;
            int currentPrime = 0;
            int nextNumberToCheck = 1;

            while (primeCounter < targetPrimeAmount)
            {
                for (int nextModulus = nextNumberToCheck - 1; nextModulus >= 1; nextModulus--)
                {
                    //The && nextModulus != 1 part is just to deal with the prime number 2, so that 2 will return as a prime number in the next if statement, instead of the loop breaking.
                    if (nextNumberToCheck % nextModulus == 0 && nextModulus != 1)
                    {
                        break;
                    }

                    if (nextModulus == 1)
                    {
                        currentPrime = nextNumberToCheck;
                        primeCounter++;
                    }
                }
                nextNumberToCheck++;
            }
            return currentPrime;
        }
    }
}
