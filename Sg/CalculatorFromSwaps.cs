using System;
using System.Collections.Generic;

namespace Sg
{
    public class CalculatorFromSwaps : Calculator
    {
        public CalculatorFromSwaps(Dictionary<double, double> marketDatas)
        {
            MarketDatas = marketDatas;
        }

        public override SortedDictionary<double, double> CalculateZeroCoupons()
        {
            SortedDictionary<double, double> result = new SortedDictionary<double, double> { { 0.0, 1.0 } };
            SortedDictionary<double, double> yield = new SortedDictionary<double, double> { { 0.0, 0.0 } };

            int N = MarketDatas.Count;

            double T = 1;
            while (T <= N)
            {
                double Sum = 0;

                double j = 1;
                while (j <= T - 1)
                {
                    //TODO: introduire la fonction YearFraction qui calcule la différence entre deux dates
                    Sum += result[j];
                    j += 1;
                }
                double zeroCoupon = (1 - Sum * MarketDatas[T]) / 1 + T * MarketDatas[T];

                result.Add(T, zeroCoupon);
                yield.Add(T, -Math.Log(zeroCoupon) * 100 / T);
                T += 1;
            }

            return yield;
        }
    }
}
