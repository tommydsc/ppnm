public class Inter{
	public static int binsearch(double[] x, double z){
		if(!(x[0]<=z && z<=x[x.Length-1]));
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}
	
	public static double linterp(double[] x, double[] y, double z){
        int i=binsearch(x,z);
        double dx=x[i+1]-x[i];
        double dy=y[i+1]-y[i];
        return y[i]+dy/dx*(z-x[i]);
    }
	
	public static double linterpInteg(double[]x,double[]y,double z){
		double Int=0;
		int i=binsearch(x,z);
		for(int k=0;k<i;k++){
			Int+=(x[k+1]-x[k])*(y[k+1]+y[k])/2;
		}
		Int+=(z-x[i])*(linterp(x,y,z)+y[i])/2;
		
		return Int;
	}
}