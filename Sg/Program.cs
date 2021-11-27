using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sg
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> Fra = new List<double>(){2.2375/100, 2.4594 / 100, 2.6818 / 100, 2.7422 / 100, 2.6625 / 100 };
            List<double> swap = new List<double>() { 0.662 / 100, 1.062 / 100, 1.170 / 100, 1.194 / 100, 1.191 / 100 };

            Estimator est = new EstimatorFra(5,Fra);
            Estimator estswap = new EstimatorFra(5, swap);

            est.EstimateZc();
            estswap.EstimateZc();
            Dictionary<double, double> result = est.yield;
            Dictionary<double, double> resultswap = estswap.yield;

            foreach (KeyValuePair<double, double> entry in resultswap)
            {
                Console.WriteLine("taux for maturity = "+entry.Key + " rate : "+entry.Valsue*100 +"%");
            }
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
