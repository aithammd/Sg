namespace Sg
{
    internal abstract class Curve
    {
        // la méthode qui renvoie la valeur de la courbe à une date donnée
        public abstract double ValueAtDate(double date);
    }
}
