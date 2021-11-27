using System;
using System.Collections.Generic;

namespace Sg
{
    class CalculatorFromFRAs : Calculator
    {
        public CalculatorFromFRAs(Dictionary<double, double> marketDatas)
        {
            MarketDatas = marketDatas;
        }

        public override Dictionary<double, double> CalculateZeroCoupons()
        {
            Dictionary<double, double> result = new Dictionary<double, double> { { 0.0, 1.0 } };
            
            int N = MarketDatas.Count;

            double T = 1.0;
            while (T <= N)
            {
                double zeroCoupon = result[T - 1.0] / (1 + MarketDatas[T]); // Price of a zero coupon of maturity T
                result.Add(T, zeroCoupon);

                T += 1;
            }

            return result;
        }
    }
}
