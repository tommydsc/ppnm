Out.txt: main.exe
	mono main.exe > Out.txt
	
main.exe: main.cs matrix.dll jacob.dll
	mcs -target:exe -out:main.exe main.cs -reference:jacob.dll,matrix.dll

matrix.dll : matrix.cs
	mcs -target:library -out:matrix.dll matrix.cs
	
jacob.dll : jacob.cs matrix.dll
	mcs -target:library -out:jacob.dll jacob.cs -reference:matrix.dll
	
clean:
	$(RM) *.exe *.dll Out*