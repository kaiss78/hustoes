namespace OES.Model
{
    internal class PFunction : Problem
    {
        public string inp1, inp2, inp3, outp1, outp2, outp3;
        public string path;

        public PFunction()
        {
            type = "程序综合题";
        }

        public PFunction(string p)
        {
            problem = p;
            inp1 = "";
            inp2 = "";
            inp3 = "";
            outp1 = "";
            outp2 = "";
            outp3 = "";
            type = "程序综合题";
        }
    }
}