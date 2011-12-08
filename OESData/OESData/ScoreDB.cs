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
                Score problem = new Score();
                for (int i = 0; i < p_Data.Columns.Count; i++)
                {
                    // 数据库NULL值单独处理   
                    if (p_Data.Columns[i].ToString() == "StudentName")
                        problem.stuName = (string)(p_Data.Rows[j][i]);
                    if (p_Data.Columns[i].ToString() == "ClassName")
                        problem.stuClassName = (string)p_Data.Rows[j][i];
                    if (p_Data.Columns[i].ToString() == "TotalScore")
                        problem.score = (string)p_Data.Rows[j][i];


                }

                result.Add(problem);
            }
            return result;
        }


        public List<Score> FindScoreByClassPaper(string ClassName, string Title)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@ClassName", SqlDbType.VarChar, 50, ClassName, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Title", SqlDbType.VarChar, 50, Title, ParameterDirection.Input));
            Ds = new DataSet();
            RunProc("FindScoreByClassPaper", ddlparam, Ds);
            List<Score> score = new List<Score>();
            score = DataSetToScore(Ds);
            return score;
        }
        #endregion
    }
}
