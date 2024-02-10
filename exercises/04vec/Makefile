Out.txt: main.exe 
	mono main.exe > Out.txt
	
main.exe: main.cs vec.dll
	mcs -target:exe -out:main.exe main.cs -reference:vec.dll vec.cs

vec.dll: vec.cs
	mcs -target:library -out:vec.dll vec.cs
