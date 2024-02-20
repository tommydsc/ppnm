class main{
	public static int Main(){
		
		
		
		for(double x=1.0/128;x<=5;x+=1.0/128){
			System.Console.WriteLine($"{x}	{sfuns.erf(x)}	{sfuns.gamma(x)}  {sfuns.lngamma(x)}");
		}
		
		for(double x=-5;x<=0;x+=1.0/128){
			System.Console.WriteLine($"{x}	{sfuns.erf(x)}	{sfuns.gamma(x)} ");
		}
	return 0;
	}
}