using System.Collections.Generic;

namespace Sg
{
    public abstract class Calculator
    {
        public Dictionary<double, double> MarketDatas { get; set; }

        public abstract Dictionary<double, double> CalculateZeroCoupons();
    }
}
