using static System.Console;
using static System.Math;
using static matrix;
static public class QRGS{
	
	//function decomp returns (Q,R) of A=QR
	public static matrix[] decomp(matrix A){
		matrix B = new matrix(A.size1,A.size2); //copy the matrix elementwise, to makesure not to change A
		for (int i=0;i<A.size1;i++){
			for(int j=0;j<A.size2;j++){
				B[i,j]=A[i,j];
			}
		}
		if (B.size1<B.size2){
			Write("Dimension Error in decomposition.\n");
		}
		matrix R=new matrix(B.size2,B.size2);
		matrix Q=new matrix(B.size1,B.size2);
		for(int i=0;i<B.size2;i++){ //Gram-Schmidt
			R[i,i]=cNorm(B,i);
			for (int k=0;k<B.size1;k++){
				Q[k,i]=B[k,i]/R[i,i];
			}
			for (int j=i+1;j<B.size2;j++){
				R[i,j]=mColProduct(Q,i,B,j);
				for(int k=0;k<B.size1;k++){
					B[k,j]+= -R[i,j]*Q[k,i];
				}
			}
		}
		
		matrix[] decomp=new matrix[2];
		decomp[0]=Q;
		decomp[1]=R;		
		return decomp;
	}
	
	
	//function solve returns vector x s.t. Rx=Q^tb (for squared A: Ax=b)
	public static matrix solve(matrix A,matrix b){
		if(A.size1!=b.size1 || b.size2!=1){
			Write($"Dimension Error in solve function.\n {A.size1}{A.size2}{b.size1}{b.size2}");
		}
		
		matrix Q=decomp(A)[0];	//calls function for QR-decomposition	
		matrix R=decomp(A)[1];
		matrix x=new matrix(A.size2,1);
		double s=0;
		
		for (int i=A.size2-1;i>-1;i--){
			s=0;
			for (int k=i+1;k<A.size2;k++){
				s+=R[i,k]*x[k,0];
			}
			x[i,0]=(mProduct(transpose(Q),b)[i,0]-s)/R[i,i];
		}
		
		return x;
	}
	
	//function det returns abs value of determinant of matrix A
	public static double det(matrix A){
		if(A.size1!=A.size2){
			Write("Dimension Error in det function.\n");
		}
		double d=1;
		matrix R=decomp(A)[1];
		for(int i=0;i<R.size1;i++){
			d*=R[i,i];
		}
		return Abs(d);
	}
	
	//function inverse returns inverse of matrix A
	public static matrix inverse(matrix A){
		if(A.size1!=A.size2){
			Write("Dimension Error in inverse function with returned matrix.\n");
			return A;
		}
		matrix B=new matrix(A.size1,A.size2);
		matrix Q=decomp(A)[0];
		matrix R=decomp(A)[1];
		matrix b= new matrix(A.size1,1);
		for(int j=0;j<A.size1;j++){
			for(int k=0;k<A.size1;k++){
				b[k,0]=Q[j,k];
			}
			for(int i=0;i<A.size1;i++){
				B[i,j]=solve(R,b)[i,0];
			}
		}
		return B;		
	}
		
} //QRGS