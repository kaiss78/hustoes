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
        #region 分数管理
        // -- Description:	查询某个班级某次考试的所有成绩
        private List<Score> DataSetToScore(DataSet p_DataSet)
        {
            DataTable p_Data = p_DataSet.Tables[0];
            // 返回值初始化   
            List<Score> result = new List<Score>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                Score sco = new Score();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "StudentName")
                        sco.stuName = (string)(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "ClassName")
                        sco.stuClassName = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "StudentID")
                        sco.studentID = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "TotalScore")
                        sco.Value = Convert.ToInt32(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "Title")
                        sco.paperTitle = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "ExamName")
                        sco.examName = (string)p_Data.Rows[j][i];
                }
                result.Add(sco);
            }
            return result;
        }

        private List<String> DataSetToString(DataSet p_DataSet)
        {
            DataTable p_Data = p_DataSet.Tables[0];
            List<String> res = new List<string>();
            for (int i = 0; i < p_Data.Rows.Count; i++)
                res.Add(p_Data.Rows[i][0].ToString());
            return res;
        }

        //添加信息至Score表
        public void AddScore(int ExamID, int PaperID, string StudentID, int Score)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@ExamID", SqlDbType.Int, 0, ExamID, ParameterDirection.Input));
            dp.Add(CreateParam("@PaperID", SqlDbType.Int, 0, PaperID, ParameterDirection.Input));
            dp.Add(CreateParam("@StudentID", SqlDbType.VarChar, 50, StudentID, ParameterDirection.Input));
            dp.Add(CreateParam("@Score", SqlDbType.Int, 0, Score, ParameterDirection.Input));
            try
            {
                RunProc("AddScore", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //根据班级查找考试
        public List<String> FindExamByClass(string ClassName)
        {
            List<String> res = new List<string>();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@ClassName", SqlDbType.VarChar, 50, ClassName, ParameterDirection.Input));
            Ds = new DataSet();
            try
            {
                RunProc("FindExamByClass", dp, Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            res = DataSetToString(Ds);
            return res;
        }

        public List<Score> FindScoreByClassExam(string ClassName, string ExamName)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@ClassName", SqlDbType.VarChar, 50, ClassName, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@ExamName", SqlDbType.VarChar, 50, ExamName, ParameterDirection.Input));
            Ds = new DataSet();
            RunProc("FindScoreByClassExam", ddlparam, Ds);
            List<Score> score = new List<Score>();
            score = DataSetToScore(Ds);
            return score;
        }
        #endregion
    }
}
