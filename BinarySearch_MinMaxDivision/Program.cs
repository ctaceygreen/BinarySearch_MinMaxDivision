using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int checkBlocks(int[] A, int maxSize)
    {
        int blocks = 1;
        int currentBlockSum = A[0];
        for(int i = 1; i < A.Length; i++)
        {
            if(currentBlockSum + A[i] > maxSize)
            {
                currentBlockSum = A[i];
                blocks++;
            }
            else
            {
                currentBlockSum += A[i];
            }
        }
        return blocks;

    }
    public int solution(int K, int M, int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        int lowerBound = A.Max();
        int upperBound = A.Sum();

        if(K == 1)
        {
            return upperBound;
        }
        if(K >= A.Length)
        {
            return lowerBound;
        }

        // Binary Search, by comparing 
        int bestSize = 0;
        while(lowerBound <= upperBound)
        {
            int mid = (lowerBound + upperBound) / 2;
            if(checkBlocks(A, mid) <= K)
            {
                //Then we possibly have spare blocks to minimise further. Make upperbound left of mid and set best result so far
                upperBound = mid - 1;
                bestSize = mid;
            }
            else
            {
                //Then we used too many blocks so need to try a larger size.
                lowerBound = mid + 1;
            }
        }
        return bestSize;
    }
}