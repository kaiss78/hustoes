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
            ddlparam[1] = CreateParam("@Sort", SqlDbType.Int, 2, SORT_EXCEL, ParameterDirection.Input);
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
    }
}
