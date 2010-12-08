namespace OES.Model
{
    internal class PModif : Problem
    {
        public string ans1, ans2, ans3;
        public string path;

        public PModif()
        {
            type = "程序改错题";
        }

        public PModif(string p)
        {
            problem = p;
            ans1 = "";
            ans2 = "";
            ans3 = "";
            type = "程序改错题";
        }
    }
}