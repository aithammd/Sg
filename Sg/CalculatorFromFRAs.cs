using System;
using System.Collections.Generic;

namespace Sg
{
    public class CalculatorFromFRAs : Calculator
    {
        public CalculatorFromFRAs(Dictionary<double, double> marketDatas)
        {
            MarketDatas = marketDatas;
        }

        public override SortedDictionary<double, double> CalculateZeroCoupons()
        {
            SortedDictionary<double, double> result = new SortedDictionary<double, double> { { 0.0, 1.0 } };
            SortedDictionary<double, double> yield = new SortedDictionary<double, double> { { 0.0, 0.0 } };

            int N = MarketDatas.Count;

            double T = 1.0;
            while (T <= N)
            {
                double zeroCoupon = result[T - 1.0] / (1 + MarketDatas[T]); // Price of a zero coupon of maturity T
                result.Add(T, zeroCoupon);
                yield.Add(T,-Math.Log(zeroCoupon)*100/T);

                T += 1;
            }

            return yield;
        }
    }
}
