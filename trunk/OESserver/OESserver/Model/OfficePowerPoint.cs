namespace OES.Model
{
    internal class OfficePowerPoint : Problem
    {
        public string ansPath;
        public string rawPath;
        public string stuAnsPath;

        public OfficePowerPoint()
        {
            type = "PowerPoint操作题";
        }

        public OfficePowerPoint(string p)
        {
            problem = p;
            type = "PowerPoint操作题";
        }

        public OfficePowerPoint(string rawPath, string ansPath, string stuAnsPath)
        {
            this.ansPath = ansPath;
            this.rawPath = rawPath;
            this.stuAnsPath = stuAnsPath;
            type = "PowerPoint操作题";
        }
    }
}