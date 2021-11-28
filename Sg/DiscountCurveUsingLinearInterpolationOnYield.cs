using System;

namespace Sg
{
    public class DiscountCurveFromYieldCurve : ICurve
    {
        private IYieldCurve YieldCurve { get; set; }

        public DiscountCurveFromYieldCurve(IYieldCurve yieldCurve)
        {
            YieldCurve = yieldCurve;
        }

        public double ValueAtDate(double date)
        {
            double yield = YieldCurve.ValueAtDate(date);

            double zeroCoupon = Math.Exp(-yield * date);

            return zeroCoupon;
        }
    }
}
