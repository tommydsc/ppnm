Out.txt : hello.exe              # Out.txt depends on hello.exe
	mono hello.exe > Out.txt # run hello.exe, send output to Out.txt

hello.exe : hello.cs             # hello.exe depends on hello.cs
	mcs hello.cs             # compile hello.cs into hello.exe

.PHONEY:clean
clean:                           # a phoney target, no dependencies
	rm -f Out.txt hello.exe  # remove secondary files