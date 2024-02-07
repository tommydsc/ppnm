using System;
using static System.Console;
using static System.Math;
class main{
public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
	if(Abs(b-a)<=acc) return true;
	if(Abs(b-a)<=Max(Abs(a),Abs(b))*eps) return true;
	return false;
}
static int Main(){
	
	//Max/Min representable integers
	int i=1;
	while(i+1>i){i++;}
	Write($"Maximum representable integer is {i}, int.MaxValue={int.MaxValue}.\n");
	i=0;
	while(i-1<i){i--;}
	Write($"Minimal representable integer is {i}, int.MinValue={int.MinValue}.\n");

	// Machine-espilon
	double x=1;
	do{x/=2;}while(1+x!=1);
	x*=2;
	Write($"Machine epsilon for double is {x}. Sytem.Math.Pow(2,-52)={System.Math.Pow(2,-52)}. \n");
	float y=1F;
	while((float)(1F+y)!=1F){y/=2;}
	y*=2F;
	Write($"Machine epsilon for float is {y}. System.Math.Pow(2,-23)={System.Math.Pow(2,-23)}.\n");

	//Calculating with espilon
	double ep=System.Math.Pow(2,-52);
	double tiny=ep/2;
	double a=1+tiny+tiny;
	double b=tiny+tiny+1;
	Write($"a==b? {a==b}\n");
	Write($"a>1? {a>1}\n");
	Write($"b>1? {b>1}\n");
	Write($"Explanation: tiny={tiny},1+tiny={1+tiny},tiny+tiny={tiny+tiny}.\n");

	//Comparing doubles
	double d1=0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double d2=8*0.1;
	Write($"d1={d1:e16}.\n");
	Write($"d2={d2:e16}.\n");
	Write($"d1==d2? {d1==d2}.\n");
	Write($"Comparison with approx function: d1==d2? {approx(d1,d2)}.\n");



return 0;
}

}
