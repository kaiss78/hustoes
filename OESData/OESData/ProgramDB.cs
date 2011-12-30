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
        #region 编程题有关方法

        public List<int> ImportProgram(List<string[]> lst)
        {
            int x;
            ProgramPType tp;
            PLanguage lang;
            List<int> res = new List<int>();
            string[] output, tmp, tmp2;
            List<string> input = new List<string>();
            try
            {
                foreach (string[] str in lst)
                {
                    if (str[3].ToLower() == "comp")
                        tp = ProgramPType.Completion;
                    else if (str[3].ToLower() == "modi")
                        tp = ProgramPType.Modify;
                    else
                        tp = ProgramPType.Function;
                    if (str[4].ToLower() == "c")
                        lang = PLanguage.C;
                    else if (str[4].ToLower() == "cpp")
                        lang = PLanguage.CPP;
                    else
                        lang = PLanguage.VB;
                    x = AddProgram(str[0], tp, lang, int.Parse(str[1]), int.Parse(str[2]));
                    if (tp == ProgramPType.Function)
                    {
                        tmp = str[7].Split('`');
                        foreach (string s in tmp)
                            input.Add(s);
                    }
                    tmp = str[8].Split(new string[] { "``" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < tmp.Length; i++)    //添加答案
                    {
                        tmp2 = tmp[i].Split('`');
                        if (tp == ProgramPType.Function)
                            foreach (string s in tmp2)
                                AddProgramAnswer(x, i + 1, input[i], s);
                        else
                            foreach (string s in tmp2)
                                AddProgramAnswer(x, i + 1, "", s);
                    }
                    res.Add(x);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

        //增加编程的综合题，返回PID
        //如果不需要Input的话，就new一个新的List<List<string>>作为Input
        public int AddProgram(string PContent, ProgramPType Type, PLanguage Language, int Unit,int PLevel)
        {
            int PID = -1;
            int blankIdx;
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Output));
            ddlparam.Add(CreateParam("@PContent", SqlDbType.VarChar, 500, PContent, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Type", SqlDbType.Int, 0, Convert.ToInt32(Type), ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Language", SqlDbType.Int, 0, Convert.ToInt32(Language), ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            try
            {
                RunProc("AddProgram", ddlparam);
                PID = Convert.ToInt32(ddlparam[0].Value);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            return PID;
        }

        //添加答案（SeqNum从1开始）
        public void AddProgramAnswer(int PID, int SeqNum, string Input, string Output)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            dp.Add(CreateParam("@SeqNum", SqlDbType.Int, 0, SeqNum, ParameterDirection.Input));
            dp.Add(CreateParam("@Input", SqlDbType.VarChar, 9999, Input, ParameterDirection.Input));
            dp.Add(CreateParam("@Output", SqlDbType.VarChar, 9999, Output, ParameterDirection.Input));
            try
            {
                RunProc("AddProgramAnswer", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //按PID删除编程题
        public void DeleteProgram(int PID)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("DeleteProgram", ddlparam);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void UpdateProgram(int PID, ProgramPType Type, PLanguage Language, int Unit, int PLevel)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            dp.Add(CreateParam("@Type", SqlDbType.Int, 0, (int)Type, ParameterDirection.Input));
            dp.Add(CreateParam("@Language", SqlDbType.Int, 0, (int)Language, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            try
            {
                RunProc("UpdateProgram", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<PModif> FindModifyProgramByPID(int PID)
        {
            List<PModif> result = new List<PModif>();
            List<ProgramProblem> tmp = new List<ProgramProblem>();
            try
            {
                tmp = FindProgramByPID(PID);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            foreach (ProgramProblem prob in tmp)
            {
                result.Add((PModif)prob);
            }
            return result;
        }

        public List<PCompletion> FindCompletionProgramByPID(int PID)
        {
            List<PCompletion> result = new List<PCompletion>();
            List<ProgramProblem> tmp = new List<ProgramProblem>();
            try
            {
                tmp = FindProgramByPID(PID);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            foreach (ProgramProblem prob in tmp)
            {
                result.Add((PCompletion)prob);
            }
            return result;
        }

        public List<PFunction> FindFunctionProgramByPID(int PID)
        {
            List<PFunction> result = new List<PFunction>();
            List<ProgramProblem> tmp = new List<ProgramProblem>();
            try
            {
                tmp = FindProgramByPID(PID);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            foreach (ProgramProblem prob in tmp)
            {
                result.Add((PFunction)prob);
            }
            return result;
        }

        public List<ProgramProblem> FindProgramByPID(int PID)
        {
            List<ProgramProblem> result = new List<ProgramProblem>();
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("FindProgramByPID", dp, Ds);
                result = DataSetToListProgram(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
        /*
        public ProgramProblem FindProgramByPID(int PID)
        {
            List<ProgramProblem> result = new List<ProgramProblem>();
            DataSet Ds = new DataSet();
            ProgramProblem res;
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("FindProgramByPID", dp, Ds);
                result = DataSetToListProgram(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (result.Count > 0)
            {
                res = result[0];
                if (res.Type == ProgramPType.Completion)
                    return (PCompletion)res;
                else if (res.Type == ProgramPType.Modify)
                    return (PModif)res;
                else
                    return (PFunction)res;
            }
            return result;
        }
        */
        public List<ProgramProblem> FindAllProgram(string PContent, ProgramPType Type, PLanguage Language, int Unit, int CourseId, int PLevel,
            int PageIndex, int PageSize)
        {
            List<ProgramProblem> result = new List<ProgramProblem>();
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@tableName", SqlDbType.VarChar, 50, "Program_Table", ParameterDirection.Input));
            dp.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            dp.Add(CreateParam("@Type", SqlDbType.Int, 0, (int)Type, ParameterDirection.Input));
            dp.Add(CreateParam("@Language", SqlDbType.Int, 0, (int)Language, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            dp.Add(CreateParam("@PageIndex", SqlDbType.Int, 0, PageIndex, ParameterDirection.Input));
            dp.Add(CreateParam("@PageSize", SqlDbType.Int, 0, PageSize, ParameterDirection.Input));
            try
            {
                RunProc("FindItems", dp, Ds);
                result = DataSetToListProgram(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public List<ProgramAnswer> FindProgramAnswerByPID(int PID)
        {
            DataSet Ds = new DataSet();
            List<ProgramAnswer> res = new List<ProgramAnswer>();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("FindProgramAnswerByPID", dp, Ds);
                res = DataSetToListProgramAnswer(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

#if false
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
            ddlparam[9] = CreateParam("@Kind", SqlDbType.Bit, 1, (Kind == "0" ? false : true), ParameterDirection.Input);

            ddlparam[10] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);


            SqlCommand Cmd = CreateCmd("UpdateFunProgram", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
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
            ddlparam[6] = CreateParam("@Kind", SqlDbType.Bit, 1, (Kind == "0" ? false : true), ParameterDirection.Input);

            DataBind();
            SqlCommand cmd = new SqlCommand("AddCompletionModificationProgram", sqlcon);
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
                throw e;
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
                throw e;
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
            ddlparam[6] = CreateParam("@Kind", SqlDbType.Bit, 1, (Kind == "0" ? false : true), ParameterDirection.Input);
            ddlparam[7] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);


            SqlCommand Cmd = CreateCmd("UpdateCompletionModificationProgram", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
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
        public List<PModif> FindModificationProgramById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, "2", ParameterDirection.Input);
            Ds = new DataSet();
            RunProc("FindCompletionModificationProgramById", ddlparam, Ds);
            pModif = DataSetToListModifProgram(Ds);
            return pModif;
        }

        //-- Description:   查找C语言填空试题的ID和题目
        public List<Problem> FindCCompletionProblemContent()
        {
            Ds = new DataSet();
            List<Problem> problemList = new List<Problem>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindCCompletionProblemContent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            problemList = DataSetToProblemList(Ds);
            return problemList;
        }

        //-- Description:   查找C++填空试题的ID和题目
        public List<Problem> FindCppCompletionProblemContent()
        {
            Ds = new DataSet();
            List<Problem> problemList = new List<Problem>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindCppCompletionProblemContent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            problemList = DataSetToProblemList(Ds);
            return problemList;
        }

        //-- Description:   查找C语言编程试题的ID和题目
        public List<Problem> FindCFunProblemContent()
        {
            Ds = new DataSet();
            List<Problem> problemList = new List<Problem>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindCFunProblemContent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            problemList = DataSetToProblemList(Ds);
            return problemList;
        }

        //-- Description:   查找C++编程试题的ID和题目
        public List<Problem> FindCppFunProblemContent()
        {
            Ds = new DataSet();
            List<Problem> problemList = new List<Problem>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindCppFunProblemContent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            problemList = DataSetToProblemList(Ds);
            return problemList;
        }

        //-- Description:   查找C语言改错试题的ID和题目
        public List<Problem> FindCModificationProblemContent()
        {
            Ds = new DataSet();
            List<Problem> problemList = new List<Problem>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindCModificationProblemContent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            problemList = DataSetToProblemList(Ds);
            return problemList;
        }

        //-- Description:   查找C++改错试题的ID和题目
        public List<Problem> FindCppModificationProblemContent()
        {
            Ds = new DataSet();
            List<Problem> problemList = new List<Problem>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindCppModificationProblemContent", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            problemList = DataSetToProblemList(Ds);
            return problemList;
        }
#endif
        #endregion
    }
}
