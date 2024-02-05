using static System.Math;
static public class sfuns{
	public static double lngamma(double x){
		//single precision gamma function (formula from Wikipedia)
		if(x<0)return double.NaN;
		if(x<9)return lngamma(x+1)-Log(x); //Recurrence relatio
		double lnfgamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return lnfgamma;
		}
	public static double fgamma(double x){
		if(x<0)return PI/Sin(PI*x)/fgamma(1-x);//Eulers reflection formula
		return Exp(lngamma(x));
	}
}//class sfuns
