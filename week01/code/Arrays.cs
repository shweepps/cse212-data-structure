using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of size 'length'
        double[] multiples = new double[length];

        // Step 2: Loop through indices from 0 to length-1
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the i-th multiple of the number
            // First multiple is number * 1, second is number * 2, etc.
            multiples[i] = number * (i + 1);
        }

        // Step 4: Return the array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by 'amount'.
    /// For example, if the data is {1,2,3,4,5,6,7,8,9} and amount is 3,
    /// the result should be {7,8,9,1,2,3,4,5,6}.
    /// The value of amount will be in the range 1 to data.Count inclusive.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Handle the case where amount == data.Count
        // Rotating by the length of the list results in the same list
        if (amount == data.Count)
            return;

        // Step 2: Split the list into two parts:
        // - the last 'amount' elements that will go to the front
        // - the first 'data.Count - amount' elements that will move to the back
        List<int> endPart = data.GetRange(data.Count - amount, amount);
        List<int> startPart = data.GetRange(0, data.Count - amount);

        // Step 3: Clear the original list and rebuild it in rotated order
        data.Clear();
        data.AddRange(endPart);   // add the last 'amount' elements first
        data.AddRange(startPart); // then add the rest
    }
}
