//doesnt work - gets into wrong filename argument
using System;
using static System.Math;
using static System.Console;
class main{
public static int Main(string[] args){
	string infile=null,outfile=null;
	char[] split_delimiters = {' ','\t','\n',':'};
	var split_options = StringSplitOptions.RemoveEmptyEntries;
	foreach(var arg in args){
		var words=arg.Split(split_delimiters,split_options);
		infile=words[1];
		outfile=words[3];
	}
	if(infile==null || outfile==null) {
		Error.WriteLine("wrong filename argument");
		return 1;
	}
	var instream =new System.IO.StreamReader(infile);
	var outstream=new System.IO.StreamWriter(outfile,append:false);
	for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
		double x=double.Parse(line);
		outstream.WriteLine($"{x} {Sin(x)} {Cos(x)}");
    }
	instream.Close();
	outstream.Close();
	return 0;
	}//Main
}//main