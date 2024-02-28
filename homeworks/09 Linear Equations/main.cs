using System;
using static System.Console;
using static System.Random;
using static QRGS;
using static matrix;



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
		
		
	//Main function tests results of functions in funs
	public static int Main(){
		
		//creating random matrices and vector, maximum tried for decomp and solve: n=1000, m=900
		Random random = new Random();
		int n=20;
		int m=15;
		matrix A = new matrix(n,m); 
		for (int i=0;i<n;i++){
			for(int j=0;j<m;j++){
				A[i,j]=random.NextDouble();
			}
		}
		matrix A2 = new matrix(n,n);
		for (int i=0;i<n;i++){
			for(int j=0;j<n;j++){
				A2[i,j]=random.NextDouble();
			}
		}
		matrix b=new matrix(n,1); 
		for (int i=0;i<n;i++){
			b[i,0]=random.NextDouble();
		}
		
		//calling the functions decomp (Q,R will be used more than once)
		matrix Q=decomp(A)[0];	
		matrix R=decomp(A)[1];
		
		
		//Test of decomp
		Write($"A is a {n}x{m}-matrix with random entries between 0 and 1.\nFunction decomp returns R and Q s.t.:\n");
		
			//testing if R is right-triangular
		bool test=true;
		for(int i=1;i<R.size1;i++){
			for (int j=0;j<i;j++){
				if (R[i,j]!=0)test=false;
			}
		}
		if(test==false)Write("	-Error: R is not right-triangular\n");
		else Write("	-R is a right-triangular matrix \n");
		
			//testing if Q is orthogonal
		if(mApprox(E(Q.size2),mProduct(transpose(Q),Q))==false)Write("	-Error: Q is not orthogonal\n");
		else Write("	-Q is an orthogonal matrix\n");
		
			//testing if QR=A
		if(mApprox(mProduct(Q,R),A)==true)Write("	-A=QR.\n");
		else Write("	-Error: A is not equal to QR\n");
		
		
		//Test of solve
		Write($"From now on A is a {n}x{n}-matrix and b a {n}-vector, both with random entries between 0 and 1.\nFunction solve returns vector x s.t.:\n");
		if(mApprox(mProduct(A2,solve(A2,b)),b)==true)Write("	Ax=b.\n");
		else Write("	Error: Ax not equal b\n");
		
		
		//Writing out determinant
		Write($"Function det returns absolut value of determinant:\n	|det(A)|={det(A2)}.\n");
		
		
		//Test of inverse
		Write("Function inverse returns matrix B s.t.:\n");
		if(mApprox(mProduct(A2,inverse(A2)),E(A2.size1))==true)Write("	AB=1.\n");
		else Write("	-Error: AB non equal 1\n");
		
		
		/*
		//Writes out given and calculated matrices for testing reasons
		Write("A\n");
		mWrite(A);
		Write("QR\n");
		mWrite(mProduct(Q,R));
		Write("Q^TQ\n");
		mWrite(mProduct(transpose(Q),Q));
		Write("R\n");
		mWrite(R);
		Write("Q\n");
		mWrite(Q);*/
		return 0 ;
	}//Main
}//main