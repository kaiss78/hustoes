namespace OESserver
{
    internal class Student
    {
        public static string sName;
        public static string ID;
        public static string examID;
        public static string password;

        public Student(string name, string examid, string id, string pword)
        {
            sName = name;
            examID = examid;
            ID = id;
            password = pword;
        }
    }
}