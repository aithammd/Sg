using System;
using System.Collections.Generic;
using System.Linq;
namespace Sg
{
    public class Curve
    {
        // la méthode qui renvoie la valeur de la courbe à une date donnée
        public static double ValueAtDate(SortedDictionary<double, double> taux,double date) {

            if ((int)date == date)
            {
                return taux[date];
            }
            int i = 0;
            double[] keys = taux.Keys.ToArray();
            for (int j = 0; j < keys.Length; j++)
            {
                if (date < keys[j])
                {
                    i = j;
                    break;
                }

            }
            double pas = keys[i] - keys[i - 1];
            double Zc = taux[keys[i]]*(date-keys[i-1])/ pas + taux[keys[i-1]]*((keys[i]) - date)/pas;//formule d'interpolation entre i et i-1
            taux.Add(date, Zc);
            return Zc;
        
        }
    }
}
