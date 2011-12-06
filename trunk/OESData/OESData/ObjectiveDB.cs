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
        #region 选择题有关的方法

        public void AddManyChoices(List<string[]> lst)
        {
            SqlTransaction tx = sqlcon.BeginTransaction();
            foreach (string[] str in lst)
                AddChoice(str[0], str[1], str[2], str[3], str[4], str[5], int.Parse(str[6]), int.Parse(str[7]));
            tx.Commit();
        }
        //向数据库中添加选择题
        public void AddChoice(string Problem_Content, string A, string B, string C, string D, string Answer, int Unit, int Level)
        {
            SqlParameter[] ddlparam = new SqlParameter[8];
            ddlparam[0] = CreateParam("@content", SqlDbType.VarChar, 500, Problem_Content, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@A", SqlDbType.VarChar, 100, A, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@B", SqlDbType.VarChar, 100, B, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@C", SqlDbType.VarChar, 100, C, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@D", SqlDbType.VarChar, 100, D, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@Answer", SqlDbType.VarChar, 100, Answer, ParameterDirection.Input);
            ddlparam[6] = CreateParam("@Unit", SqlDbType.Int, 5, Unit.ToString(), ParameterDirection.Input);
            ddlparam[7] = CreateParam("@PLevel", SqlDbType.Int, 5, Level.ToString(), ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddChoice", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 8; i++)
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
        //按Id删除选择题
        public void DeleteChoiceById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
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
        //按单元查询选择题
        public List<Problem> FindChoiceByUnit(int Unit)
        {
            string unit = Unit.ToString();
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Unit", SqlDbType.Int, 5, unit, ParameterDirection.Input);
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
        //添加填空题
        public void AddCompletion(string PContent, int Unit, int Level)
        {
            SqlParameter[] ddlparam = new SqlParameter[3];
            ddlparam[0] = CreateParam("@PContent", SqlDbType.VarChar, 500, PContent, ParameterDirection.Input);

            ddlparam[1] = CreateParam("@Unit", SqlDbType.Int, 5, Unit.ToString(), ParameterDirection.Input);
            ddlparam[2] = CreateParam("@PLevel", SqlDbType.Int, 5, Level.ToString(), ParameterDirection.Input);

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
        //按Id删除填空题
        public void DeleteCompletionById(string Id)
        {
            SqlParameter[] ddlparam = new SqlParameter[1];
            ddlparam[0] = CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input);
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
        public void AddTof(string PContent, int Unit,int Level)
        {
            SqlParameter[] ddlparam = new SqlParameter[3];
            ddlparam[0] = CreateParam("@PContent", SqlDbType.VarChar, 500, PContent, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Unit", SqlDbType.Int, 5, Unit.ToString(), ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Level", SqlDbType.Int, 5, Level.ToString(), ParameterDirection.Input);

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
            SqlCommand Cmd = CreateCmd("DeleteJudgment", ddlparam);
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
    }
}
