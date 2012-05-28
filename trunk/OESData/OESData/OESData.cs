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
            if (sqlcon != null && sqlcon.State == ConnectionState.Open)
                return true;

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
            SqlCommand Cmd = CreateCmd(procName, prams);
            //SqlCommand cmd = new SqlCommand(procName, sqlcon);
            //cmd.CommandType = CommandType.StoredProcedure;
            //for (int i = 0; i < prams.Count; i++)
            //{
            //    cmd.Parameters.Add(prams[i]);
            //}
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 运行存储过程,返回dataset
        /// </summary>
        /// <param name="procName">存储过程名.</param>
        /// <param name="prams">存储过程入参数组.</param>
        /// <returns>dataset对象.</returns>
        public DataSet RunProc(string procName, List<SqlParameter> prams, DataSet Ds)
        {
            DataBind();
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
        //private List<Problem> DataSetToList(DataSet p_DataSet)
        //{
        //    DataTable p_Data = p_DataSet.Tables[0];
        //    // 返回值初始化   
        //    List<Problem> result = new List<Problem>();
        //    for (int j = 0; j < p_Data.Rows.Count; j++)
        //    {
        //        Problem problem = new Problem();
        //        for (int i = 0; i < p_Data.Columns.Count; i++)
        //        {
        //            // 数据库NULL值单独处理   
        //            if (p_Data.Columns[i].ToString() == "Id")
        //                problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
        //            if (p_Data.Columns[i].ToString() == "Problem_Content")
        //                problem.problem = (string)p_Data.Rows[j][i];

        //        }

        //        result.Add(problem);
        //    }
        //    return result;
        //}

        //private List<String> DataSetPaperToList(DataSet p_DataSet)
        //{
        //    DataTable p_Data = p_DataSet.Tables[0];
        //    // 返回值初始化   
        //    List<String> result = new List<String>();
        //    for (int j = 0; j < p_Data.Rows.Count; j++)
        //    {
        //        string str = "";
        //        for (int i = 0; i < p_Data.Columns.Count; i++)
        //        {
        //            // 数据库NULL值单独处理   
        //            if (p_Data.Columns[i].ToString() == "Title")
        //                str = (String)p_Data.Rows[j][i];

        //        }

        //        result.Add(str);
        //    }
        //    return result;
        //}
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
                problem.problemId=Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.optionA = p_Data.Rows[j]["A"].ToString();
                problem.optionB = p_Data.Rows[j]["B"].ToString();
                problem.optionC = p_Data.Rows[j]["C"].ToString();
                problem.optionD = p_Data.Rows[j]["D"].ToString();
                problem.ans = p_Data.Rows[j]["Answer"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);

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
        private List<Completion> DataSetToListCompletion(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            //DataTable p_DataAns = DsAns.Tables[0];
            // 返回值初始化   
            List<Completion> result = new List<Completion>();

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                List<string> ans = new List<string>();
                Completion problem = new Completion();
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);

                //for (int k = 0; k < p_DataAns.Rows.Count; k++)
                //{
                //    ans.Add((string)p_DataAns.Rows[k][0]);
                //}
                //problem.ans = ans;
                result.Add(problem);
            }
            return result;
        }

        private List<Judgment> DataSetToListJudgment(DataSet Ds)
        {

            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化   
            List<Judgment> result = new List<Judgment>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Judgment problem = new Judgment();
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.ans = p_Data.Rows[j]["Answer"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);
             
                result.Add(problem);
            }
            return result;
        }

        private List<Office> DataSetToListOffice(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            List<Office> office = new List<Office>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Office problem = new Office();
                switch ((Office.OfficeType)Convert.ToInt32(p_Data.Rows[j]["Type"]))
                {
                    case Office.OfficeType.Word:
                        {
                            problem=new OfficeWord();
                            problem.type=ProblemType.Word;
                            break;
                        }
                    case Office.OfficeType.Excel:
                        {
                            problem = new OfficeExcel();
                            problem.type = ProblemType.Excel;
                            break;
                        }
                    case Office.OfficeType.PowerPoint:
                        {
                            problem = new OfficePowerPoint();
                            problem.type = ProblemType.PowerPoint;
                            break;
                        }
                }
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);

                office.Add(problem);
            }
            return office;
        }

        private List<OfficeWord> DataSetToListOfficeWord(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化 
            List<OfficeWord> word = new List<OfficeWord>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                OfficeWord problem = new OfficeWord();
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);

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
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);

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
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);

                powerPoint.Add(problem);
            }
            return powerPoint;
        }

        private List<ProgramProblem> DataSetToListProgram(DataSet Ds)
        { 
            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化   
            List<ProgramProblem> result = new List<ProgramProblem>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                ProgramProblem problem = new ProgramProblem();
                PLanguage language=(PLanguage)Convert.ToInt32(p_Data.Rows[j]["Language"]);
                ProgramPType type = (ProgramPType)Convert.ToInt32(p_Data.Rows[j]["Type"]);
                switch (language)
                {
                    case PLanguage.C:
                        switch (type)
                        {
                            case ProgramPType.Completion:
                                problem = new PCompletion(ProblemType.CProgramCompletion);
                                break;
                            case ProgramPType.Modify:
                                problem = new PModif(ProblemType.CProgramModification);
                                break;
                            case ProgramPType.Function:
                                problem = new PFunction(ProblemType.CProgramFun);
                                break;
                        }
                        break;
                    case PLanguage.CPP:
                        switch (type)
                        {
                            case ProgramPType.Completion:
                                problem = new PCompletion(ProblemType.CppProgramCompletion);
                                break;
                            case ProgramPType.Modify:
                                problem = new PModif(ProblemType.CppProgramModification);
                                break;
                            case ProgramPType.Function:
                                problem = new PFunction(ProblemType.CppProgramFun);
                                break;
                        }
                        break;
                    case PLanguage.VB:
                        switch (type)
                        {
                            case ProgramPType.Completion:
                                problem = new PCompletion(ProblemType.VbProgramCompletion);
                                break;
                            case ProgramPType.Modify:
                                problem = new PModif(ProblemType.VbProgramModification);
                                break;
                            case ProgramPType.Function:
                                problem = new PFunction(ProblemType.VbProgramFun);
                                break;
                        }
                        break;
                }
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);
                result.Add(problem);
            }
            return result;
        }

        private List<PFunction> DataSetToListFunProgram(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            // 返回值初始化   
            List<PFunction> result = new List<PFunction>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                PFunction problem=new PFunction(ProblemType.CProgramFun);
                PLanguage language=(PLanguage)Convert.ToInt32(p_Data.Rows[j]["Language"]);
                switch (language)
                {
                    case PLanguage.C:
                        problem = new PFunction(ProblemType.CProgramFun);
                        break;
                    case PLanguage.CPP:
                        problem = new PFunction(ProblemType.CppProgramFun);
                        break;
                    case PLanguage.VB:
                        problem = new PFunction(ProblemType.VbProgramFun);
                        break;
                }
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);
                //for (int i = 0; i < p_Data.Columns.Count; i++)
                //{
                //    if (p_Data.Columns[i].ToString() == "Id")
                //        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                //    if (p_Data.Columns[i].ToString() == "Problem_Content")
                //        problem.problem = (string)p_Data.Rows[j][i];

                //    if (p_Data.Columns[i].ToString() == "File_Path")
                //        problem.path = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "In1")
                //        problem.inp1 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "In2")
                //        problem.inp2 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "In3")
                //        problem.inp3 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "Out1")
                //        problem.outp1 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "Out2")
                //        problem.outp2 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "Out3")
                //        problem.outp3 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "CorrectC")
                //        problem.correctC = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "Kind")
                //        problem.kind = (bool)p_Data.Rows[j][i];

                //}

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
                PCompletion problem=new PCompletion(ProblemType.CProgramCompletion);
                PLanguage language = (PLanguage)Convert.ToInt32(p_Data.Rows[j]["Language"]);
                switch (language)
                {
                    case PLanguage.C:
                        problem = new PCompletion(ProblemType.CProgramCompletion);
                        break;
                    case PLanguage.CPP:
                        problem = new PCompletion(ProblemType.CppProgramCompletion);
                        break;
                    case PLanguage.VB:
                        problem = new PCompletion(ProblemType.VbProgramCompletion);
                        break;
                }
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);
                //for (int i = 0; i < p_Data.Columns.Count; i++)
                //{
                //    if (p_Data.Columns[i].ToString() == "Id")
                //        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                //    if (p_Data.Columns[i].ToString() == "Problem_Content")
                //        problem.problem = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "File_Path")
                //        problem.path = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "K1")
                //        problem.ans1 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "K2")
                //        problem.ans2 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "K3")
                //        problem.ans3 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "Kind")
                //        problem.kind = (bool)p_Data.Rows[j][i];

                //}

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

                PModif problem=new PModif(ProblemType.CProgramModification);
                PLanguage language = (PLanguage)Convert.ToInt32(p_Data.Rows[j]["Language"]);
                switch (language)
                {
                    case PLanguage.C:
                        problem = new PModif(ProblemType.CProgramModification);
                        break;
                    case PLanguage.CPP:
                        problem = new PModif(ProblemType.CppProgramModification);
                        break;
                    case PLanguage.VB:
                        problem = new PModif(ProblemType.VbProgramModification);
                        break;
                }
                problem.problemId = Convert.ToInt32(p_Data.Rows[j]["PID"]);
                problem.problem = p_Data.Rows[j]["PContent"].ToString();
                problem.unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                problem.unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                problem.Plevel = Convert.ToInt32(p_Data.Rows[j]["PLevel"]);
                //for (int i = 0; i < p_Data.Columns.Count; i++)
                //{
                //    if (p_Data.Columns[i].ToString() == "Id")
                //        problem.problemId = Convert.ToInt32(p_Data.Rows[j][i]);
                //    if (p_Data.Columns[i].ToString() == "Problem_Content")
                //        problem.problem = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "File_Path")
                //        problem.path = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "K1")
                //        problem.ans1 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "K2")
                //        problem.ans2 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "K3")
                //        problem.ans3 = (string)p_Data.Rows[j][i];
                //    if (p_Data.Columns[i].ToString() == "Kind")
                //        problem.kind = (bool)p_Data.Rows[j][i];

                //}

                result.Add(problem);
            }
            return result;
        }

        private List<ProgramAnswer> DataSetToListProgramAnswer(DataSet Ds)
        {
            DataTable p_Data = Ds.Tables[0];
            List<ProgramAnswer> res = new List<ProgramAnswer>();
            for (int i = 0; i < p_Data.Rows.Count; i++)
            {
                ProgramAnswer tmp = new ProgramAnswer();
                tmp.PID = Convert.ToInt32(p_Data.Rows[i]["PID"]);
                tmp.AID = Convert.ToInt32(p_Data.Rows[i]["AID"]);
                tmp.Input = p_Data.Rows[i]["Input"].ToString();
                tmp.Output = p_Data.Rows[i]["Output"].ToString();
                tmp.SeqNum = Convert.ToInt32(p_Data.Rows[i]["SeqNum"]);
                res.Add(tmp);
            }
            return res;
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

        //private List<Problem> DataSetToProblemList(DataSet p_DataSet)
        //{
        //    List<Problem> res = new List<Problem>();
        //    DataTable dt = p_DataSet.Tables[0];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        Problem pb = new Problem();
        //        pb.problemId = Convert.ToInt32(dt.Rows[i][0]);
        //        pb.problem = dt.Rows[i][1].ToString();
        //        res.Add(pb);
        //    }
        //    return res;
        //}

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

        //数据库记录转为Student
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
                Teacher th = new Teacher();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "TeacherId")
                        th.Id = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "TeacherName")
                        th.TeacherName = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Password")
                        th.password = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "Permission")
                        th.permission = (int)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "UserName")
                        th.UserName = (string)p_Data.Rows[j][i];

                }

                result.Add(th);
            }
            return result;
        }
        //private List<Paper> DataSetToListPaper2(DataSet p_DataSet)
        //{
        //    List<Paper> result = new List<Paper>();
        //    DataTable p_Data = p_DataSet.Tables[0];

        //    for (int j = 0; j < p_Data.Rows.Count; j++)
        //    {
        //        Paper problem = new Paper();
        //        for (int i = 0; i < p_Data.Columns.Count; i++)
        //        {
        //            // 数据库NULL值单独处理   
        //            if (p_Data.Columns[i].ToString() == "Id")
        //                problem.paperID = (int)p_Data.Rows[j][i];
        //            if (p_Data.Columns[i].ToString() == "Title")
        //                problem.paperName = (string)p_Data.Rows[j][i];

        //        }

        //        result.Add(problem);
        //    }
        //    return result;
        //}
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
                    problem.Id = Convert.ToInt32(p_Data.Rows[0][i]);
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
                        problem.Id = Convert.ToInt32(p_Data.Rows[j][i]);
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

        private List<Course> DataSetToListCourse(DataSet Ds)
        {
            List<Course> res = new List<Course>();
            DataTable p_Data = Ds.Tables[0];
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Course cos = new Course();
                cos.CourseId = Convert.ToInt32(p_Data.Rows[j]["CourseId"]);
                cos.CourseName = p_Data.Rows[j]["CourseName"].ToString();
                res.Add(cos);
            }
            return res;
        }

        private List<Unit> DataSetToListUnit(DataSet Ds)
        {
            //throw new NotImplementedException();
            List<Unit> result = new List<Unit>();
            DataTable p_Data = Ds.Tables[0];

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Unit unit = new Unit();
                unit.UnitName = p_Data.Rows[j]["UnitName"].ToString();
                unit.UnitId = Convert.ToInt32(p_Data.Rows[j]["Unit"]);
                unit.course = new Course();
                unit.course.CourseId = Convert.ToInt32(p_Data.Rows[j]["CourseId"]);
                unit.course.CourseName = p_Data.Rows[j]["CourseName"].ToString();
                result.Add(unit);
            }
            return result;
        }

        //生成Paper的List
        private List<Paper> DataSetToListPaper(DataSet p_DataSet)
        {
            List<Paper> result = new List<Paper>();
            DataTable p_Data = p_DataSet.Tables[0];

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Paper paper = new Paper();
                paper.paperID = Convert.ToInt32(p_Data.Rows[j]["PaperId"]);
                paper.paperName = p_Data.Rows[j]["Title"].ToString();
                paper.author = p_Data.Rows[j]["TeacherName"].ToString();
                paper.createTime = p_Data.Rows[j]["GenerateDate"].ToString();
                result.Add(paper);
            }
            return result;

        }

        ////List<string>转成一个字符串
        //private string ListToString(List<string> ans)
        //{
        //    string str = "";
        //    for (int i = 0; i < ans.Count; i++)
        //    {
        //        str = ans.ElementAt(i) + ",";
        //    }
        //    return str;
        //}
        #endregion

    }
}
