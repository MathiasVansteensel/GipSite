//using GipSite.ApexCharts;
using ApexCharts;
using GipSite.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GipSite.Pages;

public partial class Dashboard : ComponentBase
{

	[Inject]
	public IJSRuntime JS { get; set; }

	static Random random = new();
	static int i = 0;
	static DateTime startDate = DateTime.Now;
	static List<DateOnly> anotationDates = new List<DateOnly>();

	static List<DataPoint<DateTime, decimal>> points { get; set; } = new()
	{
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble()),
		new(startDate.AddHours(i++), (decimal)random.NextDouble())
	};


	public Dashboard()
	{
		
	}

	static ApexChart<DataPoint<DateTime, decimal>> mainChart;

	//in hours (or whatever the x axis div is)
	const int Viewport = 48;

	async void MainChartAdd()
	{
		var newDp = new DataPoint<DateTime, decimal>(startDate.AddHours(i++), (decimal)random.NextDouble());
		points.Add(newDp);
		await mainChart.AppendDataAsync(new List<DataPoint<DateTime, decimal>>() { newDp });
		UpdateChart();
	}

	private async void UpdateChart() 
	{
		for (int i = 0; i < points.Count; i++)
		{
			DateOnly currentDate = DateOnly.FromDateTime(points[i].X);
			if (!anotationDates.Contains(currentDate))
			{
				await mainChart.AddPointAnnotationAsync(new AnnotationsPoint
				{
					X = currentDate.ToDateTime(new()).ToUnixTimeMilliseconds(),
					Label = new Label 
					{
						Text = currentDate.ToString("M"),
						Style = new Style 
						{
							Background = "#000"
						}
					}
				}, true);
				anotationDates.Add(currentDate);
			}
			
		}

		int length = points.Count, start = (length >= Viewport ? length - Viewport : 0), end = length - 3;
		DateTime startTime = points[start].X, endTime = points[end].X;

		await mainChart.ZoomXAsync(startTime.ToUnixTimeMilliseconds(), endTime.ToUnixTimeMilliseconds());
	}

	protected override void OnInitialized()
	{
		base.OnInitialized();
	}
}