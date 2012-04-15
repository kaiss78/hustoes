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
        public int AddExam(string ExamName, string ExamDate)
        {
            int ExamID = -1;
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@ExamID", SqlDbType.Int, 0, ExamID, ParameterDirection.Output));
            dp.Add(CreateParam("@ExamName", SqlDbType.VarChar, 100, ExamName, ParameterDirection.Input));
            dp.Add(CreateParam("@ExamDate", SqlDbType.DateTime, 0, ExamDate, ParameterDirection.Input));
            try
            {
                RunProc("AddExam", dp);
                ExamID = Convert.ToInt32(dp[0].Value);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            return ExamID;
        }
    }
}
