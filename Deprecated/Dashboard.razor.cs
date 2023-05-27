////using GipSite.ApexCharts;
//using GipSite.Pages;
//using Microsoft.AspNetCore.Components;
//using Microsoft.JSInterop;

//namespace GipSite.Pages;

//public partial class Dashboard : ComponentBase
//{

//	[Inject]
//	public IJSRuntime JS { get; set; }

//	public Chart<double> MainChart { get; set; }
//	public ChartProperties Properties { get; set; }
//	public Series<double> Series { get; set; }


//	public Dashboard()
//	{
//		Random r = new();
//		ChartProperties properties = new(xTooltipFormat: "function(x) { return '69; }", strokeCurve: StrokeCurveType.Smooth);
//		Dictionary<DateTime, double> points = new();
//		for (int i = 0; i < 20; i++) points.Add(DateTime.Now.AddDays(i), r.NextDouble() * 10);
//		Series<double> series = new("testSeries", points);


//		Series = series;
//		Properties = properties;
//	}

//	protected override void OnInitialized()
//	{
//		base.OnInitialized();
//		MainChart = new(JS, Properties, series: Series);
//	}
//}


////protected override void OnInitialized() => AfterInit();
////private async void AfterInit() => await JS.InvokeVoidAsync("RenderMainGraph");