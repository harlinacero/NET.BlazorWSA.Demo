using ChartJs.Blazor.Common;

namespace BlazorApp.Charts
{
    public interface IChart<T>
    {
        void AddColors(string[] colors);
        void AddDataSet();
        void AddOptions(OptionsTitle options);
        T BuildChart();
        void Reset();
    }
}