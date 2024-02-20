CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

default: Out.erf.gnuplot.svg Out.gamma.gnuplot.svg Out.lngamma.gnuplot.svg 

Out.erf.gnuplot.svg : Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "erf(x)" ;\
		set grid ;\
		set title "Error function" ;\
		plot [-3:3]\
			 "$<" with lines notitle \
			,"erf.data.txt" using 1:2 with points pointtype 6 notitle \
			,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 6 notitle ;\
	' | tee log.erf.gpi  | gnuplot


Out.gamma.gnuplot.svg: Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "gamma(x)" ;\
		set mxtics 2 ;\
		set grid ;\
		set grid mxtics ;\
		set title "Gamma function" ;\
		set yrange [-5:5];\
		plot [-5:5]\
			"$<" u 1:3 with lines notitle \
			,"gamma.data.txt" using 1:2 with points pointtype 6 notitle \
	' | tee log.gamma.gpi  | gnuplot
	
Out.lngamma.gnuplot.svg: Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left ;\
		set xlabel "x" ;\
		set ylabel "lngamma(x)" ;\
		set mxtics 2 ;\
		set grid ;\
		set grid mxtics ;\
		set title "Log of Gamma function" ;\
		set yrange [-5:5];\
		plot [-5:5]\
			"$<" u 1:4 with lines notitle \
	' | tee log.lngamma.gpi  | gnuplot

Out.txt: main.exe
	mono $< > $@

sfuns.dll: sfuns.cs ; $(MKLIB)
main.exe : main.cs sfuns.dll ; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*