#include<iostream.h>
/********found********/
#define PI  3.1416

double area(double r=0)
{
	return PI*r*r;
}
/********found********/
double area(double a,double b)
{
/********found********/
	return a*b;
}
void main()
{
	cout<<"Area of point is "<<area(10)<<endl;
	cout<<"Area of point is "<<area(10,20)<<endl;
}
