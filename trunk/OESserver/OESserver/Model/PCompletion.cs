namespace OES.Model
{
    internal class PCompletion : Problem
    {
        public string ans1, ans2, ans3;
        public string path;

        public PCompletion()
        {
            type = "程序填空题";
        }

        public PCompletion(string p)
        {
            problem = p;
            ans1 = "";
            ans2 = "";
            ans3 = "";
            type = "程序填空题";
        }
    }
}