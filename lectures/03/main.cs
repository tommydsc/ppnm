using static System.Console;
class main{
static int Main(){
	double x=2,y=1;
	if(x>y) Write("x>y\n");
	/* //some problems with syntax
	else Write("x<=\n");
	for (int i=1;i<10;++i) Write($"i={i}\n"); //first use i then ++, first ++ then use i
	i=0;
	do {Write("i={i}\n";i++;} while (i<10;);//first du then check for doing again
	i=0;
	while($"i={i}\n";) {Write("i={i}\n";i++;};	       //check first then do
	*/
	int n=5;
	double[] a=new double[n]; //array (is a class) must start with new
	for(int i=0;i<n;i++)a[i]=i+1;
	for(int i=0;i<n;i++) Write($"a[i]={a[i]}\n");
	foreach(double ai in a) Write($"ai={ai}\n");
	return 0;
} //Main
}  //class main
