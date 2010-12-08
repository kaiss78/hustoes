namespace OES.Model
{
    internal class Judge : Problem
    {
        public string ans, stuAns;

        public Judge()
        {
            type = "判断题";
        }

        public Judge(string p)
        {
            problem = p;
            stuAns = "";
            ans = "";
            type = "判断题";
        }
    }
}