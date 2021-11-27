using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sg
{
    public class EstimatorSwap : Estimator
    {
        //public List<double> Data { get; set; }//contient des swap rates de maturite i+1 (i = indice)
        public EstimatorSwap(double End,List<double> data)
        {
            Data = new List<double>(data);
            EndDate = End;
            Zc = new Dictionary<double, double>();
            yield = new Dictionary<double, double>();

        }

        public override void EstimateZc()
        {
            Zc.Add(0, 1);//on ajoute le P(0,1)
            yield.Add(0,0);
            double T = 1;
            double Sum = -1;
            while (T <= EndDate)
            {
                Sum += Zc[T - 1];
                double ZC = 1 - Sum * Data[(int)T-1] / 1 + T*Data[(int)T-1];
                Zc.Add(T,ZC);
                yield.Add(T,100* -Math.Log(ZC) / T);//on a joute le taux zc correspondant
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
