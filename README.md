# Finding Integers Between Two Arrays

## Problem Description

You are given two arrays of integers. Determine all integers that satisfy the following two conditions:

1. The elements of the first array are all factors of the integer being considered.
2. The integer being considered is a factor of all elements of the second array.

These numbers are referred to as being between the two arrays. Determine how many such numbers exist.

### Example

**Input:**

```

a = [2, 4]
b = [16, 32, 96]

```

**Output:**

`3`

**Explanation:**

There are three numbers between the arrays: 4, 8, and 16.

- 2 and 4 divide evenly into 4, 8, 12, and 16.
- 4, 8, and 16 divide evenly into 16, 32, and 96.

Thus, 4, 8, and 16 are the only three numbers for which each element of `a` is a factor and each is a factor of all elements of `b`.

## Function Signature

```csharp
public static int getTotalX(List<int> a, List<int> b)
```
## Solution
Here's the implementation of the getTotalX function:
``` csharp
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
```
## Example Usage
``` csharp
public static void Main(string[] args)
{
    List<int> arr = new List<int> { 2, 4 };
    List<int> brr = new List<int> { 16, 32, 96 };

    int total = getTotalX(arr, brr);
    Console.WriteLine(total); // Output: 3
}
```
## How to Run
1. Copy the getTotalX function into your project.
2. Call the function with the appropriate parameters.
3. Print or use the result as needed.
## Contributing
If you have suggestions for improving this implementation, feel free to open an issue or submit a pull request.
