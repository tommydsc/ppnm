using static System.Console;
using static System.Math;

public class matrix{
	public readonly int size1,size2;
	private double[] data;  // to keep matrix elements
	public matrix(int n,int m){      // constructor
		size1=n; size2=m;
		data = new double[size1*size2];
		}
	public double this[int i,int j]{     // indexer
		get => data[i*size2+j];
		set => data[i*size2+j]=value;
		}
		
		
	//returns matrix product of D and B
	public static matrix mProduct (matrix D, matrix B){ 
		if (D.size2!=B.size1){
			Write("Dimension Error");
			matrix E=new matrix(1,1);
			return E;
		}
		matrix C=new matrix(D.size1,B.size2);
		for(int i=0;i<D.size1;i++){
			for(int j=0;j<B.size2;j++){
				for(int k=0;k<D.size2;k++){
					C[i,j]+=D[i,k]*B[k,j];
				}
			}
		}
		return C;
	}
	
	
	 //returns dot product of D_i times B_j (colums of D,B respectively)
	public static double mColProduct(matrix D, int i, matrix B, int j){
		if (D.size1!=B.size1){
			Write("Dimension Error");
			return 0;
		}
		double sum=0;
		for (int k=0;k<D.size1;k++){
			sum+=D[k,i]*B[k,j];
		}
		return sum;
	}
	
	
	//returns vector norm of jth column of D
	public static double cNorm(matrix D, int j){ 
		if (D.size2<j){
			Write("Dimension Error");
			return 0;
		}
		double c=0;
		for (int i=0;i<D.size1;i++){
			c+=D[i,j]*D[i,j];
		}
		return Sqrt(c);
	}
	
	
	//transposing matrix
	public static matrix transpose(matrix D){
		matrix T=new matrix (D.size2,D.size1);
		for(int i=0;i<D.size2;i++){
			for (int j=0; j<D.size1;j++){
				T[i,j]=D[j,i];
			}
		}
		return T;
	}
	
	//approx function form pervious exercise
	public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(b-a)<=acc) return true;
		if(Abs(b-a)<=Max(Abs(a),Abs(b))*eps) return true;
		return false;
	}
	
	//aporx funciton for matrices
	public static bool mApprox(matrix D, matrix B){
		if(D.size1!=B.size1||D.size2!=B.size2)return false;
		for (int i=0;i<D.size1;i++){
			for (int j=0;j<D.size2;j++){
				if (approx(D[i,j],B[i,j])==false)return false;
			}
		}
		return true;
	}
	
	//definition of One-Matrix
	public static matrix E(int n){
		matrix E=new matrix(n,n); 
		for (int i=0;i<n;i++){
			E[i,i]=1; 
		}
		return E;
	}
}