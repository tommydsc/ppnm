
class main {

public static int Main(string[] args){
	long nterms=(long)9e8;
	foreach(string arg in args){
		var words = arg.Split(':');
		if(words[0]=="-nterms")nterms=(long)double.Parse(words[1]);
	}
	
	double sum=0;
	System.Threading.Tasks.Parallel.For( 1, N+1, (int i) => sum+=1.0/i );
	
	System.Console.Write($"main-for: total sum = {sum}\n");
	

return 0;
}//Main


}//main