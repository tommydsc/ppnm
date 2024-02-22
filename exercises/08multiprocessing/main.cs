class main{

public class data { public int a,b; public double sum;}


public static void harm(object obj){
	var arg = (data)obj;
	arg.sum=0;
	for(int i=arg.a;i<arg.b;i++)arg.sum+=1.0/i;
}



public static int Main(string[] args){
	int nthreads = 1, nterms = (int)2e8; 
	foreach(var arg in args) {
		var words = arg.Split(':');
		if(words[0]=="-threads") nthreads=int.Parse(words[1]);
		if(words[0]=="-terms" ) nterms  =(int)float.Parse(words[1]);
	}
	data[] param = new data[nthreads];
	for(int i=0;i<nthreads;i++) {
		param[i] = new data();
		param[i].a = 1 + nterms/nthreads*i;
		param[i].b = nterms/nthreads*(i+1);
		System.Console.Write($"{nthreads}.{i+1} {param[i].a} {param[i].b}\n");
	}
	
	var threads = new System.Threading.Thread[nthreads];
	for(int i=0;i<nthreads;i++) {
		threads[i] = new System.Threading.Thread(harm); 
		threads[i].Start(param[i]); 
	}
	
	foreach(var thread in threads) thread.Join();
	
	double total=0; foreach(var p in param) total+=p.sum;
	
	
	System.Console.Write($"main: total sum = {total}\n");
	

return 0;
}

}