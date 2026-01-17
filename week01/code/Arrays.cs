

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
        // Step 1: Create an array to hold 'length' numbers
        double[] multiples = new double[length];

        // Step 2: Loop through indices from 0 to length-1
        for (int i = 0; i < length; i++)
        {
            // Step 3: Compute each multiple
            // The first multiple is number * 1, second is number * 2, etc.
            multiples[i] = number * (i + 1);
        }

        // Step 4: Return the array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by 'amount'.
    /// For example, if data = {1,2,3,4,5,6,7,8,9} and amount = 3,
    /// the result will be {7,8,9,1,2,3,4,5,6}.
    /// The value of amount will be in the range 1 to data.Count inclusive.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: If amount == data.Count, rotation results in the same list
        if (amount == data.Count)
            return;

        // Step 2: Slice the list into two parts
        // - last 'amount' elements to move to the front
        List<int> endPart = data.GetRange(data.Count - amount, amount);

        // - the first 'data.Count - amount' elements will follow
        List<int> startPart = data.GetRange(0, data.Count - amount);

        // Step 3: Clear the original list
        data.Clear();

        // Step 4: Add the rotated parts back
        data.AddRange(endPart);   // add last 'amount' elements first
        data.AddRange(startPart); // then add the remaining
    }
}
