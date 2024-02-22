CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output=$@ --append --format "$$nthreads %e %U"

N=9e8

Out.txt : main.exe Makefile
		>$@
		$(TIME) mono $< -terms:$N -threads:1 >>$@
		$(TIME) mono $< -terms:$N -threads:2 >>$@
		$(TIME) mono $< -terms:$N -threads:3 >>$@
		$(TIME) mono $< -terms:$N -threads:4 >>$@
		$(TIME) mono $< -terms:$N -threads:5 >>$@
		$(TIME) mono $< -terms:$N -threads:6 >>$@
		$(TIME) mono $< -terms:$N -threads:7 >>$@
		$(TIME) mono $< -terms:$N -threads:8 >>$@

main.exe : main.cs ; $(MKEXE)

Out-for.txt: main.exe
		>$@
		$(TIME) mono $< -nterms:$N  >>$@
	

main-for.exe: main-for.cs;$(MKEXE)

Out-linq.txt: main.exe
		>$@
		$(TIME) mono $< -nterms:$N  >>$@
	

main-linq.exe: main-linq.cs;$(MKEXE)

clean:	
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*