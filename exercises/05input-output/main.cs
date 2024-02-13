using System;
using static System.Math;
using static System.Console;
class main{
public static void Main(string[] args){
	//argument in Makefile
	foreach(string arg in args){
	var words = arg.Split(':');
		WriteLine("x Sin(x) Cos(x)\n");
		var numbers=words[1].Split(',');
		foreach(var number in numbers){
			double x=double.Parse(number);
			WriteLine($"{x} {Sin(x)} {Cos(x)}\n");
		}
		WriteLine("x Exp(x) Log(x)\n");
		numbers=words[2].Split(',');
		foreach(var number in numbers){
			double x=double.Parse(number);
			WriteLine($"{x} {Exp(x)} {Log(x)}\n");
		}
	}
}//Main
}//main