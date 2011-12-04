using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using OES.Model;
using System.Data;

namespace OES
{
    public partial class OESData
    {
        public enum ErrorType
        {
            etIdNotFound
        };

        #region 异常处理
        public void ErrorReport(ErrorType et)
        {
            switch (et)
            { 
                case ErrorType.etIdNotFound:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 变量定义
        SqlConnection sqlcon;//定义SQL的链接
        string sqlstring; //定义SQL语句字符串
        List<Paper> paper = new List<Paper>();
        List<Problem> results = new List<Problem>();
        List<Choice> choice = new List<Choice>();
        List<Completion> completion = new List<Completion>();
        List<Judge> judge = new List<Judge>();
        List<OfficeWord> word = new List<OfficeWord>();
        List<OfficeExcel> excel = new List<OfficeExcel>();
        List<OfficePowerPoint> powerPoint = new List<OfficePowerPoint>();
        List<PFunction> pFun = new List<PFunction>();
        List<PCompletion> pCompletion = new List<PCompletion>();
        List<PModif> pModif = new List<PModif>();

        OESConfig dbconfig = new OESConfig("DbConfig.xml",new string[,]{
            {"IP","127.0.0.1"},
            {"DbName","OESDB"},
            {"User","oes"},
            {"Password","123456"}
        });

        DataSet Ds;
        //定义返回的数据集

        #endregion

        #region 常量定义
        public const int SORT_WORD = 1;
        public const int SORT_EXCEL = 2;
        public const int SORT_PPT = 3;
        public const int KIND_CPP = 0;
        public const int KIND_C = 1;
        #endregion

        #region 数据库基本控制

        //数据库连接
        private bool DataBind()
        {
            sqlcon = new SqlConnection();

            string strConnection = "Data Source=" + dbconfig["IP"] + ";Initial Catalog="+dbconfig["DbName"]+";User ID="+dbconfig["User"]+";Password="+dbconfig["Password"];
            //string strConnection = @"Data Source=LUOKANGQI-PC;Initial Catalog=OESDB;Integrated Security=True";
            sqlcon.ConnectionString = strConnection;


            try
            {
                sqlcon.Open();
            }
            catch
            {
                return false;
            }

            return true;
        }
        //数据库关闭
        private void Terminate()
        {
            try
            {
                sqlcon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("数据库关闭出错！" + e.ToString());

            }
        }
        //构造存储过程参数
        private SqlParameter CreateParam(string ParamName, SqlDbType DbType, Int32 Size, object Value, ParameterDirection Direction)
        {
            SqlParameter param;
            if (Size > 0)
            {
                param = new SqlParameter(ParamName, DbType, Size);
            }
            else
            {
                param = new SqlParameter(ParamName, DbType);
            }

            param.Direction = Direction;
            if (Value != null)
            {
                param.Value = Value;
            }
            return param;
        }
        
        /// <summary>
        /// 运行存储过程,返回dataset
        /// </summary>
        /// <param name="procName">存储过程名.</param>
        /// <param name="prams">存储过程入参数组.</param>
        /// <returns>dataset对象.</returns>
        public DataSet RunProc(string procName, SqlParameter[] prams, DataSet Ds)
        {
            SqlCommand Cmd = CreateCmd(procName, prams);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);

            try
            {
                Da.Fill(Ds, "demo");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            Cmd.Parameters.Clear();
            return Ds;
        }

        /// <summary>
        /// 为存储过程生成一个SqlCommand对象
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">存储过程参数</param>
        /// <returns>SqlCommand对象</returns>

        private SqlCommand CreateCmd(string procName, SqlParameter[] prams)
        {
            DataBind();
            SqlCommand Cmd = new SqlCommand(procName, sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    Cmd.Parameters.Add(parameter);
            }
            Cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));

            return Cmd;
        }

        #endregion

        #region DataSet ---> List 系列方法


        /// <summary>   
        /// DataSet装换为泛型集合   
        /// </summary>   
        /// <typeparam name="T"></typeparam>   
        /// <param name="p_DataSet">DataSet</param>   
        /// <param name="p_TableIndex">待转换数据表索引</param>   
        /// <returns></returns>   
        private List<Problem> DataSetToList(DataSet p_DataSet)
        {
            DataTable p_Data = p_DataSet.Tables[0];
            // 返回值初始化   
            List<Problem> result = new List<Problem>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Problem problem = new Problem();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];

                }

                result.Add(problem);
            }
            return result;
        }

        private List<String> DataSetPaperToList(DataSet p_DataSet)
        {
            DataTable p_Data = p_DataSet.Tables[0];
            // 返回值初始化   
            List<String> result = new List<String>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                string str = "";
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "Title")
                        str = (String)p_Data.Rows[j][i];

                }

                result.Add(str);
            }
            return result;
        }
        /// <summary>   
        /// DataSet装换为泛型集合   
        /// </summary>   
        /// <typeparam name="T"></typeparam>   
        /// <param name="p_DataSet">DataSet</param>   
        /// <param name="p_TableIndex">待转换数据表索引</param>   
        /// <returns></returns>   
        private List<Choice> DataSetToListChoice(DataSet p_DataSet)
        {
            DataTable p_Data = p_DataSet.Tables[0];
            // 返回值初始化   
            List<Choice> result = new List<Choice>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Choice problem = new Choice();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "A")
                        problem.optionA = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "B")
                        problem.optionB = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "C")
                        problem.optionC = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "D")
                        problem.optionD = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "Answer")
                        problem.ans = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "Unit")
                        problem.unit = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "UnitName")
                        problem.unitName = p_Data.Rows[j][i].ToString();

                }

                result.Add(problem);
            }
            return result;
        }
        /// <summary>   
        /// DataSet装换为泛型集合   
        /// </summary>   
        /// <typeparam name="T"></typeparam>   
        /// <param name="Ds">DataSet</param>   
        /// <param name="DsAns">DataSet</param>   
        /// <param name="p_TableIndex">待转换数据表索引</param>   
        /// <returns></returns>   
        private List<Completion> DataSetToListCompletion(DataSet Ds, DataSet DsAns)
        {
            DataTable p_Data = Ds.Tables[0];
            DataTable p_DataAns = DsAns.Tables[0];
            // 返回值初始化   
            List<Completion> result = new List<Completion>();

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                List<string> ans = new List<string>();
                Completion problem = new Completion();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Unit")
                        problem.unit = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "UnitName")
                        problem.unitName = p_Data.Rows[j][i].ToString();
                }

                for (int k = 0; k < p_DataAns.Rows.Count; k++)
                {
                    ans.Add((string)p_DataAns.Rows[k][0]);
                }
                problem.ans = ans;
                result.Add(problem);
            }
            return result;
        }

        private List<Judge> DataSetToListJudge(DataSet Ds)
        {

            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化   
            List<Judge> result = new List<Judge>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Judge problem = new Judge();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];

                    if (p_Data.Columns[i].ToString() == "Answer")
                        problem.ans = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Unit")
                        problem.unit = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "UnitName")
                        problem.unitName = (string)p_Data.Rows[j][i];

                }

                result.Add(problem);
            }
            return result;
        }
        private List<OfficeWord> DataSetToListOfficeWord(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化 
            List<OfficeWord> word = new List<OfficeWord>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                OfficeWord problem = new OfficeWord();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];

                    if (p_Data.Columns[i].ToString() == "Answer_Path")
                        problem.ansPath = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "File_Path")
                        problem.rawPath = (string)p_Data.Rows[j][i];

                }

                word.Add(problem);
            }
            return word;
        }
        private List<OfficeExcel> DataSetToListOfficeExcel(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化 
            List<OfficeExcel> excel = new List<OfficeExcel>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                OfficeExcel problem = new OfficeExcel();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];

                    if (p_Data.Columns[i].ToString() == "Answer_Path")
                        problem.ansPath = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "File_Path")
                        problem.rawPath = (string)p_Data.Rows[j][i];
                }

                excel.Add(problem);
            }
            return excel;
        }
        private List<OfficePowerPoint> DataSetToListOfficePowerPoint(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化 
            List<OfficePowerPoint> powerPoint = new List<OfficePowerPoint>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                OfficePowerPoint problem = new OfficePowerPoint();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];

                    if (p_Data.Columns[i].ToString() == "Answer_Path")
                        problem.ansPath = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "File_Path")
                        problem.rawPath = (string)p_Data.Rows[j][i];
                }

                powerPoint.Add(problem);
            }
            return powerPoint;
        }

        private List<PFunction> DataSetToListFunProgram(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化   
            List<PFunction> result = new List<PFunction>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                PFunction problem = new PFunction();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];

                    if (p_Data.Columns[i].ToString() == "File_Path")
                        problem.path = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "In1")
                        problem.inp1 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "In2")
                        problem.inp2 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "In3")
                        problem.inp3 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Out1")
                        problem.outp1 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Out2")
                        problem.outp2 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Out3")
                        problem.outp3 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "CorrectC")
                        problem.correctC = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Kind")
                        problem.kind = (bool)p_Data.Rows[j][i];

                }

                result.Add(problem);
            }
            return result;
        }

        private List<PCompletion> DataSetToListCompletionProgram(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化   
            List<PCompletion> result = new List<PCompletion>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                PCompletion problem = new PCompletion();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "File_Path")
                        problem.path = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "K1")
                        problem.ans1 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "K2")
                        problem.ans2 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "K3")
                        problem.ans3 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Kind")
                        problem.kind = (bool)p_Data.Rows[j][i];

                }

                result.Add(problem);
            }
            return result;
        }

        private List<PModif> DataSetToListModifProgram(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化   
            List<PModif> result = new List<PModif>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                PModif problem = new PModif();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "File_Path")
                        problem.path = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "K1")
                        problem.ans1 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "K2")
                        problem.ans2 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "K3")
                        problem.ans3 = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Kind")
                        problem.kind = (bool)p_Data.Rows[j][i];

                }

                result.Add(problem);
            }
            return result;
        }

        private List<Classes> DataSetToClass(DataSet p_DataSet)
        {
            List<Classes> res = new List<Classes>();
            DataTable dt = p_DataSet.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Classes cls = new Classes();
                cls.classID = dt.Rows[i][0].ToString();
                cls.dept = dt.Rows[i][1].ToString();
                cls.className = dt.Rows[i][2].ToString();
                if (dt.Rows[i][3] == null)
                    cls.teacherName = "";
                else
                    cls.teacherName = dt.Rows[i][3].ToString();
                if (dt.Rows[i][4] == null)
                    cls.teacherUserName = "";
                else
                    cls.teacherUserName = dt.Rows[i][4].ToString();
                res.Add(cls);
            }
            return res;
        }

        private List<Problem> DataSetToProblemList(DataSet p_DataSet)
        {
            List<Problem> res = new List<Problem>();
            DataTable dt = p_DataSet.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Problem pb = new Problem();
                pb.problemId = Convert.ToInt32(dt.Rows[i][0]);
                pb.problem = dt.Rows[i][1].ToString();
                res.Add(pb);
            }
            return res;
        }

        private List<string> DataSetToDeptStringList(DataSet p_DataSet)
        {
            List<string> result = new List<string>();
            DataTable p_Data = p_DataSet.Tables[0];
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                result.Add(p_Data.Rows[j][0].ToString());
            }
            return result;
        }
        private List<string> DataSetToclassStringList(DataSet p_DataSet)
        {
            List<string> result = new List<string>();
            DataTable p_Data = p_DataSet.Tables[0];
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                result.Add(p_Data.Rows[j][0].ToString());
            }
            return result;
        }
        private List<Student> DataSetToListStudent(DataSet p_DataSet)
        {

            List<Student> result = new List<Student>();
            DataTable p_Data = p_DataSet.Tables[0];

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Student problem = new Student();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "StudentId")
                        problem.ID = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "StudentName")
                        problem.sName = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "ClassId")
                        problem.classId = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "Password")
                        problem.password = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Dept")
                        problem.dept = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "ClassName")
                        problem.className = (string)p_Data.Rows[j][i];


                }

                result.Add(problem);
            }
            return result;
        }
        private List<Teacher> DataSetToTeacherList(DataSet p_DataSet)
        {
            List<Teacher> result = new List<Teacher>();
            DataTable p_Data = p_DataSet.Tables[0];

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Teacher problem = new Teacher();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.Id = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "TeacherName")
                        problem.TeacherName = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Password")
                        problem.password = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Permission")
                        problem.permission = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "UserName")
                        problem.UserName = (string)p_Data.Rows[j][i];

                }

                result.Add(problem);
            }
            return result;
        }
        private List<Paper> DataSetToListPaper2(DataSet p_DataSet)
        {
            List<Paper> result = new List<Paper>();
            DataTable p_Data = p_DataSet.Tables[0];

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Paper problem = new Paper();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.paperID = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "Title")
                        problem.paperName = (string)p_Data.Rows[j][i];

                }

                result.Add(problem);
            }
            return result;
        }
        private Teacher DataSetToTeacher(DataSet p_DataSet)
        {
            Teacher problem = new Teacher();
            DataTable p_Data = p_DataSet.Tables[0];
            if (p_Data.Rows.Count < 1)
            {
                return null;
            }
            for (int i = 0; i < p_Data.Columns.Count; i++)
            {
                // 数据库NULL值单独处理   
                if (p_Data.Columns[i].ToString() == "Id")
                    problem.Id = p_Data.Rows[0][i].ToString();
                if (p_Data.Columns[i].ToString() == "TeacherName")
                    problem.TeacherName = (string)p_Data.Rows[0][i];
                if (p_Data.Columns[i].ToString() == "Password")
                    problem.password = p_Data.Rows[0][i].ToString();
                if (p_Data.Columns[i].ToString() == "Permission")
                    problem.permission = (int)p_Data.Rows[0][i];
                if (p_Data.Columns[i].ToString() == "UserName")
                    problem.UserName = (string)p_Data.Rows[0][i];

            }
            return problem;
        }

        private List<Teacher> DataSetToListTeacher(DataSet p_DataSet)
        {
            List<Teacher> result = new List<Teacher>();
            DataTable p_Data = p_DataSet.Tables[0];

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Teacher problem = new Teacher();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.Id = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "TeacherName")
                        problem.TeacherName = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Password")
                        problem.password = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "Permission")
                        problem.permission = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "UserName")
                        problem.UserName = (string)p_Data.Rows[j][i];

                }
                result.Add(problem);
            }
            return result;
        }
        private List<Unit> DataSetToListString(DataSet Ds)
        {
            //throw new NotImplementedException();
            List<Unit> result = new List<Unit>();
            DataTable p_Data = Ds.Tables[0];

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Unit unit = new Unit();
                unit.UnitName = p_Data.Rows[j][0].ToString();
                unit.UnitId = p_Data.Rows[j][1].ToString();
                result.Add(unit);
            }
            return result;
        }
        private List<Paper> DataSetToListPaper(DataSet p_DataSet)
        {
            List<Paper> result = new List<Paper>();
            DataTable p_Data = p_DataSet.Tables[0];

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Paper problem = new Paper();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.paperID = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "Title")
                        problem.paperName = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "GenerateDate")
                        problem.createTime = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "TeacherName")
                    {
                        try
                        { problem.author = (string)p_Data.Rows[j][i]; }
                        catch { problem.author = ""; }
                    }
                    if (p_Data.Columns[i].ToString() == "Teacher_Id")
                    {
                        try { problem.authorId = (p_Data.Rows[j][i]).ToString(); }
                        catch { problem.authorId = ""; }
                    }
                    if (p_Data.Columns[i].ToString() == "ProgramState")
                        problem.programState = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "TestDate")
                        problem.testTime = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "Paper_Path")
                        problem.paperPath = p_Data.Rows[j][i].ToString();
                }

                result.Add(problem);
            }
            return result;

        }

        //List<string>转成一个字符串
        private string ListToString(List<string> ans)
        {
            string str = "";
            for (int i = 0; i < ans.Count; i++)
            {
                str = ans.ElementAt(i) + ",";
            }
            return str;
        }
        #endregion

        #region 选择题有关的方法

        public void AddManyChoices(List<string[]> lst)
        {
            SqlTransaction tx = sqlcon.BeginTransaction();
            foreach (string[] str in lst)
                AddChoice(str[0], str[1], str[2], str[3], str[4], str[5], int.Parse(str[6]));
            tx.Commit();
        }

        //向数据库中添加选择题
        public void AddChoice(string Problem_Content, string A, string B, string C, string D, string Answer, int Unit)
        {
            string unit = Unit.ToString();
            SqlParameter[] ddlparam = new SqlParameter[8];
            ddlparam[0] = CreateParam("@Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@A", SqlDbType.VarChar, 100, A, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@B", SqlDbType.VarChar, 100, B, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@C", SqlDbType.VarChar, 100, C, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@D", SqlDbType.VarChar, 100, D, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@Answer", SqlDbType.VarChar, 100, Answer, ParameterDirection.Input);
            ddlparam[6] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddChoice", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 7; i++)
            {
                cmd.Parameters.Add(ddlparam[i]);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //按单元查询选择题
        public List<Problem> FindChoiceByUnit(int Unit)
        {
            string unit = Unit.ToString();
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Unit", SqlDbType.Int,5, unit, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindChoiceByUnit", ddlparam, Ds);
            results = DataSetToList(Ds);
            return results;
        }
        //按Id查询选择题
        public List<Choice> FindChoiceById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindChoiceById", ddlparam, Ds);
            choice = DataSetToListChoice(Ds);
            return choice;
        }
        //列出所有选择题（方法一）
        public List<Problem> FindChoice1()
        {
            Ds = new DataSet();
            //RunProc("FindChoice", null, Ds);
            DataBind();
            string sql = "SELECT * From Choice_Table";
            // SqlCommand Cmd = new SqlCommand("FindChoice", sqlcon);
            //Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(sql, sqlcon);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            results = DataSetToList(Ds);
            return results;

        }
        //列出所有选择题 （方法二）
        public List<Problem> FindChoice()
        {
            Ds = new DataSet();
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindChoice", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            results = DataSetToList(Ds);
            return results;

        }
        //按Id删除选择题
        public void DeleteChoiceById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            //RunProc("FindChoiceByUnit", ddlparam, Ds);
            SqlCommand Cmd = CreateCmd("DeleteChoiceById", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        //修改制定Id的选择题
        public void UpdateChoice(string Id, string Problem_Content, string A, string B, string C, string D, string Answer, int Unit)
        {
            string unit = Unit.ToString();
            SqlParameter[] ddlparam = new SqlParameter[8];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);

            ddlparam[1] = CreateParam("@A", SqlDbType.VarChar, 100, A, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@B", SqlDbType.VarChar, 100, B, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@C", SqlDbType.VarChar, 100, C, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@D", SqlDbType.VarChar, 100, D, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@Answer", SqlDbType.VarChar, 100, Answer, ParameterDirection.Input);
            ddlparam[6] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);
            ddlparam[7] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);

            SqlCommand Cmd = CreateCmd("UpdateChoice", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        #endregion

        #region 填空题有关的方法

        //列出所有填空题
        public List<Problem> FindCompletion()
        {
            Ds = new DataSet();
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindCompletion", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            results = DataSetToList(Ds);
            return results;

        }

        //按单元查找填空题
        public List<Problem> FindCompletionByUnit(int Unit)
        {
            string unit = Unit.ToString();
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindCompletionByUnit", ddlparam, Ds);
            results = DataSetToList(Ds);
            return results;
        }
        //按单元查找填空题2
        public List<Problem> FindCompletionByUnit2(int Unit)
        {
            string unit = Unit.ToString();
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindCompletionByUnit2", ddlparam, Ds);
            results = DataSetToList(Ds);
            return results;
        }
        //按Id删除填空题
        public void DeleteCompletionById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            //RunProc("FindChoiceByUnit", ddlparam, Ds);
            SqlCommand Cmd = CreateCmd("DeleteCompletion", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        //按Id修改填空题
        public void UpdateCompletion(string Id, string Problem_Content, int Unit, List<string> ans)
        {
            string unit = Unit.ToString();
            string Answer = ListToString(ans);
            SqlParameter[] ddlparam = new SqlParameter[4];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);

            ddlparam[1] = CreateParam("@Answers", SqlDbType.VarChar, 100, Answer, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);

            SqlCommand Cmd = CreateCmd("UpdateCompletion", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        //添加填空题
        public void AddCompletion(string Problem_Content, string Problem_Pic, int Unit, List<string> ans)
        {
            string unit = Unit.ToString();
            string Answer = ListToString(ans);
            SqlParameter[] ddlparam = new SqlParameter[3];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);

            ddlparam[1] = CreateParam("@Answers", SqlDbType.VarChar, 100, Answer, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);

            SqlCommand Cmd = CreateCmd("AddCompletion", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        //按Id查询填空题详细信息
        public List<Completion> FindCompletionById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            Ds = new DataSet();
            DataSet DsAns = new DataSet();

            RunProc("FindCompletionById", ddlparam, Ds);

            ddlparam[0] = CreateParam("@P_Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);

            RunProc("FindCompletionAnsByPId", ddlparam, DsAns);

            completion = DataSetToListCompletion(Ds, DsAns);
            return completion;
        }

        #endregion

        #region 判断题有关的方法

        //单题 增加判断题
        public void AddTof(string Problem_Content, string Answer, int Unit)
        {
            string unit = Unit.ToString();
            SqlParameter[] ddlparam = new SqlParameter[3];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Answer", SqlDbType.VarChar, 100, Answer, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);

            DataBind();
            SqlCommand cmd = new SqlCommand("AddTof", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 3; i++)
            {
                cmd.Parameters.Add(ddlparam[i]);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //按Id删除判断题
        public void DeleteTofById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            //RunProc("FindChoiceByUnit", ddlparam, Ds);
            SqlCommand Cmd = CreateCmd("DeleteTofById", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //按Id修改判断题
        public void UpdateTof(string Id, string Problem_Content, int Unit, string Answer)
        {
            string unit = Unit.ToString();
            SqlParameter[] ddlparam = new SqlParameter[4];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);

            ddlparam[1] = CreateParam("@Answer", SqlDbType.VarChar, 100, Answer, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);

            SqlCommand Cmd = CreateCmd("UpdateTof", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        //按单元查找判断题
        public List<Problem> FindTofByUnit(int Unit)
        {
            string unit = Unit.ToString();
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindTofByUnit", ddlparam, Ds);
            results = DataSetToList(Ds);
            return results;
        }

        //查询所有的判断题
        public List<Problem> FindTof()
        {
            Ds = new DataSet();
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindTof", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            results = DataSetToList(Ds);
            return results;

        }

        //按Id查找判断题的详细信息
        public List<Judge> FindTofById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindTofById", ddlparam, Ds);
            judge = DataSetToListJudge(Ds);
            return judge;
        }

        #endregion

        #region office类题目有关的方法 sort传的值为1,2,3，字符串的形式，分别表示Word，Excel，PPT三类大题(就没人敢写个Const Int?)

        //增加office类题目   
        public void AddOffice(string Problem_Content, string Answer_Path, string File_Path, string Sort)
        {
            SqlParameter[] ddlparam = new SqlParameter[4];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Answer_Path", SqlDbType.VarChar, 100, Answer_Path, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@File_Path", SqlDbType.VarChar, 100, File_Path, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);

            DataBind();
            SqlCommand cmd = new SqlCommand("AddOffice", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 4; i++)
            {
                cmd.Parameters.Add(ddlparam[i]);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //删除Office类题目
        public void DeleteOffice(string Id, string Sort)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);

            //RunProc("FindChoiceByUnit", ddlparam, Ds);
            SqlCommand Cmd = CreateCmd("DeleteOffice", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //修改Office类题目
        public void UpdateOffice(string Id, string Problem_Content, string Answer_Path, string File_Path, string Sort)
        {
            SqlParameter[] ddlparam = new SqlParameter[5];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Answer_Path", SqlDbType.VarChar, 100, Answer_Path, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@File_Path", SqlDbType.VarChar, 100, File_Path, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);


            SqlCommand Cmd = CreateCmd("UpdateOffice", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        //列出所有的某一种Office题目
        public List<Problem> FindOffice(string Sort)
        {
            Ds = new DataSet();
            //RunProc("FindChoice", null, Ds);
            SqlParameter ddlparam = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindOffice", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(ddlparam);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            results = DataSetToList(Ds);
            return results;
        }

        //按Id查询OfficeWord题目
        public List<OfficeWord> FindOfficeWordById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, SORT_WORD, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindOfficeById", ddlparam, Ds);
            word = DataSetToListOfficeWord(Ds);
            return word;
        }


        //按Id查询OfficeExcel题目
        public List<OfficeExcel> FindOfficeExcelById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2,SORT_EXCEL, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindOfficeById", ddlparam, Ds);
            excel = DataSetToListOfficeExcel(Ds);
            return excel;
        }


        //按Id查询OfficePowerPoint题目
        public List<OfficePowerPoint> FindOfficePowerPointById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, SORT_PPT, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindOfficeById", ddlparam, Ds);
            powerPoint = DataSetToListOfficePowerPoint(Ds);
            return powerPoint;
        }

        //-- Description:   查找Excel试题的ID和题目
        public List<Problem> FindExcelProblemContent()
        {
            Ds = new DataSet();
            List<Problem> problemList = new List<Problem>();

            DataBind();
            SqlCommand Cmd = new SqlCommand("FindExcelProblemContent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            problemList = DataSetToProblemList(Ds);
            return problemList;
        }
        //-- Description:   查找PowerPoint试题的ID和题目
        public List<Problem> FindPowerPointProblemContent()
        {
            Ds = new DataSet();
            List<Problem> problemList = new List<Problem>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindPowerPointProblemContent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            problemList = DataSetToProblemList(Ds);
            return problemList;
        }

        //-- Description:   查找Word试题的ID和题目
        public List<Problem> FindWordProblemContent()
        {
            Ds = new DataSet();
            List<Problem> problemList = new List<Problem>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindWordProblemContent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            problemList = DataSetToProblemList(Ds);
            return problemList;
        }

        #endregion

        

        #region paper记录管理

        //增加Paper记录 ,ProgramState:0表示没有编程题；1表示是C语言编程；2表示C++语言编程
        public string AddPaper(string GenerateDate, string TestDate, string Paper_Path, string Title, string Teacher_Id, int ProgramState)
        {
            string query = "select max(id) from Paper_Table";
            string id;
            int intId;
            //using (SqlConnection connection = new SqlConnection(sqlcon))
            DataBind();
                SqlCommand com = new SqlCommand(query, sqlcon);
                //connection.Open();
                SqlDataReader reader = com.ExecuteReader();

                reader.Read();
                id = reader[0].ToString();
                reader.Close();
          
            intId = Convert.ToInt32(id);
            intId = intId + 1;
            Paper_Path = Paper_Path + intId.ToString() + ".xml";
            SqlParameter[] ddlparam = new SqlParameter[7];
            ddlparam[0] = CreateParam("@GenerateDate", SqlDbType.DateTime, 20, GenerateDate, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@TestDate", SqlDbType.DateTime, 20, TestDate, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Paper_Path", SqlDbType.VarChar, 100, Paper_Path, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Title", SqlDbType.VarChar, 50, Title, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Teacher_Id", SqlDbType.Int, 20, Teacher_Id, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@ProgramState", SqlDbType.Int, 5, ProgramState, ParameterDirection.Input);
           
            DataBind();
            SqlCommand cmd = new SqlCommand("AddPaper", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 6; i++)
            {
                cmd.Parameters.Add(ddlparam[i]);
            }
            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int, 4);
            Id.Direction = ParameterDirection.Output;// 设置为输出参数
            cmd.Parameters.Add(Id);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return Id.Value.ToString();
        }

        //按照Id 删除Paper记录
        public void DeletePaper(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            
            SqlCommand Cmd = CreateCmd("DeletePaper", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //修改Paper记录，参数是Paper编号和一个Paper对象
        public void UpdatePaper(string Id, Paper p)
        {
            SqlParameter[] dp = new SqlParameter[7];
            SqlParameter[] ddlparam = new SqlParameter[7];
            ddlparam[0] = CreateParam("@GenerateDate", SqlDbType.DateTime, 20, p.createTime, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@TestDate", SqlDbType.DateTime, 20, p.testTime, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Paper_Path", SqlDbType.VarChar, 100, p.paperPath, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Title", SqlDbType.VarChar, 50, p.paperName, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Teacher_Id", SqlDbType.Int, 20, p.authorId, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[6] = CreateParam("@ProgramState", SqlDbType.Int, 5, p.programState, ParameterDirection.Input);

            SqlCommand Cmd = CreateCmd("UpdatePaper", ddlparam);
            try { Cmd.ExecuteNonQuery(); }
            catch { throw; }
        }
        
        //修改Paper记录  ,ProgramState:0表示没有编程题；1表示是C语言编程；2表示C++语言编程
        public void UpdatePaper(string Id, string GenerateDate, string TestDate, string Paper_Path, string Title, string Teacher_Id,int ProgramState)
        {
            SqlParameter[] ddlparam = new SqlParameter[7];
            ddlparam[0] = CreateParam("@GenerateDate", SqlDbType.DateTime, 20, GenerateDate, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@TestDate", SqlDbType.DateTime, 20, TestDate, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Paper_Path", SqlDbType.VarChar, 100, Paper_Path, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Title", SqlDbType.VarChar, 50, Title, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Teacher_Id", SqlDbType.Int, 20, Teacher_Id, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[6] = CreateParam("@ProgramState", SqlDbType.Int, 5, ProgramState, ParameterDirection.Input);
            
            SqlCommand Cmd = CreateCmd("UpdatePaper", ddlparam);
            try { Cmd.ExecuteNonQuery(); }
            catch { throw; }
        }
        
        //纯粹列出所有的Paper记录
        public List<String> FindAllPaper()
        {
            List<String> results = new List<String>();
            Ds = new DataSet();
            //RunProc("FindChoice", null, Ds);

            DataBind();
            SqlCommand Cmd = new SqlCommand("FindAllPaper", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                throw Ex;
            }
            results = DataSetPaperToList(Ds);
            return results;

        }
        //列出所有的Paper记录,其中将相关的出试卷的老师信息也查找出来
        public List<Paper> FindPaper()
        {
            List<Paper> results = new List<Paper>();
            Ds = new DataSet();
            //RunProc("FindChoice", null, Ds);
           
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindPaper", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                throw Ex;
            }
            results = DataSetToListPaper(Ds);
            return results;

        }

        //按Id查找Paper记录 
        public List<Paper> FindPaperById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            Ds = new DataSet();
            try { RunProc("FindPaperById", ddlparam, Ds); }
            catch (Exception ex)
            {

                return new List<Paper>();
            }
            paper = DataSetToListPaper(Ds);
            return paper;
        }

        //查找两个日期中的试卷
        public List<Paper> FindPaperByTwoDates(DateTime std, DateTime edd)
        {
            Ds = new DataSet();
            List<Paper> paperList = new List<Paper>();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@StartDate", SqlDbType.DateTime, 0, std, ParameterDirection.Input);
            dp[1] = CreateParam("EndDate", SqlDbType.DateTime, 0, edd, ParameterDirection.Input);
            try { RunProc("FindPaperByTwoDates", dp, Ds); }
            catch { throw; }
            paperList = DataSetToListPaper(Ds);
            return paperList;
        }

        //查找某一年的试卷
        public List<Paper> FindPaperByYear(string year)
        {
            Ds = new DataSet();
            List<Paper> paperList = new List<Paper>();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@StartDate", SqlDbType.DateTime, 0, Convert.ToDateTime(year + "/01/01"), ParameterDirection.Input);
            dp[1] = CreateParam("@EndDate", SqlDbType.DateTime, 0, Convert.ToDateTime(year + "/12/31"), ParameterDirection.Input);
            try { RunProc("FindPaperByTwoDates", dp, Ds); }
            catch { throw; }
            paperList = DataSetToListPaper(Ds);
            return paperList;
        }

        //按标题查找试卷，模糊查询
        public List<Paper> FindPaperByTitle(string title)
        {
            Ds = new DataSet();
            List<Paper> paperList = new List<Paper>();
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@Title", SqlDbType.VarChar, 50, title, ParameterDirection.Input);
            try { RunProc("FindPaperByTitle", dp, Ds); }
            catch { throw; }
            paperList = DataSetToListPaper(Ds);
            return paperList;
        }

        //-- Description:	列出试卷,按照测试时间>当前时间
        public List<Paper> FindPaperByTestDate()
        {
            Ds = new DataSet();
            List<Paper> paperList = new List<Paper>();
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindPaperByTestDate", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            paperList = DataSetToListPaper2(Ds);
            return paperList;
        }

        #endregion

        #region 分数管理
       // -- Description:	查询某个班级某次考试的所有成绩
        private List<Score> DataSetToScore(DataSet p_DataSet)
        {
            DataTable p_Data = p_DataSet.Tables[0];
            // 返回值初始化   
            List<Score> result = new List<Score>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Score problem = new Score();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "StudentName")
                        problem.stuName = (string)(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "ClassName")
                        problem.stuClassName = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "TotalScore")
                        problem.score = (string)p_Data.Rows[j][i];


                }

                result.Add(problem);
            }
            return result;
        }
        

        public List<Score> FindScoreByClassPaper(string ClassName,string Title)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@ClassName", SqlDbType.VarChar, 50, ClassName, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Title", SqlDbType.VarChar, 50, Title, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindScoreByClassPaper", ddlparam, Ds);
            List<Score> score = new List<Score>();
            score= DataSetToScore(Ds);
            return score;
        }
        #endregion

        #region 章节管理

        //添加章节，UnitName具体的章节名字，例如“故障恢复”
        public void AddUnit(string UnitName)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@UnitName", SqlDbType.VarChar, 100, UnitName, ParameterDirection.Input);
           
            DataBind();
            SqlCommand cmd = new SqlCommand("AddUnit", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 1; i++)
            {
                cmd.Parameters.Add(ddlparam[i]);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        //Description:	列出所有章节名
        public List<Unit> FindUnit()
        {
            List<Unit> UnitList = new List<Unit>();
            Ds = new DataSet();
            try { RunProc("FindUnit", null, Ds); }
            catch (Exception Ex) { throw Ex; }
            UnitList = DataSetToListString(Ds);
            return UnitList;
        }

        //Description:  删除某个章节
        public void DeleteUnit(int Unit)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@Unit", SqlDbType.Int, 11, Unit, ParameterDirection.Input);
            SqlCommand cmd = CreateCmd("DeleteUnit", dp);
            try { cmd.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
        }

        //Description:  修改某个章节
        public void UpdateUnit(int Unit, string UnitName)
        {
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@Unit", SqlDbType.Int, 11, Unit, ParameterDirection.Input);
            dp[1] = CreateParam("@UnitName", SqlDbType.VarChar, 50, UnitName, ParameterDirection.Input);
            SqlCommand cmd = CreateCmd("UpdateUnit", dp);
            try { cmd.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 考试、试卷管理

        //-- Description:	根据试卷号返回试卷具体文件地址
        public string FindPaperPathByPaperId(string Id)
        {
            
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            
            DataBind();
            SqlCommand cmd = new SqlCommand("FindPaperPathByPaperId", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 1; i++)
            {
                cmd.Parameters.Add(ddlparam[i]);
            }
            SqlParameter Paper_Path = new SqlParameter("@Paper_Path", SqlDbType.VarChar, 100);
            Paper_Path.Direction = ParameterDirection.Output;// 设置为输出参数
            cmd.Parameters.Add(Paper_Path);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine(Paper_Path.Value.ToString());
            return Paper_Path.Value.ToString();

        }
        //-- Description:	验证学生可否参加考试,返回false 表示验证不通过，true，验证通过
        public bool CheckStudent(string StudentName ,string  StudentId ,string Password )
        {
            SqlParameter[] ddlparam = new SqlParameter[3];
            ddlparam[0] = CreateParam("@StudentName", SqlDbType.VarChar, 50, StudentName, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@StudentId", SqlDbType.VarChar, 50, StudentId, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Password", SqlDbType.VarChar, 50, Password, ParameterDirection.Input);

            Ds = new DataSet();
            RunProc("CheckStudent", ddlparam, Ds);

            DataTable p_Data = Ds.Tables[0];
            if (p_Data.Columns.Count < 1)
            {
                return false;
            }
            return true;
        }
        

#endregion

        #region 教师信息管理

        //-- Description:	查找Teacher的所有信息，通过Teacher的LoginName
        public Teacher FindTeacherByLoginName(string UserName)
        {
            Teacher teacher = new Teacher();
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@UserName", SqlDbType.VarChar, 50, UserName, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindTeacherByLoginName", ddlparam, Ds);
            teacher = DataSetToTeacher(Ds);
            return teacher;
        }

        //-- Description:	增加教师信息
        public void AddTeacher(string TeacherName, string Password, int Permission, string UserName)
        {
            
            SqlParameter[] ddlparam = new SqlParameter[4];
            ddlparam[0] = CreateParam("@TeacherName", SqlDbType.VarChar, 50, TeacherName, ParameterDirection.Input);

            ddlparam[1] = CreateParam("@Password", SqlDbType.VarChar, 200, Password, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Permission", SqlDbType.Int , 2, Permission.ToString(), ParameterDirection.Input);
            ddlparam[3] = CreateParam("@UserName", SqlDbType.VarChar, 50, UserName, ParameterDirection.Input);
            
            DataBind();
            SqlCommand cmd = new SqlCommand("AddTeacher", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 4; i++)
            {
                cmd.Parameters.Add(ddlparam[i]);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        //-- Description:	按照Id删除教师信息
        public void DeleteTeacherById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            DataBind();
            //RunProc("FindChoiceByUnit", ddlparam, Ds);
            SqlCommand Cmd = CreateCmd("DeleteTeacherById", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        //-- Description:   删除多个教师
        public void DeleteManyTeacher(List<String> list)
        {
            try
            {
                SqlTransaction tx = sqlcon.BeginTransaction();
                for (int i = 0; i < list.Count; i++)
                    DeleteTeacherById(list[i]);
                tx.Commit();
            }
            catch (Exception e) { throw e; }
        }

        //-- Description:	修改教师记录的信息
        public void UpdateTeacherById(string Id, string TeacherName, string Password, int Permission, string UserName)
        {
            
            SqlParameter[] ddlparam = new SqlParameter[5];

            ddlparam[0] = CreateParam("@TeacherName", SqlDbType.VarChar, 50, TeacherName, ParameterDirection.Input);

            ddlparam[1] = CreateParam("@Password", SqlDbType.VarChar, 200, Password, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Permission", SqlDbType.Int, 2, Permission.ToString(), ParameterDirection.Input);
            ddlparam[3] = CreateParam("@UserName", SqlDbType.VarChar, 50, UserName, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            
            SqlCommand Cmd = CreateCmd("UpdateTeacherById", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        //-- Description:	列出所有teacher信息
        public List<Teacher> FindTeacher()
        {
            Ds = new DataSet();
            List<Teacher> teacherList = new List<Teacher>();
            //RunProc("FindTeacher", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            teacherList = DataSetToTeacherList(Ds);
            return teacherList;
        }

        #endregion

        #region 班级信息管理

        //-- Description:   添加班级 输入老师教工号
        public void AddClass(string dept, string className, string teacherUserName)
        {
            SqlParameter[] dp = new SqlParameter[3];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            dp[2] = CreateParam("@TeacherUserName", SqlDbType.VarChar, 50, teacherUserName, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddClass", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 3; i++)
                cmd.Parameters.Add(dp[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }

        //-- Description:   批量导入班级时的添加单个班级
        public void AddClassByClassImport(string dept, string className, string teacherUserName)
        {
            SqlParameter[] dp = new SqlParameter[3];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            dp[2] = CreateParam("@UserName", SqlDbType.VarChar, 50, teacherUserName, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddManyClass", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 3; i++)
                cmd.Parameters.Add(dp[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }


        //-- Description:   批量导入班级
        public void AddManyClasses(List<string[]> value)
        {
            SqlTransaction tx = sqlcon.BeginTransaction();
            for (int i = 0; i < value.Count; i++)
            {
                string dept = value[i][0].ToString();
                string className = value[i][1].ToString();
                string userName = value[i][2].ToString();
                AddClassByClassImport(dept, className, userName);
            }
            tx.Commit();
        }



        //-- Description:   导入学生时添加的班级
        public string AddClassByImport(string dept, string className)
        {
            string res = "";                //返回ClassId
            Ds = new DataSet();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddClassByImport", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 2; i++)
                cmd.Parameters.Add(dp[i]);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            try 
            {
                Da.Fill(Ds);
                DataTable dt = Ds.Tables[0];
                res = dt.Rows[0][0].ToString();
            }
            catch (Exception Ex) { throw Ex; }
            return res;
        }

        //-- Description:   删除班级信息
        public void DeleteClass(string classId)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@ClassId", SqlDbType.VarChar, 50, classId, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("DeleteClass", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(dp[0]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }

        //-- Description:   删除多个班级
        public void DeleteManyClass(List<String> list)
        {
            try
            {
                SqlTransaction tx = sqlcon.BeginTransaction();
                for (int i = 0; i < list.Count; i++)
                    DeleteClass(list[i]);
                tx.Commit();
            }
            catch (Exception e) { throw e; }
        }

        //-- Description:   修改班级信息
        public void UpdateClass(string classId, string dept, string className, string teacherUserName)
        {
            SqlParameter[] dp = new SqlParameter[4];
            dp[0] = CreateParam("@ClassId", SqlDbType.VarChar, 50, classId, ParameterDirection.Input);
            dp[1] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[2] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            dp[3] = CreateParam("@TeacherUserName", SqlDbType.VarChar, 50, teacherUserName, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("UpdateClass", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 4; i++)
                cmd.Parameters.Add(dp[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }

        //-- Description:   超级管理员查询所有班级信息
        public List<Classes> FindAllClass()
        {
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindAllClass", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   超级管理员按学院查找班级
        public List<Classes> FindClassByDept(string dept)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByDept", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp[0]);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   普通教师按学院查找班级
        public List<Classes> FindClassByDeptWithTeacher(string dept, string userName)
        {
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByDeptWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   超级管理员按班级名称查找班级
        public List<Classes> FindClassByClassName(string className)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByClassName", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp[0]);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   普通教师按班级名称查找班级
        public List<Classes> FindClassByClassNameWithTeacher(string className, string userName)
        {
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByClassNameWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   按教工号查找班级
        public List<Classes> FindClassByUserName(string userName)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByUserName", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp[0]);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:	查找某个学院下的所有班级
        public List<string> FindClassNameOfDept(string Dept)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, Dept, ParameterDirection.Input);

            Ds = new DataSet();
            List<string> classStringList = new List<string>();

            RunProc("FindClassNameOfDept", ddlparam, Ds);
            classStringList = DataSetToclassStringList(Ds);
            return classStringList;
        }

        //-- Description:   查找某个学院下某个老师的所有班级
        public List<String> FindClassNameOfDeptWithTeacher(string dept, string userName)
        {
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            Ds = new DataSet();
            List<string> res = new List<string>();
            SqlCommand Cmd = new SqlCommand("FindClassNameOfDeptWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            res = DataSetToclassStringList(Ds);
            return res;
        }

        //-- Description:	查找所有的学院
        public List<string> FindAllDept()
        {
            Ds = new DataSet();
            List<string> deptStringList = new List<string>();

            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindAllDept", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            deptStringList = DataSetToDeptStringList(Ds);
            return deptStringList;
        }

        //-- Description:   查找某个老师所教班级所在的所有学院
        public List<String> FindAllDeptWithTeacher(string userName)
        {
            Ds = new DataSet();
            List<string> res = new List<string>();
            SqlParameter dp = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindAllDeptWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            res = DataSetToDeptStringList(Ds);
            return res;
        }

        #endregion

        #region 学生信息管理

        //-- Description:   验证学生信息是否正确
        public bool ValidateStudentInfo(string studentId, string studentName, string password)
        {
            DataSet Ds = new DataSet();
            SqlParameter[] dp = new SqlParameter[3];
            dp[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, studentId, ParameterDirection.Input);
            dp[1] = CreateParam("@StudentName", SqlDbType.VarChar, 50, studentName, ParameterDirection.Input);
            dp[2] = CreateParam("@Password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);
            try { RunProc("ValidateStudentInfo", dp, Ds); }
            catch { throw; }
            return Ds.Tables[0].Rows.Count > 0;
        }

        //-- Description:   添加学生 输入学院、班级信息.
        public void AddStudent(string id, string name, string dept, string className, string password)
        {
            SqlParameter[] ddlparam = new SqlParameter[5];
            ddlparam[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddNewStudent", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 5; i++)
            {
                cmd.Parameters.Add(ddlparam[i]);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        //-- Description:   批量导入时，导入单个学生的方法
        public void AddStudentByImport(string id, string name, string classId, string password)
        {
            SqlParameter[] ddlparam = new SqlParameter[4];
            ddlparam[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@ClassId", SqlDbType.VarChar, 50, classId, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddStudent", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 4; i++)
                cmd.Parameters.Add(ddlparam[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException e) { throw e; }
        }

        //-- Description:   批量导入学生
        public void  AddManyStudents(string dept, string className, List<string[]> value)
        {
            SqlTransaction tx = sqlcon.BeginTransaction();
            string classId = AddClassByImport(dept, className);
            for (int i = 0; i < value.Count; i++)
            {
                string name = value[i][0].ToString();
                string id = value[i][1].ToString();
                string pw = value[i][2].ToString();
                AddStudentByImport(id, name, classId, pw);
            }
            tx.Commit();
        }

        //-- Description:   删除学生
        public void DeleteStudent(string id)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("DeleteStudentByStudentId", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(dp[0]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }

        //-- Description:   删除多个学生
        public void DeleteManyStudent(List<String> list)
        {
            try
            {
                SqlTransaction tx = sqlcon.BeginTransaction();
                for (int i = 0; i < list.Count; i++)
                    DeleteStudent(list[i]);
                tx.Commit();
            }
            catch (Exception e) { throw e; }
        }

        //-- Description:   修改学生
        public void UpdateStudent(string id, string name, string dept, string className, string password, string oriId)
        {
            SqlParameter[] ddlparam = new SqlParameter[6];
            ddlparam[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@OriStudentId", SqlDbType.VarChar, 50, oriId, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("UpdateStudent", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 6; i++)
                cmd.Parameters.Add(ddlparam[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException e) { throw e; }
        }

        //-- Description:	超级管理员列出所有学生
        public List<Student> FindAllStudent()
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();

            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindAllStudent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            studentList = DataSetToListStudent(Ds);
            return studentList;

        }
        //-- Description:	普通教师查看自己所教院系的学生信息
        public List<Student> FindStudentByUserName(string userName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter dp = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByUserName", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            studentList = DataSetToListStudent(Ds);
            return studentList;

        }
        //-- Description:	按院系班级信息查询学生
        public List<Student> FindStudentByClass(string Dept, string ClassName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, Dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, ClassName, ParameterDirection.Input);
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByClass", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }

        //-- Description:	 普通教师按院系班级信息查询学生
        public List<Student> FindStudentByClassWithTeacher(string Dept, string ClassName, string userName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter[] dp = new SqlParameter[3];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, Dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, ClassName, ParameterDirection.Input);
            dp[2] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByClassWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }



        //-- Description:	按学生姓名查询学生信息
        public List<Student> FindStudentByName(string name)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter dp = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByName", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }

        //-- Description:   普通教师按学生姓名查询学生信息
        public List<Student> FindStudentByNameWithTeacher(string name, string userName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByNameWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }

        //-- Description:	按学号查询学生信息
        public List<Student> FindStudentByStudentId(string StudentId)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter dp = CreateParam("@StudentId", SqlDbType.VarChar, 50, StudentId, ParameterDirection.Input);
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByStudentId", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }

        //-- Description:   普通教师按学号查询学生信息
        public List<Student> FindStudentByStudentIdWithTeacher(string id, string userName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByStudentIdWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }


        #endregion

    }
}
