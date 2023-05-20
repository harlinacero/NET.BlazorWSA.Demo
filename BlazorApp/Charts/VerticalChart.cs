using System.Drawing;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Util;

namespace BlazorApp.Charts
{
    public class VerticalChart : IChart<BarConfig>
    {

        protected BarConfig _config;
        public VerticalChart()
        {
            _config = new BarConfig();
        }
        public void AddOptions(OptionsTitle options)
        {
            _config.Options = new BarOptions
            {
                Responsive = true,
                Legend = new Legend { Position = Position.Top },
                Title = options
            };
        }
        public void AddDataSet()
        {
            for (int i = 0; i <= 5; i++)
            {
                IEnumerable<int> data = Utils.PageUtils.GenerateRandomList(5);
                IDataset<int> dataset = new BarDataset<int>(data)
                {
                    Label = $"Dataset {i + 1}",
                    BackgroundColor = ColorUtil.FromDrawingColor(Color.FromArgb(128, Color.Blue)),
                    BorderColor = ColorUtil.FromDrawingColor(Color.Blue),
                    BorderWidth = 1
                };

                _config.Data.Datasets.Add(dataset);
            }
        }

        public void AddColors(string[] colors)
        {
            throw new NotImplementedException();
        }
        public void Reset()
        {
            _config = new BarConfig();
        }

        public BarConfig BuildChart()
        {
            return _config;
        }
    }

    public class HorizontalChart : IChart<BarConfig>
    {

        protected BarConfig _config;
        public HorizontalChart()
        {
            _config = new BarConfig();
        }
        public void AddOptions(OptionsTitle options)
        {
            _config.Options = new BarOptions
            {
                Responsive = true,
                Legend = new Legend { Position = Position.Top },
                Title = options
            };
        }
        public void AddDataSet()
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

        public void AddColors(string[] colors)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            _config = new BarConfig();
        }
        public BarConfig BuildChart()
        {
            return _config;
        }
    }
}