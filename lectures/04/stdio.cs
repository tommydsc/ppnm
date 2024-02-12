class main{
	static int Main(){

	double x=7;	
	System.Console.Out.Write($"this goes to stdout: x={x}\n");
	System.Console.Error.Write($"this goes to stderr: x={x}\n");
	
	string line=System.Console.In.ReadLine(); //Standard input is connected to keyboard, waits for input
	System.Console.Error.Write($"this also goes to stderr: line={line}\n");
	x=double.Parse(line); //turns string into double
	System.Console.Out.Write($"this goes to stdout: x={x}\n");
	
	
	
	
	
	return 0;
	}
}
