using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sg
{
    public class EstimatorFra:Estimator
    {
        //public List<double> Data { get; set; }//contient des FRA rates
        public EstimatorFra(double End,List<double> data)
        {
            Data = new List<double>(data);
            EndDate = End;
            Zc = new Dictionary<double, double>();
            yield = new Dictionary<double, double>();

        }

        public override void EstimateZc()
        {
            Zc.Add(0,1);//on ajoute le P(0,1)
            yield.Add(0,Data[0]*100);
            double T = 1;
            while (T <= EndDate)
            {
                double ZC = Zc[T - 1] / (1 + Data[(int)T - 1]);//Price of a zero coupon of maturity T
                Zc.Add(T, ZC);
                yield.Add(T, 100 * -Math.Log(ZC) / T);//on a joute le taux zc correspondant
                T += 1;
            }
            return;
        }


        public override void Interpolation()
        {
            return;
        }

    }
}
