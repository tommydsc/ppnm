using System;
using static System.Console;
using static System.Math;
using static matrix;
using static QRGS;
static public class LSD{
	
	public static matrix lsfit(Func <double,double>[]fs, double[] x, double[] y, double[] dy) {
		int n=0;
		if(x.Length==y.Length&&x.Length==dy.Length) n=x.Length ;
		else Write("Dimension error in data points\n");
		int m=fs.Length;
		matrix A=new matrix(n,m);
		matrix b=new matrix(n,1);
		
		for(int i=0;i<n;i++){
			b[i,0]=y[i]/dy[i];
			for (int j=0;j<m;j++){
				A[i,j]=fs[j](x[i])/dy[i];
			}
		}
		
		return solve(A,b);
	}
	
		
} //LSD