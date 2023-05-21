using System.Drawing;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.Util;

namespace BlazorApp.Charts
{
    public class LineChart : IChart<LineConfig>
    {
        private LineConfig _config;
        private const int InitalCount = 7;
        public LineChart()
        {
            _config = new LineConfig();
        }
        public void AddColors(string[] colors)
        {
            throw new NotImplementedException();
        }

        public void AddDataSet()
        {
            IDataset<int> dataset1 = new LineDataset<int>(Utils.PageUtils.GenerateRandomList(InitalCount))
            {
                Label = "My first dataset",
                BackgroundColor = ColorUtil.FromDrawingColor(Color.Red),
                BorderColor = ColorUtil.FromDrawingColor(Color.Red),
                Fill = FillingMode.Disabled
            };

            IDataset<int> dataset2 = new LineDataset<int>(Utils.PageUtils.GenerateRandomList(InitalCount))
            {
                Label = "My second dataset",
                BackgroundColor = ColorUtil.FromDrawingColor(Color.Blue),
                BorderColor = ColorUtil.FromDrawingColor(Color.Blue),
                Fill = FillingMode.Disabled
            };


            _config.Data.Datasets.Add(dataset1);
            _config.Data.Datasets.Add(dataset2);
        }

        public void AddOptions(OptionsTitle options)
        {
            _config.Options = new LineOptions
            {
                Responsive = true,
                Title = options,
                Tooltips = new Tooltips
                {
                    Mode = InteractionMode.Nearest,
                    Intersect = true
                },
                Hover = new Hover
                {
                    Mode = InteractionMode.Nearest,
                    Intersect = true
                },
                Scales = new Scales
                {
                    XAxes = new List<CartesianAxis>
                    {
                        new CategoryAxis
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = "Month"
                            }
                        }
                    },
                    YAxes = new List<CartesianAxis>
                    {
                        new LinearCartesianAxis
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = "Value"
                            }
                        }
                    }
                }
            };
        }

        public LineConfig BuildChart()
        {
            return _config;
        }

        public void Reset()
        {
            _config = new LineConfig();
        }
    }
}