using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<int> a, List<int> b)
    {
        // Find the maximum value in array b
        int maxB = b.Max();

        // Find potential factors of maxB
        List<int> potentialFactors = new List<int>();
        for (int i = 1; i <= maxB; i++)
        {
            bool isFactor = true;
            foreach (int num in b)
            {
                if (num % i != 0)
                {
                    isFactor = false;
                    break;
                }
            }
            if (isFactor)
                potentialFactors.Add(i);
        }

        // Count valid numbers that are divisible by all elements of a
        int count = 0;
        foreach (int num in potentialFactors)
        {
            bool isValid = true;
            foreach (int divisor in a)
            {
                if (num % divisor != 0)
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
                count++;
        }

        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}
