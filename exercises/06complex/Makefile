Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs 
	mcs -reference:System.Numerics.dll -target:exe -out:main.exe main.cs