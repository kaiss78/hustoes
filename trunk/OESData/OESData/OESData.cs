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
        #region 变量定义
        SqlConnection sqlcon;//定义SQL的链接
        string sqlstring; //定义SQL语句字符串
        List<Paper> paper = new List<Paper>();
        List<Problem> results = new List<Problem>();
        List<Choice> choice = new List<Choice>();
        List<Completion> completion = new List<Completion>();
        List<Judgment> judgment = new List<Judgment>();
        List<OfficeWord> word = new List<OfficeWord>();
        List<OfficeExcel> excel = new List<OfficeExcel>();
        List<OfficePowerPoint> powerPoint = new List<OfficePowerPoint>();
        List<PFunction> pFun = new List<PFunction>();
        List<PCompletion> pCompletion = new List<PCompletion>();
        List<PModif> pModif = new List<PModif>();

        OESConfig dbconfig = new OESConfig("DbConfig.xml", new string[,]{
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

            string strConnection = "Data Source=" + dbconfig["IP"] + ";Initial Catalog=" + dbconfig["DbName"] + ";User ID=" + dbconfig["User"] + ";Password=" + dbconfig["Password"];
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
            if (Direction==ParameterDirection.Input && Value != null)
            {
                param.Value = Value;
            }
            return param;
        }

        public void RunProc(string procName, List<SqlParameter> prams)
        {
            DataBind();
            SqlCommand cmd = new SqlCommand(procName, sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < prams.Count; i++)
            {
                cmd.Parameters.Add(prams[i]);
            }
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 运行存储过程,返回dataset
        /// </summary>
        /// <param name="procName">存储过程名.</param>
        /// <param name="prams">存储过程入参数组.</param>
        /// <returns>dataset对象.</returns>
        public DataSet RunProc(string procName, List<SqlParameter> prams, DataSet Ds)
        {
            SqlCommand Cmd = CreateCmd(procName, prams);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(Ds, "demo");
            Cmd.Parameters.Clear();
            return Ds;
        }

        /// <summary>
        /// 为存储过程生成一个SqlCommand对象
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">存储过程参数</param>
        /// <returns>SqlCommand对象</returns>

        private SqlCommand CreateCmd(string procName, List<SqlParameter> prams)
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
                        problem.unit.UnitId = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "UnitName")
                        problem.unit.UnitName = p_Data.Rows[j][i].ToString();

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
                        problem.unit.UnitId = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "UnitName")
                        problem.unit.UnitName = p_Data.Rows[j][i].ToString();
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

        private List<Judgment> DataSetToListJudge(DataSet Ds)
        {

            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化   
            List<Judgment> result = new List<Judgment>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Judgment problem = new Judgment();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    if (p_Data.Columns[i].ToString() == "Id")
                        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Problem_Content")
                        problem.problem = (string)p_Data.Rows[j][i];

                    if (p_Data.Columns[i].ToString() == "Answer")
                        problem.ans = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Unit")
                        problem.unit.UnitId = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "UnitName")
                        problem.unit.UnitName = (string)p_Data.Rows[j][i];

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
#if false
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
#endif
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
                unit.UnitId = Convert.ToInt32(p_Data.Rows[j][1]);
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

    }
}
