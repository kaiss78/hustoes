using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using OES.Model;
using System.Data;

namespace OES
{
    public class OESData
    {
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

        DataSet Ds;//定义返回的数据集
        //数据库连接
        private bool DataBind()
        {
            sqlcon = new SqlConnection();
            string strConnection = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Documents and Settings\\Administrator\\桌面\\OESserver\\OESserver\\OESDB.mdf\";Integrated Security=True;Connect Timeout=30;User Instance=True";
            //sqlcon = new SqlConnection();
            //string strConnection = "Trusted_Connection=SSPI;";
            //strConnection += "initial catalog=OESDB;Server=localhost;";
            //strConnection += "Connect Timeout=30";
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
                MessageBox.Show("数据库关闭出错！" + e.ToString());

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
                MessageBox.Show(e.ToString());
            }
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
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
            }

        }
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
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
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
            RunProc("FindCompletionAnsByPId", ddlparam, DsAns);

            completion = DataSetToListCompletion(Ds, DsAns);
            return completion;
        }

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
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
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

        //增加office类题目   sort传的值为1,2,3，字符串的形式，分别表示Word，Excel，PPT三类大题
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
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
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
        public List<OfficeWord> FindOfficeWordById(string Id, string Sort)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindOfficeById", ddlparam, Ds);
            word = DataSetToListOfficeWord(Ds);
            return word;
        }


        //按Id查询OfficeExcel题目
        public List<OfficeExcel> FindOfficeExcelById(string Id, string Sort)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindOfficeById", ddlparam, Ds);
            excel = DataSetToListOfficeExcel(Ds);
            return excel;
        }


        //按Id查询OfficePowerPointl题目
        public List<OfficePowerPoint> FindOfficePowerPointById(string Id, string Sort)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindOfficeById", ddlparam, Ds);
            powerPoint = DataSetToListOfficePowerPoint(Ds);
            return powerPoint;
        }

        //增加编程的综合体型
        public void AddFunProgram(string Problem_Content, string File_Path, string In1, string In2, string In3, string Out1, string Out2, string Out3, string CorrectC, string Kind)
        {
            SqlParameter[] ddlparam = new SqlParameter[10];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@File_Path", SqlDbType.VarChar, 100, File_Path, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@In1", SqlDbType.VarChar, 100, In1, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@In2", SqlDbType.VarChar, 100, In2, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@In3", SqlDbType.VarChar, 100, In3, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@Out1", SqlDbType.VarChar, 100, Out1, ParameterDirection.Input);
            ddlparam[6] = CreateParam("@Out2", SqlDbType.VarChar, 100, Out2, ParameterDirection.Input);
            ddlparam[7] = CreateParam("@Out3", SqlDbType.VarChar, 100, Out3, ParameterDirection.Input);
            ddlparam[8] = CreateParam("@CorrectC", SqlDbType.VarChar, 100, CorrectC, ParameterDirection.Input);
            ddlparam[9] = CreateParam("@Kind", SqlDbType.Bit, 1, Kind, ParameterDirection.Input);

            DataBind();
            SqlCommand cmd = new SqlCommand("AddFunProgram", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 10; i++)
            {
                cmd.Parameters.Add(ddlparam[i]);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //按Id号删除编程题
        public void DeleteFunProgram(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);

            //RunProc("FindChoiceByUnit", ddlparam, Ds);
            SqlCommand Cmd = CreateCmd("DeleteFunProgram", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //按Id修改综合编程题
        public void UpdateFunProgram(string Id, string Problem_Content, string File_Path, string In1, string In2, string In3, string Out1, string Out2, string Out3, string CorrectC, string Kind)
        {
            SqlParameter[] ddlparam = new SqlParameter[11];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@File_Path", SqlDbType.VarChar, 100, File_Path, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@In1", SqlDbType.VarChar, 100, In1, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@In2", SqlDbType.VarChar, 100, In2, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@In3", SqlDbType.VarChar, 100, In3, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@Out1", SqlDbType.VarChar, 100, Out1, ParameterDirection.Input);
            ddlparam[6] = CreateParam("@Out2", SqlDbType.VarChar, 100, Out2, ParameterDirection.Input);
            ddlparam[7] = CreateParam("@Out3", SqlDbType.VarChar, 100, Out3, ParameterDirection.Input);
            ddlparam[8] = CreateParam("@CorrectC", SqlDbType.VarChar, 100, CorrectC, ParameterDirection.Input);
            ddlparam[9] = CreateParam("@Kind", SqlDbType.Bit, 1, Kind, ParameterDirection.Input);

            ddlparam[10] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);


            SqlCommand Cmd = CreateCmd("UpdateFunProgram", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //列出所有的综合编程题
        public List<Problem> FindFunProgram()
        {
            Ds = new DataSet();
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindFunProgram", sqlcon);
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

        //查询某Id的综合编程题
        public List<PFunction> FindFunProgramById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);

            Ds = new DataSet();
            RunProc("FindFunProgramById", ddlparam, Ds);
            pFun = DataSetToListFunProgram(Ds);
            return pFun;
        }

        //增加编程的填空题和修改题;Sort为1时，表示编程的填空题，Sort为2时表示编程的修改题; Kind "1"或是“0”分别表示C语言或是C++语言
        public void AddCompletionModificationProgram(string Sort, string Problem_Content, string File_Path, string K1, string K2, string K3, string Kind)
        {
            SqlParameter[] ddlparam = new SqlParameter[7];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@File_Path", SqlDbType.VarChar, 100, File_Path, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@K1", SqlDbType.VarChar, 100, K1, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@K2", SqlDbType.VarChar, 100, K2, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@K3", SqlDbType.VarChar, 100, K3, ParameterDirection.Input);
            ddlparam[6] = CreateParam("@Kind", SqlDbType.Bit, 1, Kind, ParameterDirection.Input);

            DataBind();
            SqlCommand cmd = new SqlCommand("FindFunProgramById", sqlcon);
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
                MessageBox.Show(e.ToString());
            }
        }

        //删除编程的填空题和修改题
        public void DeleteCompletionModificationProgram(string Id, string Sort)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);

            //RunProc("FindChoiceByUnit", ddlparam, Ds);
            SqlCommand Cmd = CreateCmd("DeleteCompletionModificationProgram", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //按Id修改编程的填空题和修改题
        public void UpdateCompletionModificationProgram(string Id, string Sort, string Problem_Content, string File_Path, string K1, string K2, string K3, string Kind)
        {
            SqlParameter[] ddlparam = new SqlParameter[8];
            ddlparam[0] = CreateParam("@Problem_Content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@File_Path", SqlDbType.VarChar, 100, File_Path, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@K1", SqlDbType.VarChar, 100, K1, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@K2", SqlDbType.VarChar, 100, K2, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@K3", SqlDbType.VarChar, 100, K3, ParameterDirection.Input);
            ddlparam[6] = CreateParam("@Kind", SqlDbType.Bit, 1, Kind, ParameterDirection.Input);
            ddlparam[7] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);


            SqlCommand Cmd = CreateCmd("UpdateCompletionModificationProgram", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        //列出全部的编程填空题或是修改题
        public List<Problem> FindCompletionModificationProgram(string Sort)
        {
            Ds = new DataSet();
            //RunProc("FindChoice", null, Ds);
            SqlParameter ddlparam = CreateParam("@Sort", SqlDbType.Int, 2, Sort, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindCompletionModificationProgram", sqlcon);
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

        //查询指定Id的编程填空题
        public List<PCompletion> FindCompletionProgramById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, "1", ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindCompletionModificationProgramById", ddlparam, Ds);
            pCompletion = DataSetToListCompletionProgram(Ds);
            return pCompletion;
        }

        //查询指定Id的修改题
        public List<PModif> FindModificationProgramById(string Id, string Sort)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, "2", ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindCompletionModificationProgramById", ddlparam, Ds);
            pModif = DataSetToListModifProgram(Ds);
            return pModif;
        }
        //增加Paper记录 ,ProgramState:0表示没有编程题；1表示是C语言编程；2表示C++语言编程
        public string AddPaper(string GenerateDate, string TestDate, string Paper_Path, string Title, string Teacher_Id, int ProgramState)
        {
            SqlParameter[] ddlparam = new SqlParameter[7];
            ddlparam[0] = CreateParam("@GenerateDate", SqlDbType.DateTime, 20, GenerateDate, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@TestDate", SqlDbType.DateTime, 20, TestDate, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Paper_Path", SqlDbType.VarChar, 100, Paper_Path, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Title", SqlDbType.VarChar, 50, Title, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Teacher_Id", SqlDbType.Int, 20, Teacher_Id, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@ProgramState", SqlDbType.Int, 5, ProgramState, ParameterDirection.Input);
            //ddlparam[6].Direction = ParameterDirection.Output;       // 设置为输出参数
           // string  Id = "";
            //ddlparam[6] = CreateParam("@Id", SqlDbType.Int, 5,Id.ToString() , ParameterDirection.Input);
            
            DataBind();
            SqlCommand cmd = new SqlCommand("AddPaper", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 7; i++)
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
                MessageBox.Show(e.ToString());
            }
            MessageBox.Show(Id.Value.ToString());
            return Id.Value.ToString();
        }

        //按照Id 删除Paper记录
        public void DeletePaper(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            
            //RunProc("FindChoiceByUnit", ddlparam, Ds);
            SqlCommand Cmd = CreateCmd("DeletePaper", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
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
            ddlparam[6] = CreateParam("@ProgramState", SqlDbType.Int, 5, Id, ParameterDirection.Input);


            SqlCommand Cmd = CreateCmd("UpdatePaper", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        //列出所有的Paper记录
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
                MessageBox.Show(Ex.ToString());
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
            RunProc("FindPaperById", ddlparam, Ds);
            paper = DataSetToListPaper(Ds);
            return paper;
        }
        //添加章节，UnitName具体的章节名字，例如“故障恢复” Unit 例子：1-12；TypeId 0,1,2分别表示填空选择判断
        public void AddUnit(string UnitName,int Unit,int TypeId)
        {
            string A = Unit.ToString();
            string B = TypeId.ToString();
            SqlParameter[] ddlparam = new SqlParameter[3];
            ddlparam[0] = CreateParam("@UnitName", SqlDbType.VarChar, 100, UnitName, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Unit", SqlDbType.Int, 5, A, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@TypeId", SqlDbType.Int, 5, B, ParameterDirection.Input);
           
            DataBind();
            SqlCommand cmd = new SqlCommand("AddPaper", sqlcon);
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
                MessageBox.Show(e.ToString());
            }
        }
        //Description:	给定Type( 0,1,2分别表示填空选择判断的标号)，列出所有相应题型的所有章节名
        public List<string> FindUnit(string TypeId)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@TypeId", SqlDbType.Int, 3, Id, ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindUnit", ddlparam, Ds);
            UnitList = DataSetToListString(Ds);
            return UnitList;
        }
        private List<string> DataSetToListString(DataSet Ds)
        {
            //throw new NotImplementedException();
            List<string> result = new List<string>();
            DataTable p_Data = p_DataSet.Tables[0];

            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                result.Add(p_Data.Rows[j][0].ToString());
            }
            return result();
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
                        problem.paperID =p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "Title")
                        problem.paperName = (string)p_Data.Rows[j][i];
                    if(p_Data.Columns[i].ToString()=="GenerateDate")
                        problem.createTime = p_Data.Rows[j][i].ToString();
                    if (p_Data.Columns[i].ToString() == "TName")
                        problem.author = (string)p_Data.Rows[j][i];
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

    }
}
