Out.gnuplot.svg: input.txt Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "t" ;\
		set ylabel "logarithm of decay log(y(t))" ;\
		set mxtics 2 ;\
		set grid ;\
		set grid mxtics ;\
		set title "radiocative decay" ;\
		f(x)=log(143.057705031799)-0.171852690707342*x;\
		plot \
			"$<" u 1:(log($$2)):(($$3)/($$2)) w ye pointtype 2 notitle \
			,"Out.txt" u 1:2 with lines notitle \
	' | tee log.gpi  | gnuplot

Out.txt: main.exe
	mono main.exe $< <input.txt> $@ > Out.txt
	
main.exe: main.cs matrix.dll funs.dll fit.dll
	mcs -target:exe -out:main.exe main.cs -reference:funs.dll,matrix.dll,fit.dll

matrix.dll : matrix.cs
	mcs -target:library -out:matrix.dll matrix.cs
	
funs.dll : funs.cs matrix.dll
	mcs -target:library -out:funs.dll funs.cs -reference:matrix.dll
	
fit.dll: fit.cs matrix.dll funs.dll
	mcs -target:library -out:fit.dll fit.cs -reference:matrix.dll,funs.dll



clean:
	$(RM) *.exe *.dll Out* log*