using System;
using static System.Math;
using static System.Console;
class main{
public static void Main(){
//using standard input and Error - Eingabe
	char[] split_delimiters = {' ','\t','\n'};
	var split_options = StringSplitOptions.RemoveEmptyEntries;
	for(string line = ReadLine(); line != null;line =ReadLine()){
		var numbers = line.Split(split_delimiters,split_options);
		Error.WriteLine("x Sin(x) Cos(x)\n");
		foreach(var number in numbers){
			double x = double.Parse(number);
			Error.WriteLine($"{x} {Sin(x)} {Cos(x)}\n"); //standard Error file in Makefile set as out.txt by adding 2
        }
    }
	}//Main
}//main