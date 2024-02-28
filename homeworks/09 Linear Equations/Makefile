Out.txt: main.exe
	mono main.exe > Out.txt
	
main.exe: main.cs matrix.dll funs.dll
	mcs -target:exe -out:main.exe main.cs -reference:funs.dll,matrix.dll

matrix.dll : matrix.cs
	mcs -target:library -out:matrix.dll matrix.cs
	
funs.dll : funs.cs matrix.dll
	mcs -target:library -out:funs.dll funs.cs -reference:matrix.dll
	
clean:
	$(RM) *.exe *.dll Out*