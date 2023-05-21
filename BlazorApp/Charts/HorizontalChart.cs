using System.Drawing;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Util;

namespace BlazorApp.Charts
{
    public class HorizontalChart : ChartBase
    {
        public HorizontalChart()
        {
            _config = new BarConfig();
        }
        public override void AddDataSet()
        {
            for (int i = 0; i <= 5; i++)
            {
                IEnumerable<int> data = Utils.PageUtils.GenerateRandomList(5);
                IDataset<int> dataset = new BarDataset<int>(data, true)
                {
                    Label = $"Dataset {i}",
                    BackgroundColor = ColorUtil.FromDrawingColor(Color.FromArgb(128, Color.Blue)),
                    BorderColor = ColorUtil.FromDrawingColor(Color.Blue),
                    BorderWidth = 1
                };

                _config.Data.Datasets.Add(dataset);
            }
        }

    }
}