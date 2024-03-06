using System;
using static System.Console;
using System.Collections.Generic;
using static Inter;

class main{
	
	public static int Main(){
		char[] split_delimiters = {' ','\t','\n'};
		var split_options = StringSplitOptions.RemoveEmptyEntries;
		int k=0;
		var xL = new List<double>();		
		var yL = new List<double>();
		for(string line = ReadLine(); line != null;line=ReadLine()){
			var numbers = line.Split(split_delimiters,split_options);
			xL.Add(double.Parse(numbers[0]));
			yL.Add(double.Parse(numbers[1]));
			k++;
		}
		double[] x = new double[k];
		double[] y = new double[k];
		for (int i=0;i<k;i++){
			x[i]=xL[i];
			y[i]=yL[i];
		}
		
		
		double d=0.05;
		for(double z=x[0];z<=x[k-1];z+=d){
			Write($"{z}	{linterp(x,y,z)} {linterpInteg(x,y,z)}\n");
		}
		
		
		return 0;
	}//Main
}//main