// ====================== assingment 1 ======================


using System;
using System.Collections.Generic;
using System.Linq;

public class Class1
{

public class MathOperators
{
    public static double Mean(List<int> data)
    {
        double sum = 0;
        foreach (var x in data)
            sum += x;

        return sum / data.Count;
    }

    public static int Mode(List<int> data)
    {
        List<int> sorted = data.OrderBy(x => x).ToList();

        int mode = sorted[0];
        int maxCount = 1;
        int currentCount = 1;

        for (int i = 1; i < sorted.Count; i++)
        {
            if (sorted[i] == sorted[i - 1])
                currentCount++;
            else
                currentCount = 1;

            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                mode = sorted[i];
            }
        }

        return mode;
    }

    public static double Median(List<int> data)
    {
        List<int> sorted = data.OrderBy(x => x).ToList();
        int n = sorted.Count;

        if (n % 2 == 0)
            return (sorted[n / 2 - 1] + sorted[n / 2]) / 2.0;
        else
            return sorted[n / 2];
    }

    public static double Variance(List<int> data)
    {
        double mean = Mean(data);
        double sum = 0;

        foreach (var x in data)
            sum += Math.Pow(x - mean, 2);

        return sum / data.Count;
    }

    public static double StandardDeviation(List<int> data)
    {
        return Math.Sqrt(Variance(data));
    }

    public static double Percentile(List<int> data, double p)
    {
        List<int> sorted = data.OrderBy(x => x).ToList();

        double index = (p / 100.0) * (sorted.Count - 1);

        int lower = (int)Math.Floor(index);
        int upper = (int)Math.Ceiling(index);

        if (lower == upper)
            return sorted[lower];

        return sorted[lower] + (sorted[upper] - sorted[lower]) * (index - lower);
    }

    public static double P20(List<int> data)
    {
        return Percentile(data, 20);
    }

    public static double P50(List<int> data)
    {
        return Percentile(data, 50);
    }

    public static double SecondQuartile(List<int> data)
    {
        return Median(data);
    }

    public static double ThirdQuartile(List<int> data)
    {
        return Percentile(data, 75);
    }

    public static double Range(List<int> data)
    {
        List<int> sorted = data.OrderBy(x => x).ToList();
        return sorted.Last() - sorted.First();
    }

    public static double InterquartileRange(List<int> data)
    {
        return ThirdQuartile(data) - Percentile(data, 25);
    }

    public static double SumOfDeviations(List<int> data)
    {
        double mean = Mean(data);
        double sum = 0;

        foreach (var x in data)
            sum += (x - mean);

        return sum;
    }
}



    static void Main()
    {
        List<int> numbers = new List<int> { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };
        
        Console.WriteLine("Mean: " + MathOperators.Mean(numbers));
        Console.WriteLine("Mode: " + MathOperators.Mode(numbers));
        Console.WriteLine("Median: " + MathOperators.Median(numbers));
        Console.WriteLine("Variance: " + MathOperators.Variance(numbers));
        Console.WriteLine("P20: " + MathOperators.P20(numbers));
        Console.WriteLine("P50: " + MathOperators.P50(numbers));
        Console.WriteLine("Third Quartile (Q3): " + MathOperators.ThirdQuartile(numbers));
        Console.WriteLine("Second Quartile (Q2): " + MathOperators.SecondQuartile(numbers));
        Console.WriteLine("Range: " + MathOperators.Range(numbers));
        Console.WriteLine("Interquartile Range (IQR): " + MathOperators.InterquartileRange(numbers));
        Console.WriteLine("Standard Deviation: " + MathOperators.StandardDeviation(numbers));
        Console.WriteLine("Summation of Deviations: " + MathOperators.SumOfDeviations(numbers));



    }
}