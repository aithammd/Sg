using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sg
{
    public abstract class Estimator
    {
        public double EndDate { get; set; }
        public List<double> Data { get; set; }

        public Dictionary<double,double> Zc { get; set; }
        public Dictionary<double, double> yield { get; set; }

        public abstract void EstimateZc();

        public abstract void Interpolation();



    }
}
