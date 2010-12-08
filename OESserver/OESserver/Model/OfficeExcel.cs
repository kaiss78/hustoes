namespace OES.Model
{
    internal class OfficeExcel : Problem
    {
        public string ansPath;
        public string rawPath;
        public string stuAnsPath;

        public OfficeExcel()
        {
            type = "Excel操作题";
        }

        public OfficeExcel(string p)
        {
            problem = p;
            type = "Excel操作题";
        }

        public OfficeExcel(string rawPath, string ansPath, string stuAnsPath)
        {
            this.ansPath = ansPath;
            this.rawPath = rawPath;
            this.stuAnsPath = stuAnsPath;
            type = "Excel操作题";
        }
    }
}