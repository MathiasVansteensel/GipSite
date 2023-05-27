namespace GipSite;

//This class only exists because FOR SOME REASON!!! i can't use structs (like PointF or so) or primitive datatypes (like int, double, decimal...)
//in the apexchart lib, this is why i like reinventing the wheel... i get to chose how it works and usually it makes more sense

public class DataPoint<Tx, Ty>
{
	public Tx X { get; set; }
	public Ty Y { get; set; }

    public DataPoint(Tx x, Ty y)
    {
        X = x; 
        Y = y;
    }
}
