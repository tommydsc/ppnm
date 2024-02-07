Out.txt: main.exe make.exe
	mono main.exe > Out.txt
	mono make.exe >> Out.txt

main.exe: main.cs
	mcs -target:exe -out:$@ $<

make.exe: make.cs
	mcs -target:exe -out:$@ $<

clean:
	$(RM) main.exe, Out.txt

