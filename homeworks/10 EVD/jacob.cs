using static System.Math;
using static System.Console;
using static matrix;
static public class Jacobi{
	
	//multplying to the right by Jacobian
	public static void timesJ(matrix A, int p, int q, double theta){
		if(Max(p,q)>Min(A.size1,A.size2))Write("Error: p,q out of dimension of A\n");
		else{
			double c=Cos(theta),s=Sin(theta);
			for(int i=0;i<A.size1;i++){
				double aip=A[i,p],aiq=A[i,q];
				A[i,p]=c*aip-s*aiq;
				A[i,q]=s*aip+c*aiq;
			}
		}//else
	}//times J

	//multplying to the right by Jacobian
	public static void Jtimes(matrix A, int p, int q, double theta){
		if(Max(p,q)>Min(A.size1,A.size2))Write("Error: p,q out of dimension of A\n");
		else{
			double c=Cos(theta),s=Sin(theta);
			for(int j=0;j<A.size1;j++){
				double apj=A[p,j],aqj=A[q,j];
				A[p,j]= c*apj+s*aqj;
				A[q,j]=-s*apj+c*aqj;
			}
		}//else
	}//Jtimes

	public static matrix[] cyclic(matrix A){
		if(A.size1!=A.size2){
			Write("Error: Non-quadratic matrix A");
		}
		matrix V= new matrix (A.size1,A.size2);
		V=E(V.size1);
		bool changed;
		do{
			changed=false;
			for(int p=0;p<A.size1-1;p++)
			for(int q=p+1;q<A.size2;q++){
				double apq=A[p,q], app=A[p,p], aqq=A[q,q];
				double theta=0.5*Atan2(2*apq,aqq-app);
				double c=Cos(theta),s=Sin(theta);
				double new_app=c*c*app-2*s*c*apq+s*s*aqq;
				double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
				if(new_app!=app || new_aqq!=aqq) {// do rotation
					changed=true;
					timesJ(A,p,q, theta); // A←A*J 
					Jtimes(A,p,q,-theta); // A←JT*A 
					timesJ(V,p,q, theta); // V←V*J
				}
			}
		}while(changed);
		matrix[] AV=new matrix[2];
		AV[0]=A;
		AV[1]=V;
		return AV;
	}//cyclic

} //Jacobi