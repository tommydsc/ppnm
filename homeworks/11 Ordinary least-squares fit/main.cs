using System;
using static System.Console;
using static System.Random;
using static System.Math;
using static QRGS;
using static matrix;
using static LSD;



class main{
	
	//function to write out matrices for testing reasons
	public static void mWrite(matrix B){
		for (int i=0;i<B.size1;i++){
			for (int j=0;j<B.size2;j++){
				Write($"{B[i,j]}	");
			}
			Write($"\n");
		}
	}
		
		
	//Main function tests results of functions in fit
	public static int Main(){
		//Reading of data, y logarithmic
		double[] x=new double[9];
		double[] y=new double[9];
		double[] dy=new double[9];
		
		char[] split_delimiters = {' ','\t','\n'};
		var split_options = StringSplitOptions.RemoveEmptyEntries;
		int k=0;
		for(string line = ReadLine(); line != null;line =ReadLine()){
			var numbers = line.Split(split_delimiters,split_options);
			x[k]=double.Parse(numbers[0]);
			y[k]=Log(double.Parse(numbers[1]));
			dy[k]=Abs(double.Parse(numbers[2])/y[k]);
			k++;
		}
		var fs = new Func<double,double>[] {z => 1.0, z => -z}; //logarithm of fitfunction
		matrix c=lsfit(fs,x,y,dy);
		Write($"#a={Exp(c[0,0])}, lambda={c[1,0]}\n");
			
		double d=0.05;
		for(double z=x[0];z<=x[k-1];z+=d){
			Write($"{z}	{c[0,0]-c[1,0]*z} \n");
		}
		
		
		/*test of lsfit with well-known function
		var fs = new Func<double,double>[] { z => 1.0, z => z, z => z*z };
		matrix x= new matrix (4,1);
		matrix y = new matrix (4,1);
		matrix dy = new matrix (4,1);
		x[0,0]=-7;x[1,0]=1;x[2,0]=5; x[3,0]=-10;
		y[0,0]=7;y[1,0]=-4;y[2,0]=13; y[3,0]=19;
		dy[0,0]=1;dy[1,0]=2;dy[2,0]=5;dy[3,0]=0.001;
		mWrite(lsfit(fs,x,y,dy));*/
		
		
		return 0;
	}//Main
}//main