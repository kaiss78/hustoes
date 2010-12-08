namespace OES.Model
{
    internal class Choice : Problem
    {
        public string ans;
        public string optionA;
        public string optionB;
        public string optionC;
        public string optionD;
        public string stuAns;

        public Choice()
        {
            type = "选择题";
        }

        public Choice(string p, string oa, string ob, string oc, string od)
        {
            problem = p;
            optionA = oa;
            optionB = ob;
            optionC = oc;
            optionD = od;
            stuAns = "";
            ans = "";
            type = "选择题";
        }
    }
}