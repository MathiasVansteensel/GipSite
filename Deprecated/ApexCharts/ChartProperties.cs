//using System;
//using System.Runtime.CompilerServices;

//namespace GipSite.ApexCharts;

////I like enums bc they have intellisense, thats the only reason this is here, so you can select an index in the ChartType array with a name instead of an index
//public enum ChartType
//{
//	Line,
//	Area,
//	Bar,
//	Radar,
//	Histogram,
//	Pie,
//	Donut,
//	RadialBar,
//	Scatter,
//	Bubble,
//	Heatmap,
//	Candlestick
//}


//public enum StrokeCurveType
//{
//	Straight,
//	Smooth,
//	Stepline
//}

//public class ChartProperties
//{
//	#region Defaults
//	const ChartType DefaultType = ChartType.Area;
//	const StrokeCurveType DefaultStrokeCurve = StrokeCurveType.Straight;
//	const int DefaultHeight = 350;
//	const bool DefaultDataLabels = false;
//	const string DefaultXTooltipFormat = @"function(x) { return x; }";
//	const string DefaultYTooltipFormat = @"function(y) { return 'at ' + y; }";
//	#endregion

//	#region BackingFields
//	private ChartType _type = DefaultType;
//	private StrokeCurveType _strokeCurve = DefaultStrokeCurve;
//	private int _height = DefaultHeight;
//	private bool _dataLabels = DefaultDataLabels;
//	private string _xTooltipFormat = DefaultXTooltipFormat;
//	private string _yTooltipFormat = DefaultYTooltipFormat;
//	#endregion

//	#region Properties
//	public ChartType Type
//	{
//		get => _type;
//		set
//		{
//			_type = value;
//			UpdatePropTree();
//			OnPropChanged?.Invoke(this, EventArgs.Empty);
//		}
//	}

//	public StrokeCurveType StrokeCurve
//	{
//		get => _strokeCurve;
//		set
//		{
//			_strokeCurve = value;
//			UpdatePropTree();
//			OnPropChanged?.Invoke(this, EventArgs.Empty);
//		}
//	}

//	public int Height
//	{
//		get => _height;
//		set
//		{
//			_height = value;
//			UpdatePropTree();
//			OnPropChanged?.Invoke(this, EventArgs.Empty);
//		}
//	}

//	public bool DataLabels
//	{
//		get => _dataLabels;
//		set
//		{
//			_dataLabels = value;
//			UpdatePropTree();
//			OnPropChanged?.Invoke(this, EventArgs.Empty);
//		}
//	}

//	public string XTooltipFormat
//	{
//		get => _xTooltipFormat;
//		set
//		{
//			_xTooltipFormat = value;
//			UpdatePropTree();
//			OnPropChanged?.Invoke(this, EventArgs.Empty);
//		}
//	}

//	public string YTooltipFormat
//	{
//		get => _yTooltipFormat;
//		set
//		{
//			_yTooltipFormat = value;
//			UpdatePropTree();
//			OnPropChanged?.Invoke(this, EventArgs.Empty);
//		}
//	}
//	#endregion


//	public Dictionary<string, object> Options;

//	internal event EventHandler OnPropChanged;

//	public ChartProperties(ChartType type = DefaultType, StrokeCurveType strokeCurve = DefaultStrokeCurve, int height = DefaultHeight, bool dataLabels = DefaultDataLabels, string xTooltipFormat = DefaultXTooltipFormat, string yTooltipFormat = DefaultYTooltipFormat)
//	{
//		//dont use accessors bc then it calls the updatePropTree funct 69696969 or so times which is useless
//		_type = type;
//		_strokeCurve = strokeCurve;
//		_height = height;
//		_dataLabels = dataLabels;
//		_xTooltipFormat = xTooltipFormat;
//		UpdatePropTree();
//	}
	
//	private void UpdatePropTree() => Options = new Dictionary<string, object>
//	{
//		{ "chart", new Dictionary<string, object> {{ "height", Height }, { "type", Type.ToString().ToLower() }, { "foreColor", "#abb2bf" } }},
//		{ "dataLabels", new Dictionary<string, object> { { "enabled", DataLabels } } },
//		{ "stroke", new Dictionary<string, object> { { "curve", StrokeCurve.ToString().ToLower() } } },
//		{ "tooltip", new Dictionary<string, object> 
//		{
//			{ "x", new Dictionary<string, object> { { "show", true }, { "format", "dd/MM/yyyy" } }},
//			{ "y", new Dictionary<string, object> { { "formatter", "function(value) { return '$' + value.toFixed(2); }" } }},
//			{ "followCursor", true },
//		}},
//		{ "legend", new Dictionary<string, object> { { "showForSingleSeries", true } } }
//	};

//	public static Dictionary<string, object> operator ~(ChartProperties chartProps) => chartProps.Options;
//}