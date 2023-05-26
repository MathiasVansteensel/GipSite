using GipSite.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Xml.Linq;

namespace GipSite.ApexCharts;

//Damn time constraints, i could've made something nice...
//public enum XAxisDataType
//{
//	Category,
//	DateTime,
//	Numeric
//}

public class Series<Ty>
{
	public const string DateTimeStringFormat = "yyyy-MM-dd\\THH:mm:ss.fff\\Z";

	internal event EventHandler OnSeriesChanged;
	private KeyValuePair<string, object> seriesJsonRep;

	#region BackingFields
	private Dictionary<DateTime, Ty> _values;
	private string _name = "data";
	#endregion

	#region Properties
	public Dictionary<DateTime, Ty> Values 
	{ 
		get => _values;
		set 
		{
			_values = value;
			Length = _values.Count;
			UpdateDataTree();
			OnSeriesChanged?.Invoke(this, EventArgs.Empty);
		}
	}
	public string Name
	{
		get => _name;
		set
		{
			_name = value;
			UpdateDataTree();
			OnSeriesChanged?.Invoke(this, EventArgs.Empty);
		}
	}

	public int Length { get; private set; } = 0;

	#endregion

	public Series(string name, Dictionary<DateTime, Ty> points)
	{
		_name = name;
		_values = points;
		Length = Values.Count;
		UpdateDataTree();
	}

#warning *CRIES IN PAIN* why didnt i just use a json string and placeholders (note to self... there is an append data function)

	public void AddDataPoint(DateTime dt, Ty value) 
	{
		Values.Add(dt, value);
		Length = Values.Count;
		UpdateDataTree();
		OnSeriesChanged?.Invoke(this, EventArgs.Empty);
	}

	public void RemoveDataPointAt(int index)
	{
		Dictionary<DateTime, Ty> newValues = new();
		for (int i = 0; i < Values.Count; i++)
		{
			if (i != index) 
			{
				var currentVal = Values.ElementAt(i);
				newValues.Add(currentVal.Key, currentVal.Value);
			}
		}
		Values = newValues;
		Length = Values.Count;
		UpdateDataTree();
		OnSeriesChanged?.Invoke(this, EventArgs.Empty);
	}

	private void UpdateDataTree()
	{
		List<Dictionary<string, object>> formattedDataPoints = new();

		for (int i = 0; i < Values.Count; i++)
		{
			var pair = Values.ElementAt(i);
			var formattedPair = new Dictionary<string, object>
			{
				{ "x", pair.Key },
				{ "y", pair.Value }
			};

			formattedDataPoints.Add(formattedPair);
		}

		seriesJsonRep = new KeyValuePair<string, object>("series", new List<Dictionary<string, object>>
		{
			new Dictionary<string, object>
			{
				{ "name", Name },
				{ "data", formattedDataPoints }
			}
		});
	}

	// => seriesJsonRep = new KeyValuePair<string, object>
	//(
	//	"series",
	//	new List<Dictionary<string, object>>
	//	{
	//		new Dictionary<string, object>
	//		{
	//			{ "name", Name },
	//			{ "data", Values }
	//		}
	//	}
	//);

	public static KeyValuePair<string, object> operator ~(Series<Ty> series) => series.seriesJsonRep;
}
