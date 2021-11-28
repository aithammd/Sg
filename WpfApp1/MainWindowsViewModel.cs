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
            SortedDictionary<double, double> MarketDatasSwaps = new SortedDictionary<double, double>()
            {
                { 1, 0.662 / 100 },
                { 2, 1.062 / 100 },
                { 3, 1.170 / 100 },
                { 4, 1.194 / 100 },
                { 5, 1.191 / 100 }
            };
            Calculator est2 = new CalculatorFromSwaps(MarketDatasSwaps);

            SortedDictionary<double, double> MarketDatasFRA = new SortedDictionary<double, double>()
            {
                { 1, 2.2375 / 100 },
                { 2, 2.4594 / 100 },
                { 3, 2.6818 / 100 },
                { 4, 2.7422 / 100 },
                { 5, 2.6625 / 100 }
            };
            Calculator est = new CalculatorFromFRAs(MarketDatasFRA);

            SortedDictionary<double, double> result = est.CalculateZeroCoupons();

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
