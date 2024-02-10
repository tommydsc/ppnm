using System;
using static System.Console;
using static System.Math;

class main{
	
public static int Main(){
	//check of constructors
	double c=7;
	vec u=new vec(1,2,3);
	vec v=new vec(2,3,5);
	
	
	//check of operators
	Write($"{c}*({u})=({c*u})\n({u})*{c}=({u*c})\n({u})+({v})=({u+v})\n-({u})=({-u}) \n({v})-({u})=({v-u})\n");
	
	
	//check of methods
	Write($"({u})*({v})={u.dot(v)}\n({u})*({v})={vec.dot(u,v)}\n");
	
	double x1=0; double x2=0;
	double y1=1; double y2=1;
	double z1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double z2 = 8*0.1;
	
	
	u=new vec(x1,y1,z1);v=new vec(x2,y2,z2);
	
	Write($"({u.x} {u.y} {u.z:e15})=({v.x} {v.y} {v.z:e15})?{vec.approx(u,v)}\n");
	
	x1=0; x2=0;
	y1=1.1; y2=1;
	z1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	z2 = 8*0.1;
	
	
	u=new vec(x1,y1,z1);v=new vec(x2,y2,z2);
	
	Write($"({u.x} {u.y} {u.z:e15})=({v.x} {v.y} {v.z:e15})?{vec.approx(u,v)}\n");
	
	
	
	
	
	
return 0;
}//Main
}//main