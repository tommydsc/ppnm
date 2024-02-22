using System.Linq ;
class main {

public static int Main(string[] args){
	long nterms=(long)9e8;
	foreach(string arg in args){
		var words = arg.Split(':');
		if(words[0]=="-nterms")nterms=(long)double.Parse(words[1]);
	}
		
	var sum = new System.Threading.ThreadLocal<double>(()=>0,trackAllValues:true);
	System.Threading.Tasks.Parallel.For(1,nterms+1,delegate(long i){sum.Value+=1.0/i;});
	double total = sum.Values.Sum();
	System.Console.Write($"main-linq: total sum = {total}\n");

return 0;
}//Main


}//main