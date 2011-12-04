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
        #region 编程题有关方法 0:C    1:C++   2:VB

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
            ddlparam[9] = CreateParam("@Kind", SqlDbType.Bit, 1, (Kind == "0" ? false : true), ParameterDirection.Input);

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
                Console.WriteLine(e.ToString());
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
                Console.WriteLine(e.ToString());
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

        #endregion
    }
}
