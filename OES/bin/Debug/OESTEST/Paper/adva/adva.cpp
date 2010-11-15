#include <iostream.h>
#define MaxLen 1024
class CMyClass
{
private:
	//********1********
	char scr[MaxLen]; char des[MaxLen];
	public:
	
	CMyClass(char* str=NULL)
	{
		int i;
		//********2********
		for(i=0;str!=NULL && str[i]!= NULL; i++) scr[i] = str[i];
		scr[i] = 0;
	}
		static void fun(char* des,char* str)
	{
		int strlen ;
        for( strlen =0; str[strlen] != 0; strlen++ );
        des[strlen] = 0;
        for(int i=0; i<strlen; i++)
        {
  		//********3********
          des[i] = str[strlen-i-1];
        }
	}
	char* fun()
	{
		//********4********
		fun(des,scr);
		return des;
	}
};
void main() 
{
	char str[MaxLen];
	char des[MaxLen];
	cout<<"please input a string: ";
	cin.getline(str,MaxLen);
	CMyClass obj(str);
	cout<<obj.fun()<<endl;
	CMyClass::fun(des,str);
	cout<<des<<endl;
}
