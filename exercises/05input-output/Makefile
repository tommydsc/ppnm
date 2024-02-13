default:Out.txt Std.txt Output.txt

Out.txt:main.exe
	mono main.exe -numbers:1,2,3,4,5:6,7,8,9,10 > Out.txt

Std.txt:std.exe input
	mono std.exe $< <input 1> $@ 2>Std.txt
	
Output.txt: io.exe
	mono io.exe -input:input.txt -output:output.txt > Output.txt

main.exe: main.cs
	mcs -target:exe -out:$@ $<
	
std.exe: std.cs
	mcs -target:exe -out:$@ $<
	
io.exe: io.cs
	mcs -target:exe -out:$@ $<
