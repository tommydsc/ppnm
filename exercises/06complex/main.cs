using System;
using static System.Console ;
using static System.Numerics.Complex;
using static System.Math;

class main{
	public static string print(System.Numerics.Complex z){
		return $"{z.Real}+{z.Imaginary}i";
	}
	
	public static bool approx(System.Numerics.Complex a, System.Numerics.Complex b, double acc=1e-9, double eps=1e-9){
	if(Abs(b.Real-a.Real)+Abs(b.Imaginary-a.Imaginary)<=2*acc) return true;
	if(Abs(b.Real-a.Real)<=Max(Abs(a.Real),Abs(b.Real))*eps && Abs(b.Imaginary-a.Imaginary)<=Max(Abs(a.Imaginary),Abs(b.Imaginary))*eps) return true;
	return false;
}
	
	public static int Main(){
	var I=ImaginaryOne ; // alternatively to var: System.Numerics.Complex
	
	/*var z=1+I;
	Write($"{z}\n");
	Write(print(z)");*/
	
	Write($"sqrt(-1)=");Write(print(Sqrt(-1+0*I)));Write($"? {approx(Sqrt(-1+0*I),0+I)} \n");
	Write($"sqrt(i)=");Write(print(Sqrt(I)));Write($"? {approx(Sqrt(I),1/Sqrt(2)+I*1/Sqrt(2))}. \n");
	Write($"e^i=");Write(print(Exp(I)));Write($"? {approx(Exp(I),Cos(1)+I*Sin(1))}.\n");	
	Write($"i^i=");Write(print(Exp(I*Log(I))));Write($"? {approx(Exp(I*Log(I)),Exp(-PI/2))}.\n");
	Write($"ln(i)=");Write(print(Log(I)));Write($"? {approx(Log(I),I*PI/2)}.\n");
	Write($"sin(i pi)=");Write(print(Sin(I*PI)));Write($"? {approx(Sin(I*PI),(Exp(-PI)-Exp(PI))/(2*I))}. \n");
	
	return 0;	
	}
}