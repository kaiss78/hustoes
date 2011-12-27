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

        #region office类题目有关的方法

        public List<int> ImportOffice(List<string[]> lst)
        {
            int x;
            OES.Model.Office.OfficeType tp;
            List<int> res = new List<int>();
            try
            {
                foreach (string[] str in lst)
                {
                    if (str[3] == "Word") tp = OES.Model.Office.OfficeType.Word;
                    else if (str[3] == "Excel") tp = OES.Model.Office.OfficeType.Excel;
                    else tp = OES.Model.Office.OfficeType.PowerPoint;
                    x = AddOffice(str[0], int.Parse(str[1]), int.Parse(str[2]), tp);
                    res.Add(x);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

        //增加Office类题目，返回PID
        public int AddOffice(string PContent, int Unit, int PLevel, OES.Model.Office.OfficeType Type)
        {
            int PID = -1;
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Output));
            ddlparam.Add(CreateParam("@PContent", SqlDbType.VarChar, 500, PContent, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Type", SqlDbType.Int, 0, Convert.ToInt32(Type), ParameterDirection.Input));
            try
            {
                RunProc("AddOffice",ddlparam);
                PID = Convert.ToInt32(ddlparam[0].Value);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            return PID;
        }

        //删除Office类题目
        public void DeleteOffice(int PID)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@PID", SqlDbType.Int, 5, PID, ParameterDirection.Input));
            try
            {
                RunProc("DeleteOffice", ddlparam);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //按PID修改Office类题目
        public void UpdateOffice(int PID, string PContent, int Unit, int PLevel, OES.Model.Office.OfficeType Type)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            dp.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            dp.Add(CreateParam("@Type", SqlDbType.Int, 0, (int)Type, ParameterDirection.Input));
            try
            {
                RunProc("UpdateOffice", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<OfficeWord> FindOfficeWordByPID(int PID)
        {
            List<OfficeWord> result = new List<OfficeWord>();
            List<Office> tmp = new List<Office>();
            try
            {
                tmp = FindOfficeByPID(PID);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            foreach (Office prob in tmp)
            {
                OfficeWord ow = new OfficeWord();
                ow.Plevel = prob.Plevel;
                ow.problem = prob.problem;
                ow.problemId = prob.problemId;
                ow.type = prob.type;
                ow.unit = prob.unit;
                result.Add(ow);
            }
            return result;
        }

        public List<OfficeExcel> FindOfficeExcelByPID(int PID)
        {
            List<OfficeExcel> result = new List<OfficeExcel>();
            List<Office> tmp = new List<Office>();
            try
            {
                tmp = FindOfficeByPID(PID);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            foreach (Office prob in tmp)
            {
                OfficeExcel oe = new OfficeExcel();
                oe.Plevel = prob.Plevel;
                oe.problem = prob.problem;
                oe.problemId = prob.problemId;
                oe.type = prob.type;
                oe.unit = prob.unit;
                result.Add(oe);
            }
            return result;
        }

        public List<OfficePowerPoint> FindOfficePowerPointByPID(int PID)
        {
            List<OfficePowerPoint> result = new List<OfficePowerPoint>();
            List<Office> tmp = new List<Office>();
            try
            {
                tmp = FindOfficeByPID(PID);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            foreach (Office prob in tmp)
            {
                OfficePowerPoint op = new OfficePowerPoint();
                op.Plevel = prob.Plevel;
                op.problem = prob.problem;
                op.problemId = prob.problemId;
                op.type = prob.type;
                op.unit = prob.unit;
                result.Add(op);
            }
            return result;
        }

        public List<Office> FindOfficeByPID(int PID)
        {
            DataSet Ds = new DataSet();
            List<Office> result = new List<Office>();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("FindOfficeByPID", dp, Ds);
                result = DataSetToListOffice(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
        /*
        public Office FindOfficeByPID(int PID)
        {
            DataSet Ds = new DataSet();
            List<Office> result = new List<Office>();
            Office res;
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@PID", SqlDbType.Int, 0, PID, ParameterDirection.Input));
            try
            {
                RunProc("FindOfficeByPID", dp, Ds);
                //TODO
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (result.Count > 0)
            {
                res = result[0];
                if (res.type == ProblemType.Word)
                    return (OfficeWord)res;
                else if (res.type == ProblemType.Excel)
                    return (OfficeExcel)res;
                else
                    return (OfficePowerPoint)res;
            }
            else
                return null;
        }
        */
        public List<Office> FindAllOffice(string PContent, int Unit, int CourseId, int PLevel, OES.Model.Office.OfficeType Type, int PageIndex, int PageSize)
        {
            List<Office> result = new List<Office>();
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@tableName", SqlDbType.VarChar, 50, "Office_Table", ParameterDirection.Input));
            dp.Add(CreateParam("@PContent", SqlDbType.VarChar, 9999, PContent, ParameterDirection.Input));
            dp.Add(CreateParam("@Type", SqlDbType.Int, 0, (int)Type, ParameterDirection.Input));
            dp.Add(CreateParam("@Language", SqlDbType.Int, 0, -1, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            dp.Add(CreateParam("@PLevel", SqlDbType.Int, 0, PLevel, ParameterDirection.Input));
            dp.Add(CreateParam("@PageIndex", SqlDbType.Int, 0, PageIndex, ParameterDirection.Input));
            dp.Add(CreateParam("@PageSize", SqlDbType.Int, 0, PageSize, ParameterDirection.Input));
            try
            {
                RunProc("FindItems", dp, Ds);
                result = DataSetToListOffice(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

#if false
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
#endif
        #endregion
    }
}
