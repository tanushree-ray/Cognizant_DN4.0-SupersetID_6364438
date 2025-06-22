using System;

class FinancialForecast
{
    static void Main()
    {
        Console.WriteLine("Financial Forecast Tool-");

        Console.Write("Enter initial investment amount: ");
        double currentValue = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter annual growth rate (in %): ");
        double growthRatePercent = Convert.ToDouble(Console.ReadLine());
        double growthRate = growthRatePercent / 100.0;

        Console.Write("Enter number of years: ");
        int years = Convert.ToInt32(Console.ReadLine());

        double result = ForecastRecursive(currentValue, growthRate, years);

        Console.WriteLine($"\nEstimated value after {years} years: {result:F2}");
    }

    static double ForecastRecursive(double currentValue, double rate, int years)
    {
        if (years == 0)
            return currentValue;

        return ForecastRecursive(currentValue, rate, years - 1) * (1 + rate);
    }
}
