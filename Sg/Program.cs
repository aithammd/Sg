using System;
using System.Collections.Generic;

namespace Sg
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, double> MarketDatasFRA = new SortedDictionary<double, double>()
            {
                { 1, 2.2375 / 100 },
                { 2, 2.4594 / 100 },
                { 3, 2.6818 / 100 },
                { 4, 2.7422 / 100 },
                { 5, 2.6625 / 100 }
            };
            Calculator calculatorFromFRAs = new CalculatorFromFRAs(MarketDatasFRA);

            double lastDate = 3.0;

            SortedDictionary<double, double> zeroCouponsFromFRAs = calculatorFromFRAs.CalculateZeroCoupons();
            PrintZeroCoupons(zeroCouponsFromFRAs);

            YieldCurveUsingLinearInterpolation yieldCurveUsingLinearInterpolation = new YieldCurveUsingLinearInterpolation(zeroCouponsFromFRAs);
            yieldCurveUsingLinearInterpolation.PrintSampledCurve(lastDate, "yieldCurveFromFRAs");

            DiscountCurveFromYieldCurve discountCurveFromFRAs = new DiscountCurveFromYieldCurve(yieldCurveUsingLinearInterpolation);
            discountCurveFromFRAs.PrintSampledCurve(lastDate, "discountCurveFromFRAs");

            SortedDictionary<double, double> MarketDatasSwaps = new SortedDictionary<double, double>()
            {
                { 1, 0.662 / 100 },
                { 2, 1.062 / 100 },
                { 3, 1.170 / 100 },
                { 4, 1.194 / 100 },
                { 5, 1.191 / 100 }
            };

            Calculator calculatorFromSwaps = new CalculatorFromSwaps(MarketDatasSwaps);
            SortedDictionary<double, double> zeroCouponsFromSwaps = calculatorFromSwaps.CalculateZeroCoupons();
            PrintZeroCoupons(zeroCouponsFromSwaps);
        }

        public static void PrintZeroCoupons(SortedDictionary<double, double> zeroCoupons)
        {
            Console.WriteLine("Printing zero-coupon values:");

            foreach (KeyValuePair<double, double> entry in zeroCoupons)
            {
                Console.WriteLine("Zero-coupon for maturity = " + entry.Key + " is: " + entry.Value);
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
