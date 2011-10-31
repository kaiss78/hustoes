#include <iostream.h>
void fun(char* str,char* str1,char* str2)
{
    int i;
    int j;
    for(i=0;str1[i] != 0; i++)
    {
        str[i] = str1[i];
    }
    for(j=0;str2[j]!=0; i++,j++)
    {
        str[i] = str2[j];
    }
    str[i] = 0;
}
void main()
{
	char str[1024];
	char* str1 = "abcaeraertAAAA";
	char* str2 = "AAAAasdart";
	fun(str,str1,str2);
	cout<<str<<endl;
	return;
}
