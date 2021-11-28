using System;
using System.Collections.Generic;
using System.Linq;

namespace Sg
{
    internal class YieldCurveUsingLinearInterpolation : IYieldCurve
    {
        private SortedDictionary<double, double> ZeroCoupons { get; set; }

        public YieldCurveUsingLinearInterpolation(SortedDictionary<double, double> zeroCoupons)
        {
            ZeroCoupons = zeroCoupons;
        }

        private double[] CurvePoints => ZeroCoupons.Keys.ToArray();
        private double[] Yields => ZeroCoupons.Select(p => p.Key == 0.0 ? 0.0 : -Math.Log(p.Value) / p.Key).ToArray();
        private double Length => ZeroCoupons.Count;

        public double ValueAtDate(double date)
        {
            double yield;
            if (date % 1 == 0) // date est un entier
            {
                yield = Yields[(int)date];
            }
            else // date n'est pas un entier
            {
                int i = 0;
                for (int j = 0; j < Length; j++)
                {
                    if (date > CurvePoints[j])
                    {
                        i = j;
                        break;
                    }
                }

                if (i == 0)
                {
                    double pas = CurvePoints[1];
                    yield = Yields[1] * date / pas; //formule d'interpolation entre 0 et date;
                }
                else
                {
                    double pas = CurvePoints[i] - CurvePoints[i - 1];
                    yield = Yields[i] * (date - CurvePoints[i - 1]) / pas
                        + Yields[i - 1] * (CurvePoints[i] - date) / pas; //formule d'interpolation entre i et i-1
                }
            }

            return yield;
        }
    }
}
