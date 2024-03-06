Out.gnuplot.svg: input.txt Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left bottom ;\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set mxtics 2 ;\
		set grid ;\
		set grid mxtics ;\
		set title "Linear Interpoaltion and Integral" ;\
		plot \
			"$<" u 1:2 pointtype 2 notitle \
			,"Out.txt" u 1:2 with lines title "linear Interpolation"\
			,"Out.txt" u 1:3 with lines title "Integral"\
	' | tee log.gpi  | gnuplot

Out.txt: main.exe
	mono main.exe $< <input.txt> $@ > Out.txt
	
main.exe: main.cs lint.dll
	mcs -target:exe -out:main.exe main.cs -reference:lint.dll

lint.dll : lint.cs
	mcs -target:library -out:lint.dll lint.cs
	
clean:
	$(RM) *.exe *.dll Out* log*