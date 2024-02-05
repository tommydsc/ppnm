using System;
using static System.Console;
using static System.Math;
class main{
	static double x=1.0;
	static double a=Sqrt(2); //sqrt of 2
	static double b=Exp(Log(2)/5);//2 to the 1/5
	static double c=Exp(PI); //e to the pi
	static double d=Exp(Log(PI)*E);//pi to the e
	static int Main() {
		Write($"sqrt2^2={a*a} (should equal 2)\n");
		Write($"fifth root of 2 to the 5={b*b*b*b*b} (should equal 2)\n");
		Write($"Gelfonds constant={c} (should equal 23.1406926328)\n");
		Write($"pi to the e={d} (should equal 22.4591577184 )\n");
		int prod=1;
		for(int i=1;i<10;i+=1) {
			Write($"gamma({i}) approximately {sfuns.fgamma(i)} (exact value {prod})\n");
			prod*=i;
		}
		prod=1;
		for(int i=1;i<10;i+=1) {
			Write($"lngamma({i}) approximately {sfuns.lngamma(i)} (exact value {Log(prod)})\n");
			prod*=i;
		}
		return 0;
	}
}	
