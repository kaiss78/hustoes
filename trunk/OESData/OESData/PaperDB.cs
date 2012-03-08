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
        #region paper记录管理

        public void ImportPaper(List<string[]> lst)
        {
            
        }

        public int AddPaper(string GenerateDate, string Title, int TeacherId)
        {
            int PaperId = -1;
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PaperId", SqlDbType.Int, 5, PaperId, ParameterDirection.Output));
            ddlparam.Add(CreateParam("@GenerateDate", SqlDbType.DateTime, 0, GenerateDate, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Title", SqlDbType.VarChar, 500, Title, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@TeacherId", SqlDbType.Int, 5, TeacherId, ParameterDirection.Input));
            try
            {
                RunProc("AddPaper", ddlparam);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            return Convert.ToInt32(ddlparam[0].Value);
        }

        //按照Id 删除Paper记录
        public void DeletePaper(int PaperId)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PaperId", SqlDbType.Int, 5, PaperId, ParameterDirection.Input));
            try
            {
                RunProc("DeletePaper", ddlparam);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void UpdatePaper(int PaperId, string GenerateDate, string Title, int TeacherId)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PaperId", SqlDbType.Int, 0, PaperId, ParameterDirection.Input));
            dp.Add(CreateParam("@GenerateDate", SqlDbType.DateTime, 20, Convert.ToDateTime(GenerateDate), ParameterDirection.Input));
            dp.Add(CreateParam("@Title", SqlDbType.VarChar, 500, Title, ParameterDirection.Input));
            dp.Add(CreateParam("@TeacherId", SqlDbType.Int, 0, TeacherId, ParameterDirection.Input));
            try
            {
                RunProc("UpdatePaper", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Paper> FindPaperByPaperId(int PaperId)
        {
            DataSet Ds = new DataSet();
            List<Paper> result = new List<Paper>();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PaperId", SqlDbType.Int, 0, PaperId, ParameterDirection.Input));
            try
            {
                RunProc("FindPaperByPaperId", dp, Ds);
                result = DataSetToListPaper(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        //列出所有的Paper记录,其中将相关的出试卷的老师信息也查找出来
        public List<Paper> FindAllPaper()
        {
            List<Paper> results = new List<Paper>();
            Ds = new DataSet();

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
            results = DataSetToListPaper(Ds);
            return results;
        }

        //查找两个日期中的试卷
        public List<Paper> FindPaperByTwoDates(DateTime std, DateTime edd)
        {
            Ds = new DataSet();
            List<Paper> paperList = new List<Paper>();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@StartDate", SqlDbType.DateTime, 0, std, ParameterDirection.Input));
            dp.Add(CreateParam("EndDate", SqlDbType.DateTime, 0, edd, ParameterDirection.Input));
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
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@StartDate", SqlDbType.DateTime, 0, Convert.ToDateTime(year + "/01/01"), ParameterDirection.Input));
            dp.Add(CreateParam("@EndDate", SqlDbType.DateTime, 0, Convert.ToDateTime(year + "/12/31"), ParameterDirection.Input));
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
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@Title", SqlDbType.VarChar, 50, title, ParameterDirection.Input));
            try { RunProc("FindPaperByTitle", dp, Ds); }
            catch { throw; }
            paperList = DataSetToListPaper(Ds);
            return paperList;
        }

#if flase
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
        public void UpdatePaper(string Id, string GenerateDate, string TestDate, string Paper_Path, string Title, string Teacher_Id, int ProgramState)
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
#endif
        #endregion
    }
}
