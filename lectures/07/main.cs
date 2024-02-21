class main{
	
public class harmdata{public int a,b; public double sum;}
	
	public static void harm(object obj){
		harmdata d = (harmdata)obj;
		d.sum=0;
		System.Console.Write($"harm: a={d.a} b={d.b}\n");
		for (int i=d.a;i<=d.b;i++)d.sum+=1.0/i;
		System.Console.Write($"harm: sum={d.sum} \n");
	}
	
	public static int Main(string[] args){
		/*harmdata datum = new harmdata();
		datum.a=1;
		datum.b=10000;
		harm(datum);
		datum.sum;*/
		
		int nterms =(int)1e7,nthreads=1;
		foreach(string arg in args){
			var words=arg.Split(':');
			if (words[0]=="-nterms")nterms=(int)double.Parse(words[1]);
			if (words[0]=="-nthreads")nthreads=(int)double.Parse(words[1]);
		}
		System.Console.Write($"Main: nterms={nterms} nthreads={nthreads}\n");
		harmdata[] data = new harmdata[nthreads];
		int chunk=nterms/nthreads;
		for(int i=0;i<nthreads;i++){
			data[i] = new harmdata();
			data[i].a=i*chunk+1;
			data[i].b=data[i].a+chunk;
		}
		data[nthreads-1].b=nterms;
		var threads = new System.Threading.Thread[nthreads];
		System.Console.Write($"Main:starting threads\n");
		for(int i=0;i<nthreads;i++){
			threads[i]=new System.Threading.Thread(harm);
			threads[i].Start(data[i]);
		}
		System.Console.Write($"Main: waiting for finishing threads\n");
		foreach(var thread in threads)thread.Join();
		double total=0;
		foreach(harmdata datum in data)total+=datum.sum;
		System.Console.Write($"Main: total sum = {total}\n");
		
	return 0;
	}
}