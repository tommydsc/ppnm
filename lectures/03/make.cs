using static System.Console;
public class myclass { public string s; }
struct mystruct { public string s; }
class main{
static void setto7(double x){x=7;}
static void setto7(double[] tmp){for (int i=0;i<tmp.Length;i++)tmp[i]=7;}
static int Main(){
	myclass A=new myclass();
	mystruct a;
	a=new mystruct();
	A.s="hello";
	a.s="hello";
	WriteLine($"A.s={A.s}");
	WriteLine($"a.s={a.s}");
	myclass B=A; //copyconstructor B and A refer to same object
	mystruct b=a; //whole object is created and moved into b
	WriteLine($"B.s={B.s}");
	WriteLine($"b.s={b.s}");
	B.s="new string"; //changes A, too!
	b.s="new string";
	WriteLine($"A.s={A.s}");
	WriteLine($"a.s={a.s}");
	
	double x=1;
	setto7(x);
	Write($"x={x}\n"); //writes 1, 7 is just in function

	double[] v = new double[5];
	setto7(v);
	foreach(var vi in v)Write(vi); //writes 7
	Write("\n");
	
return 0;


}

}
