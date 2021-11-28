using System;
using System.Collections.Generic;
using System.Linq;

namespace Sg
{
    public static class CurveUtilities
    {
        // méthode qui renvoie des valeurs à plusieurs dates entre 0 et lastDate
        public static SortedDictionary<double, double> Sample(this ICurve curve, double lastDate)
        {
            double[] dates = new double[100];
            for (int i = 0; i < dates.Length; i++)
            {
                dates[i] = i * lastDate / 100;
            }

            Dictionary<double, double> result = dates.ToDictionary(x => x, x => curve.ValueAtDate(x));

            return new SortedDictionary<double, double>(result);
        }

        public static void PrintSampledCurve(this ICurve curve, double lastDate, string curveId)
        {
            Console.WriteLine("Sampling curve " + curveId + ":");

            SortedDictionary<double, double> sampledValues = curve.Sample(lastDate);

            foreach (KeyValuePair<double, double> entry in sampledValues)
            {
                Console.WriteLine("Zero-coupon for date = " + entry.Key + " is: " + entry.Value);
            }
            Console.WriteLine("Done.");

            Console.ReadLine();
        }
    }
}
