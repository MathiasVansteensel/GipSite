namespace GipSite;

public class ApexChart
{
	//Yes... i did convert all the js option structures to json and merge them, then painstakingly removed duplicate options and then pasted it as a c# class... fight me
	public enum ChartType
	{
		//I like enums bc they have intellisense, thats the only reason this is here, so you can select an index in the ChartType array with a name instead of an index
		Line,
		Area,
		Column,
		Bar,
		Scatter,
		Bubble,
		Heatmap,
		Radar,
		Pie,
		Donut,
		RadialBar,
		RangeBar,
		Candlestick,
		BoxPlot,
		Histogram,
		Pyramid,
		Funnel,
		Gantt,
		TreeMap,
		NetworkGraph,
		Mixed
	}

	public enum StrokeCurveType
	{
		Straight,
		Smooth,
		Stepline
	}

	public readonly string[] ChartTypes = { "line", "area", "column", "bar", "scatter", "bubble", "heatmap", "radar", "pie", "donut", "radialbar", "rangebar", "candlestick", "boxplot", "histogram", "pyramid", "funnel", "gantt", "treeMap", "networkGraph", "mixed" };
	public readonly string[] StrokeCurveTypes = { "straight", "smooth",	"stepline" };

	public Chart Chart { get; set; } = new();
	public List<Series> Series { get; set; } = new();
	public Xaxis Xaxis { get; set; } = new();
	public Yaxis Yaxis { get; set; } = new();
	public ChartTitle Title { get; set; } = new();
	public Subtitle Subtitle { get; set; } = new();
	public Tooltip Tooltip { get; set; } = new();
	public Datalabels DataLabels { get; set; } = new();
	public Annotations Annotations { get; set; } = new();
	public Grid Grid { get; set; } = new();
	public Legend Legend { get; set; } = new();
	public List<Responsive> Responsive { get; set; } = new();
	public Stroke Stroke { get; set; } = new();

	public ApexChart(string seriesName, double[] values, ChartType type, bool dataLables, StrokeCurveType strokeCurve, int[] xAxisValues)
    {
		Series.Add(new(seriesName, values));
		Chart.Type = ChartTypes[(int)ChartType.Area];
		DataLabels.Enabled = dataLables;
		Stroke.Curve.CurveType = StrokeCurveTypes[(int)StrokeCurveType.Smooth];
		Xaxis.Categories.AddRange(xAxisValues.Cast<dynamic>().ToArray());
		Xaxis.Type = "numeric";
	}
}

public class Chart
{
	public string Type { get; set; }
	public int Height { get; set; }
	public string Width { get; set; }
	public string Background { get; set; }
	public Toolbar Toolbar { get; set; }
	public Zoom Zoom { get; set; }
	public Animations Animations { get; set; }
	public Sparkline Sparkline { get; set; }
	public Dropshadow DropShadow { get; set; }
}

public class Toolbar
{
	public bool Show { get; set; }
	public string AutoSelected { get; set; }
}

public class Zoom
{
	public bool Enabled { get; set; }
}

public class Animations
{
	public bool Enabled { get; set; }
	public string Easing { get; set; }
	public int Speed { get; set; }
	public int Delay { get; set; }
}

public class Sparkline
{
	public bool Enabled { get; set; }
}

public class Dropshadow
{
	public bool Enabled { get; set; }
	public int Top { get; set; }
	public int Left { get; set; }
	public int Blur { get; set; }
	public float Opacity { get; set; }
}

public class Xaxis
{
	public string Type { get; set; }
	public List<dynamic> Categories { get; set; }
}

public class Yaxis
{
	public AxisLable Title { get; set; }
	public Labels Labels { get; set; }
}

public class AxisLable
{
	public string Text { get; set; }
}

public class Labels
{
	public Func<string> Formatter { get; set; }
}

public class ChartTitle
{
	public string Text { get; set; }
	public string Align { get; set; }
}

public class Subtitle
{
	public string Text { get; set; }
	public string Align { get; set; }
}

public class Tooltip
{
	public bool Enabled { get; set; }
	public bool Shared { get; set; }
	public bool Intersect { get; set; }
	public bool FollowCursor { get; set; }
	public bool FillSeriesColor { get; set; }
	public string Theme { get; set; }
	public TooltipStyle Style { get; set; }
	public Ondatasethover OnDatasetHover { get; set; }
}

public class TooltipStyle
{
	public string FontSize { get; set; }
	public string FontFamily { get; set; }
}

public class Ondatasethover
{
	public bool HighlightDataSeries { get; set; }
}

public class Stroke 
{
	public Curve Curve { get; set; }
}

public class Curve
{
	public string CurveType { get; set; }
}

public class Datalabels
{
	public bool Enabled { get; set; }
	public DataLabelStyle Style { get; set; }
}

public class DataLabelStyle
{
	public string FontSize { get; set; }
	public string FontFamily { get; set; }
}

public class Annotations
{
	public List<Point> Points { get; set; }
	public Annotationsoptions AnnotationsOptions { get; set; }
}

public class Annotationsoptions
{
	public string Position { get; set; }
	public int yAxisIndex { get; set; }
	public int XAxisIndex { get; set; }
}

public class Point
{
	public double X { get; set; }
	public double Y { get; set; }
	public Marker Marker { get; set; }
	public Label Label { get; set; }
}

public class Marker
{
	public int Size { get; set; }
	public int StrokeWidth { get; set; }
	public int FillOpacity { get; set; }
	public string Shape { get; set; }
}

public class Label
{
	public string BorderColor { get; set; }
	public int BorderWidth { get; set; }
	public string Text { get; set; }
	public string TextAnchor { get; set; }
	public string Position { get; set; }
	public int OffsetX { get; set; }
	public int OffsetY { get; set; }
	public LabelStyle Style { get; set; }
}

public class LabelStyle
{
	public string FontSize { get; set; }
	public string FontWeight { get; set; }
	public string Color { get; set; }
	public string Background { get; set; }
}

public class Grid
{
	public bool Show { get; set; }
	public string BorderColor { get; set; }
	public int StrokeDashArray { get; set; }
	public string Position { get; set; }
	public GridXaxis Xaxis { get; set; }
	public GridYaxis Yaxis { get; set; }
}

public class GridXaxis
{
	public Lines Lines { get; set; }
}

public class Lines
{
	public bool Show { get; set; }
}

public class GridYaxis
{
	public GridLines Lines { get; set; }
}

public class GridLines
{
	public bool Show { get; set; }
}

public class Legend
{
	public bool Show { get; set; }
	public string Position { get; set; }
	public string HorizontalAlign { get; set; }
	public Onitemclick OnItemClick { get; set; }
	public Onitemhover OnItemHover { get; set; }
	public Containermargin ContainerMargin { get; set; }
}

public class Onitemclick
{
	public bool ToggleDataSeries { get; set; }
}

public class Onitemhover
{
	public bool HighlightDataSeries { get; set; }
}

public class Containermargin
{
	public int Left { get; set; }
	public int Top { get; set; }
}

public class Series
{
    public Series(string name, params double[] values)
    {
        Name = name;
		Data = values.ToList();
    }
    public string Name { get; set; }
	public List<double> Data { get; set; }
}

public class Responsive
{
	public int Breakpoint { get; set; }
	public Options Options { get; set; }
}

public class Options
{
	public ChartOptions ChartOptions { get; set; }
}

public class ChartOptions
{
	public int Height { get; set; }
}




//Json used:
//{
//    "chart": {
//        "type": "line",
//            "height": 400,
//                "width": "100%",
//                    "background": "#fff",
//                        "toolbar": {
//            "show": true,
//                "autoSelected": "zoom"
//        },
//        "zoom": {
//	"enabled": true

//		},
//        "animations": {
//	"enabled": true,
//                "easing": "easeinout",
//                    "speed": 800,
//                        "delay": 0

//		},
//        "sparkline": {
//	"enabled": false

//		},
//        "dropShadow": {
//	"enabled": false,
//                "top": 0,
//                    "left": 0,
//                        "blur": 3,
//                            "opacity": 0.5

//		}
//    },
//    "series": [{
//        "name": "Series 1",
//        "data": [10, 20, 30, 40, 50, 60, 70, 80, 90]
//    }, {
//	"name": "Series 2",
//        "data": [20, 30, 40, 50, 60, 70, 80, 90, 100]
//    }],
//        "xaxis": {
//	"type": "datetime",
//            "categories": [

//				"2022-01-01",
//                "2022-02-01",
//                "2022-03-01",
//                "2022-04-01",
//                "2022-05-01",
//                "2022-06-01",
//                "2022-07-01",
//                "2022-08-01",
//                "2022-09-01"
//            ]
//    },
//    "yaxis": {
//	"title": {
//		"text": "Value"

//		},
//        "labels": {
//		"formatter": "formatstringfunct"

//		}
//},
//    "title": {
//	"text": "My Chart Title",
//            "align": "center"

//	},
//    "subtitle": {
//	"text": "My Chart Subtitle",
//            "align": "center"

//	},
//    "tooltip": {
//	"enabled": true,
//            "shared": true,
//                "intersect": false,
//                    "followCursor": false,
//                        "fillSeriesColor": false,
//                            "theme": "dark",
//                                "style": {
//		"fontSize": "12px",
//                "fontFamily": "Helvetica, Arial, sans-serif"

//		},
//        "onDatasetHover": {
//		"highlightDataSeries": true

//		}
//},
//    "dataLabels": {
//	"enabled": false,
//            "style": {
//		"fontSize": "12px",
//                "fontFamily": "Helvetica, Arial, sans-serif"

//		}
//},
//    "annotations": {
//	"points": [{
//		"x": "2022-03-01",
//            "y": 30,
//            "marker": {
//			"size": 8,
//                "strokeWidth": 2,
//                "fillOpacity": 1,
//                "shape": "circle"

//			},
//            "label": {
//			"borderColor": "#FF4560",
//                "borderWidth": 1,
//                "text": "Annotation 1",
//                "textAnchor": "start",
//                "position": "right",
//                "offsetX": 0,
//                "offsetY": 0,
//                "style": 
//                {
//				"fontSize": "12px",
//                    "fontWeight": "bold",
//                    "color": "#fff",
//                    "background" : "#FF4560"

//					}
//		}
//	}],
//            "annotationsOptions": {
//		"position": "front",
//                "yAxisIndex": 0,
//                    "xAxisIndex": 0

//		}
//},
//    "grid": {
//	"show": true,
//            "borderColor": "#f1f1f1",
//                "strokeDashArray": 0,
//                    "position": "back",
//                        "xaxis": {
//		"lines": {
//			"show": true

//			}
//	},
//        "yaxis": {
//		"lines": {
//			"show": true

//			}
//	}
//},
//    "legend": {
//	"show": true,
//            "position": "top",
//                "horizontalAlign": "left",
//                    "onItemClick": {
//		"toggleDataSeries": true

//		},
//        "onItemHover": {
//		"highlightDataSeries": true

//		},
//        "containerMargin": {
//		"left": 0,
//                "top": 0

//		}
//},
//    "stroke": {
//	"curve": "smooth"

//	},
//    "responsive": [{
//        "breakpoint": 768,
//        "options": {
//            "chart": {
//                "height": 300
//            }
//        }
//    }]
//}