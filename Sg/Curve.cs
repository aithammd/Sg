using System.Collections.Generic;

namespace Sg
{
    public interface ICurve
    {
        // méthode qui renvoie la valeur de la courbe à une date donnée
        double ValueAtDate(double date);

        // méthode qui renvoie des valeurs à plusieurs dates entre 0 et lastDate
        SortedDictionary<double, double> Sample(double lastDate);
    }
}
