using System;

namespace no_whose_prime_factors_are_2_3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var answer = s.NthUglyNumber(10);
            Console.WriteLine(answer);
        }
    }

    public class Solution
    {
        public int NthUglyNumber(int n)
        {
            // the main challenge here is to avoid taking the duplicate element multiple times
            // e.g - 6, is prime factor of 2 and 3, here we need to consider one one 6
            var result = new int[n];
            int idx2 = 0, idx3 = 0, idx5 = 0;
            result[0] = 1;
            for (int i = 1; i < n; i++)
            {
                // min of the 3 sequences is the ith UglyNumber
                result[i] = Math.Min(result[idx5] * 5, Math.Min(result[idx2] * 2, result[idx3] * 3));
                // if the factor is matches with 2s factor update the index
                if (result[i] == result[idx2] * 2) idx2++;
                // if the factor is matches with 3s factor update the index
                if (result[i] == result[idx3] * 3) idx3++;
                // if the factor is matches with 5s factor update the index
                if (result[i] == result[idx5] * 5) idx5++;
            }

            return result[n - 1];
        }
    }
}
