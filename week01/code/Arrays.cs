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
        // Plan: 
        // 1. Initialize an array of doubles with the specified length to hold the multiples.
        // 2. Loop through the array indices from 0 up to length - 1.
        // 3. Calculate each multiple by multiplying the number by (i + 1) and store it in the array.
        // 4. Return the populated array of multiples.

        // here we initialize an array of doubles with the specified length to hold the multiples of the given number
        var multiples = new double[length];
        // we set the limit of the loop to the length of the array, so we can fill each index with the appropriate multiple
        for (int i = 0; i < length; i++)
        {
            // here we calculate the multiple by multiplying the number by (i + 1) because array indices start at 0, but we want to start with the first multiple (which is the number itself)
            multiples[i] = number * (i + 1);
        }
        // and here we return the filled array of multiples
        return multiples;
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
        // Plan: 
        // 1. Extract the last 'amount' of elements using GetRange to move them to the front.
        // 2. Insert that extracted range at the beginning of a new list.
        // 3. Loop through the remaining elements of the original list and add them to the end.
        // 4. Clear the original list and add all the rotated values back to it.

        // here we create a new list to hold the rotated values
        List<int> rotated = new();

        // here we get the last 'amount' of elements from the original list to be moved to the front
        var range = data.GetRange(data.Count - amount, amount);

        // here we insert the range of elements at the beginning of the rotated list
        rotated.InsertRange(0, range);

        // here we loop through the original list, stopping before the last 'amount' of elements, to add the remaining elements to the rotated list
        for (int i = 0; i < data.Count - amount; i++)
        {
            // here we add each remaining element to the end of the rotated list so they come after the front elements
            rotated.Add(data[i]);
        }

        // here we clear the original list and add all the rotated values
        data.Clear();
        data.AddRange(rotated);
    }
}
