using System;
using static System.Console;
using static System.Random;
using static matrix;
using static Jacobi;



class main{
	
	//function to write out matrices for testing reasons
	public static void mWrite(matrix B){
		for (int i=0;i<B.size1;i++){
			for (int j=0;j<B.size2;j++){
				Write($"{B[i,j]}	");
			}
			Write($"\n");
		}
		Write($"\n");
	}

	public static int Main(){
		
		//creating random symmetric squared matrix and copy that can be changed
		Random random = new Random();
		int n=100; //maximum tried: 1000
		matrix A = new matrix(n,n);
		matrix B = new matrix (n,n);		
		for (int i=0;i<n;i++){
			A[i,i]=random.NextDouble();
			B[i,i]=A[i,i];
			for(int j=0;j<i;j++){
				A[i,j]=random.NextDouble();
				A[j,i]=A[i,j];
				B[i,j]=A[i,j];
				B[j,i]=A[i,j];
			}
		}
		
		//calling function cyclic since output is needed more than once
		matrix V=new matrix(n,n);
		matrix D=new matrix(n,n);
		matrix[] DV = new matrix[2]; //function cyclic should be called just once!
		DV=cyclic(A);
		D=DV[0];
		V=DV[1];
		
		//testing of the functions
		
		Write($"A is a symmetric {n}x{n}-matrix with random entries between 0 and 1.\nFunction cyclic returns D and V s.t.:\n");
		
			//V^tAV=Dz
		if(mApprox(mProduct(mProduct(transpose(V),B),V),D)==true)Write("	-V^tAV=D\n");
		else Write("	-Error: V^tAV not equal D\n");
		
			//VDV^t=A
		if(mApprox(mProduct(mProduct(V,D),transpose(V)),B)==true)Write("	-VDV^t=A\n");
		else Write("	-Error: VDV^t not equal A\n");
		
			//V^tV=1
		if(mApprox(mProduct(transpose(V),V),E(V.size1))==true) Write("	-V^tV=1\n");
		else Write("	-Error: V^tV nto equal 1\n");
		
			//VV^t=1
		if(mApprox(mProduct(V,transpose(V)),E(V.size1))==true) Write("	-VV^t=1.\n");
		else Write("	-Error: V^tV nto equal 1.\n");
		
		
		/*	//Diagonality of D - just approximately: The higher the n the bigger the absolut value of non-diagonal entries of D  
		bool test=true;
		for(int i=0;i<D.size1;i++){
			for (int j=0;j<i;j++){
				if(approx(D[i,j],0)==false)test=false;
			}
			for (int j=i+1;j<D.size2;j++){
				if(approx(D[i,j],0)==false)test=false;
			}
		}
		
		if(test==true)Write("	-D is diagonal matrix\n");
		else Write("	-Error: D is not diagonal\n"); */
		
		
		/*	//Writes out given and calculated matrices for testing reasons
		Write("A\n");
		mWrite(A);;*/
		return 0 ;
	}//Main
}//main