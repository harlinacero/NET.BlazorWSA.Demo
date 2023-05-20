using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;

namespace BlazorApp.Charts
{
    public class PieChart : IChart<PieConfig>
    {
        private PieConfig _pieConfig;

        public PieChart()
        {
            _pieConfig = new PieConfig();
        }

        public void Reset()
        {
            _pieConfig = new PieConfig();
        }

        public void AddOptions(OptionsTitle options)
        {
            _pieConfig.Options = new PieOptions
            {
                Responsive = true,
                Title = options
            };
        }


        public void AddColors(string[] colors)
        {
            foreach (var color in colors)
            {
                _pieConfig.Data.Labels.Add(color);
            }
        }

        public void AddDataSet()
        {
            PieDataset<int> dataset = new PieDataset<int>(new[] { 6, 5, 3, 7 })
            {
                BackgroundColor = new[]
                    {
                    ColorUtil.ColorHexString(255, 99, 132), // Slice 1 aka "Red"
                    ColorUtil.ColorHexString(255, 205, 86), // Slice 2 aka "Yellow"
                    ColorUtil.ColorHexString(75, 192, 192), // Slice 3 aka "Green"
                    ColorUtil.ColorHexString(54, 162, 235), // Slice 4 aka "Blue"
                    }
            };

            _pieConfig.Data.Datasets.Add(dataset);
        }

        public PieConfig BuildChart()
        {
            return _pieConfig;
        }

    }
}