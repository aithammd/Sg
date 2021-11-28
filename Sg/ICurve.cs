namespace Sg
{
    public interface ICurve
    {
        // méthode qui renvoie la valeur de la courbe à une date donnée
        double ValueAtDate(double date);
    }

    public interface IYieldCurve : ICurve
    {

    }
}
