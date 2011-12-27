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
        //获取查询的记录条数
        public int FindItemsCount(string tableName, string PContent, int Unit, int CourseId, int PLevel, int Type, int Language)
        {
            int res = 0;
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@tableName", SqlDbType.VarChar, 50, tableName + "_Table", ParameterDirection.Input));
            dp.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            dp.Add(CreateParam("@Type", SqlDbType.Int, 0, Type, ParameterDirection.Input));
            dp.Add(CreateParam("@Language", SqlDbType.Int, 0, Language, ParameterDirection.Input));
            try
            {
                RunProc("FindItemsCount", dp, Ds);
                res = Convert.ToInt32(Ds.Tables[0].Rows[0][0]);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

        #region 选择题有关的方法 - 全部测试过了

        //批量导入选择题
        public void ImportChoice(List<string[]> lst)
        {
            try
            {
                foreach (string[] str in lst)
                    AddChoice(str[0], str[1], str[2], str[3], str[4], str[5], int.Parse(str[6]), int.Parse(str[7]));
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
        //向数据库中添加选择题
        public int AddChoice(string PContent, string A, string B, string C, string D, string Answer, int Unit, int PLevel)
        {
            int PID = -1;
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Output));
            ddlparam.Add(CreateParam("@PContent", SqlDbType.VarChar, 500, PContent, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@A", SqlDbType.VarChar, 100, A, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@B", SqlDbType.VarChar, 100, B, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@C", SqlDbType.VarChar, 100, C, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@D", SqlDbType.VarChar, 100, D, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Answer", SqlDbType.VarChar, 100, Answer, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Unit", SqlDbType.Int, 5, Unit.ToString(), ParameterDirection.Input));
            ddlparam.Add(CreateParam("@PLevel", SqlDbType.Int, 5, PLevel.ToString(), ParameterDirection.Input));
            try
            {
                RunProc("AddChoice", ddlparam);
                PID = Convert.ToInt32(ddlparam[0].Value);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            return PID;
        }
        
        //按Id删除选择题
        public void DeleteChoice(int PID)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@Id", SqlDbType.Int, 5, PID, ParameterDirection.Input));
            try
            {
                RunProc("DeleteChoice", ddlparam);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        //按PID修改选择题
        public void UpdateChoice(int PID, string PContent,
            string A, string B, string C, string D, string Answer, int Unit, int PLevel)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 9, PID, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@PContent", SqlDbType.VarChar, 500, PContent, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@A", SqlDbType.VarChar, 100, A, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@B", SqlDbType.VarChar, 100, B, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@C", SqlDbType.VarChar, 100, C, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@D", SqlDbType.VarChar, 100, D, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Answer", SqlDbType.VarChar, 100, Answer, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Unit", SqlDbType.Int, 5, Unit.ToString(), ParameterDirection.Input));
            ddlparam.Add(CreateParam("@PLevel", SqlDbType.Int, 5, PLevel.ToString(), ParameterDirection.Input));
            try
            {
                RunProc("UpdateChoice", ddlparam);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
        //按PID查找选择题
        public List<Choice> FindChoiceByPID(int PID)
        {
            DataSet Ds = new DataSet();
            List<Choice> result = new List<Choice>();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 9, PID, ParameterDirection.Input));
            try
            {
                RunProc("FindChoiceByPID", dp, Ds);
                result = DataSetToListChoice(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
        
        //按题干、章节、课程、难度查找选择题，显示第PageIndex页（从1开始），每页PageSize项内容
        //PContent为""表示不按PContent查询；Unit或CourseId或PLevel为-1表示不按它们查询
        public List<Choice> FindAllChoice(string PContent, int Unit, int CourseId, int PLevel, int PageIndex, int PageSize)
        {
            DataSet Ds = new DataSet();
            List<Choice> result = new List<Choice>();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@tableName", SqlDbType.VarChar, 50, "Choice_Table", ParameterDirection.Input));
            dp.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            dp.Add(CreateParam("@Type", SqlDbType.Int, 0, -1, ParameterDirection.Input));
            dp.Add(CreateParam("@Language", SqlDbType.Int, 0, -1, ParameterDirection.Input));
            dp.Add(CreateParam("@PageIndex", SqlDbType.Int, 0, PageIndex, ParameterDirection.Input));
            dp.Add(CreateParam("@PageSize", SqlDbType.Int, 0, PageSize, ParameterDirection.Input));
            try
            {
                RunProc("FindItems", dp, Ds);
                result = DataSetToListChoice(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
#if false
        //按单元查询选择题
        public List<Problem> FindChoiceByUnit(int Unit)
        {
            string unit = Unit.ToString();
            List<SqlParameter> ddlparam = new List<SqlParameter>();
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
#endif
        #endregion

        #region 填空题有关的方法 - 全部测试过了

        public void ImportCompletion(List<string[]> lst)
        {
            List<String> ansList;
            try
            {
                foreach (string[] str in lst)
                {
                    ansList = new List<string>();
                    string[] ans = str[1].Split('`');
                    foreach (string s in ans)
                        ansList.Add(s);
                    AddCompletion(str[0], int.Parse(str[2]), int.Parse(str[3]), ansList);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //添加填空题，先添加填空题至数据库，再把对应答案添加至数据库
        public int AddCompletion(string PContent, int Unit, int PLevel, List<string> Answer)
        {
            int PID = -1;
            DataBind();
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Output));
            ddlparam.Add(CreateParam("@PContent", SqlDbType.VarChar, 500, PContent, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Unit", SqlDbType.Int, 5, Unit.ToString(), ParameterDirection.Input));
            ddlparam.Add(CreateParam("@PLevel", SqlDbType.Int, 5, PLevel.ToString(), ParameterDirection.Input));
            try
            {
                RunProc("AddCompletion", ddlparam);
                PID = Convert.ToInt32(ddlparam[0].Value);
                foreach (string ans in Answer)
                    AddCompletionAnswer(PID, ans);
                return PID;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString()); 
                return -1;
            }
        }

        //按PID添加填空题的答案（SeqNum=1）
        public void AddCompletionAnswer(int PID, string Answer)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            dp.Add(CreateParam("@SeqNum", SqlDbType.Int, 0, 1, ParameterDirection.Input));
            dp.Add(CreateParam("@Answer", SqlDbType.VarChar, 9999, Answer, ParameterDirection.Input));
            try
            {
                RunProc("AddCompletionAnswer", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //按PID删除填空题
        public void DeleteCompletion(int PID)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 5, PID, ParameterDirection.Input));
            try
            {
                RunProc("DeleteCompletion", ddlparam);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //按PID删除填空题答案
        public void DeleteCompletionAnswerByPID(int PID)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("DeleteCompletionAnswerByPID", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //按PID更新填空题（需要更新答案）
        public void UpdateCompletion(int PID, string PContent, int Unit, int PLevel, List<string> Answer)
        {
            DataBind();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            dp.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            try
            {
                SqlTransaction tx = sqlcon.BeginTransaction();
                RunProc("UpdateCompletion", dp);
                DeleteCompletionAnswerByPID(PID);
                foreach (string ans in Answer)
                    AddCompletionAnswer(PID, ans);
                tx.Commit();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //根据PID查找单个填空题（需要找出答案）
        public List<Completion> FindCompletionByPID(int PID)
        {
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            List<Completion> result = new List<Completion>();
            dp.Add(CreateParam("@PID", SqlDbType.VarChar, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("FindCompletionByPID", dp, Ds);
                result = DataSetToListCompletion(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (result.Count != 0)
            {
                try
                {
                    result[0].ans = FindCompletionAnswerByPID(PID);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return result;
        }

        //根据PID查找填空题答案
        public List<string> FindCompletionAnswerByPID(int PID)
        {
            List<string> res = new List<string>();
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("FindCompletionAnswerByPID", dp, Ds);
                int rowcnt = Ds.Tables[0].Rows.Count;
                foreach (DataRow dr in Ds.Tables[0].Rows)
                    res.Add(dr["Answer"].ToString());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

        //按多个关键字查找填空题（无须找出答案）
        public List<Completion> FindAllCompletion(string PContent, int Unit, int CourseId, int PLevel, int PageIndex, int PageSize)
        {
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            List<Completion> result = new List<Completion>();
            dp.Add(CreateParam("@tableName", SqlDbType.VarChar, 50, "Completion_Table", ParameterDirection.Input));
            dp.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            dp.Add(CreateParam("@Type", SqlDbType.Int, 0, -1, ParameterDirection.Input));
            dp.Add(CreateParam("@Language", SqlDbType.Int, 0, -1, ParameterDirection.Input));
            dp.Add(CreateParam("@PageIndex", SqlDbType.Int, 0, PageIndex, ParameterDirection.Input));
            dp.Add(CreateParam("@PageSize", SqlDbType.Int, 0, PageSize, ParameterDirection.Input));
            try
            {
                RunProc("FindItems", dp, Ds);
                result = DataSetToListCompletion(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

#if flase
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
#endif
        #endregion

        #region 判断题有关的方法 - 全部测试过了

        public void ImportJudgment(List<string[]> lst)
        {
            try
            {
                foreach (string[] str in lst)
                    AddJudgment(str[0], str[1], int.Parse(str[2]), int.Parse(str[3]));
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //增加判断题，返回PID
        public int AddJudgment(string PContent,string Answer, int Unit, int PLevel)
        {
            int PID = -1;
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Output));
            ddlparam.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Answer", SqlDbType.VarChar, 10, Answer, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            try
            {
                RunProc("AddJudgment", ddlparam);
                PID = Convert.ToInt32(ddlparam[0].Value);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            return PID;
        }

        //按PID删除判断题
        public void DeleteJudgment(int PID)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("DeleteJudgment", ddlparam);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //按PID更新判断题
        public void UpdateJudgment(int PID, string PContent, string Answer, int Unit, int PLevel)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            dp.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            dp.Add(CreateParam("@Answer", SqlDbType.VarChar, 50, Answer, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            try
            {
                RunProc("UpdateJudgment", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //按PID查找判断题
        public List<Judgment> FindJudgmentByPID(int PID)
        {
            DataSet Ds = new DataSet();
            List<Judgment> result = new List<Judgment>();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("FindJudgmentByPID", dp, Ds);
                result = DataSetToListJudgment(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public List<Judgment> FindAllJudgment(string PContent, int Unit, int CourseId, int PLevel, int PageIndex, int PageSize)
        {
            DataSet Ds = new DataSet();
            List<Judgment> result = new List<Judgment>();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@tableName", SqlDbType.VarChar, 50, "Judgment_Table", ParameterDirection.Input));
            dp.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            dp.Add(CreateParam("@Type", SqlDbType.Int, 0, -1, ParameterDirection.Input));
            dp.Add(CreateParam("@Language", SqlDbType.Int, 0, -1, ParameterDirection.Input));
            dp.Add(CreateParam("@PageIndex", SqlDbType.Int, 0, PageIndex, ParameterDirection.Input));
            dp.Add(CreateParam("@PageSize", SqlDbType.Int, 0, PageSize, ParameterDirection.Input));
            try
            {
                RunProc("FindItems", dp, Ds);
                result = DataSetToListJudgment(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

#if false
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
#endif
        #endregion
    }
}
