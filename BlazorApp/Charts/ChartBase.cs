using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;

namespace BlazorApp.Charts
{
    public abstract class ChartBase : IChart<BarConfig>
    {
        protected BarConfig _config;

        public void AddColors(string[] colors)
        {
            throw new NotImplementedException();
        }
        public abstract void AddDataSet();
        public void AddOptions(OptionsTitle options)
        {
            _config.Options = new BarOptions
            {
                Responsive = true,
                Legend = new Legend { Position = Position.Top },
                Title = options
            };
        }

        public BarConfig BuildChart()
        {
            return _config;
        }
        public void Reset()
        {
            _config = new BarConfig();
        }
    }
}