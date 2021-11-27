using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using Sg;
namespace WpfApp1
{
    class MainWindowsViewModel
    {
        public SeriesCollection MySeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public MainWindowsViewModel(double[] taux, String[] dates)
        {
            MySeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> (taux)
                }
            };

            Labels = dates;
        }
        public MainWindowsViewModel()
        {
            List<double> swap = new List<double>() { -0.521 / 100, -0.368 / 100, -0.256 / 100, -0.185 / 100, -0.130 / 100 };
            List<double> Fra = new List<double>() { 2.2375 / 100, 2.4594 / 100, 2.6818 / 100, 2.7422 / 100, 2.6625 / 100 };

            Estimator est = new EstimatorSwap(5, swap);

            est.EstimateZc();
            Dictionary<double, double> result = est.yield;
            string[] keys = Array.ConvertAll(result.Keys.ToArray(), item => item.ToString());
            double[] values = result.Values.ToArray();

            MySeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "taux ZC",
                    Values = new ChartValues<double> (values)
                }
            };
            Labels = keys;

        }
    }
}
