Out.txt: main.exe
	mono main.exe $< <input.txt 1> $@ 2> Out.txt
	
main.exe: main.cs
	mcs -target:exe -out:$@ $<