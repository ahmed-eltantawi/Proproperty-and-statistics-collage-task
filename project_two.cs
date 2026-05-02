using System;
using System.Collections.Generic;
using System.Linq;

public class OutlierDetector
{
    public static double Percentile(List<int> data, double p)
    {
        var sorted = data.OrderBy(x => x).ToList();

        double index = (p / 100.0) * (sorted.Count - 1);
        int lower = (int)Math.Floor(index);
        int upper = (int)Math.Ceiling(index);

        if (lower == upper)
            return sorted[lower];

        return sorted[lower] + (sorted[upper] - sorted[lower]) * (index - lower);
    }

    public static void CheckOutliers(List<int> data)
    {
        var sorted = data.OrderBy(x => x).ToList();

        double Q1 = Percentile(sorted, 25);
        double Q3 = Percentile(sorted, 75);
        double IQR = Q3 - Q1;

        double lowerBound = Q1 - 1.5 * IQR;
        double upperBound = Q3 + 1.5 * IQR;

        Console.WriteLine($"Lower Bound: {lowerBound}");
        Console.WriteLine($"Upper Bound: {upperBound}");
        Console.WriteLine();

        foreach (var x in data)
        {
            if (x < lowerBound || x > upperBound)
                Console.WriteLine($"=========\n{x} --------> Outlier\n=========");
            else
                Console.WriteLine($"{x} -> Normal");
        }
    }
}

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>
        {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110
        };

        OutlierDetector.CheckOutliers(numbers);
    }
}