//using Microsoft.AspNetCore.Components;
//using Microsoft.Extensions.Options;
//using Microsoft.JSInterop;
//using System.ComponentModel.Design;
//using System.Text.Json;

//namespace GipSite.ApexCharts;

//public class Chart<Ty>
//{
//	IJSRuntime JSRuntime { get; set; }
//	public Dictionary<string, object> Options { get; init; } = new();
//	ChartProperties ChartProperties { get; }
//	Series<Ty>[] Series { get; }
//	public string TargetElement { get; }
//	public int Length { get; private set; }

//    public Chart(IJSRuntime runtime, ChartProperties properties, string targetElement = "#chart", params Series<Ty>[] series)
//    {
//        JSRuntime = runtime;
//		TargetElement = targetElement;
//		ChartProperties = properties;
//        ChartProperties.OnPropChanged += async (sender, e) => await UpdateOptions();
//		Series = series;
//        Options = ~properties;
//		Length = series.Length;
//		for (int i = 0; i < Length; i++)
//        {
//            var currentSeries = ~series[i];
//            Series[i].OnSeriesChanged += async (sender, e) => await UpdateSeries();
//			Options.Add(currentSeries.Key, currentSeries.Value);
//        }
//		//for debugging
//		Console.WriteLine(JsonSerializer.Serialize(Options));
//	}

//	private List<Dictionary<string, object>> GetSeriesList() 
//	{
//		List<Dictionary<string, object>> series = new();
//		for (int i = 0; i < Series.Length; i++)
//		{
//			Series<Ty> currentSeries = Series[i];
//			var kvp = ~currentSeries;
//			var seriesData = (List<Dictionary<string, object>>)kvp.Value;

//			series = series.Concat(seriesData).ToList();
//		}
//		//Console.WriteLine(JsonSerializer.Serialize(series));
//		return series;
//	}

//	public async Task UpdateSeries() => await JSRuntime.InvokeVoidAsync("UpdateSeries", GetSeriesList());

//	public async Task UpdateOptions() => await JSRuntime.InvokeVoidAsync("UpdateOptions", ~this);

//	public async Task RenderChart() => await JSRuntime.InvokeVoidAsync("RenderChart", ~this, TargetElement);

//	//I know this is normally the complement operator, but i can do whatever i want, my code :)
//	//I did this as a shorter way to get the underlying options to make the code cleaner.
//	/// <summary>
//	/// Used to get the underlying structure for JS interop.
//	/// </summary>
//	/// <param name="chart">The chart of which to get the underlying structure</param>
//	/// <returns>A <see cref="Dictionary{string, object}"/> that represents this chart as a Javascript structure.</returns>
//	public static Dictionary<string, object> operator ~(Chart<Ty> chart) => chart.Options;
//}
