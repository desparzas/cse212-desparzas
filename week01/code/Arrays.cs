public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of size 'length' to store the multiples
        double[] result = new double[length];

        // Step 2: Use a loop to fill the array with multiples of 'number'
        // For example, if number = 3 and length = 5 → {3, 6, 9, 12, 15}
        for (int i = 0; i < length; i++)
        {
            // Step 3: Each element will be (i + 1) * number
            result[i] = (i + 1) * number;
        }

        // Step 4: Return the filled array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Get the last 'amount' elements (the segment to be moved to the front)
        List<int> tail = data.GetRange(data.Count - amount, amount);

        // Step 2: Remove those 'amount' elements from the end of the original list
        data.RemoveRange(data.Count - amount, amount);

        // Step 3: Insert the extracted segment at the beginning of the list
        data.InsertRange(0, tail);

        // Note: This modifies the original list directly, as required
    }

}
