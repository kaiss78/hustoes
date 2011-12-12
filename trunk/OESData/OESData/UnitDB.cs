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
        #region 章节管理

        public void ImportUnit(List<string[]> lst)
        { }

        //添加章节，UnitName具体的章节名字，例如“故障恢复”
        public void AddUnit(string UnitName, int Unit)
        {
            SqlParameter[] ddlparam = new SqlParameter[2];
            ddlparam[0] = CreateParam("@UnitName", SqlDbType.VarChar, 100, UnitName, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@Unit", SqlDbType.Int, 9, Unit, ParameterDirection.Input);

            DataBind();
            SqlCommand cmd = new SqlCommand("AddUnit", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 2; i++)
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

        //Description:	列出所有章节名
        public List<Unit> FindAllUnit()
        {
            List<Unit> UnitList = new List<Unit>();
            Ds = new DataSet();
            try { RunProc("FindAllUnit", null, Ds); }
            catch (Exception Ex) { throw Ex; }
            UnitList = DataSetToListString(Ds);
            return UnitList;
        }

        //Description:  删除某个章节
        public void DeleteUnit(int Unit)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 11, Unit, ParameterDirection.Input));
            SqlCommand cmd = CreateCmd("DeleteUnit", dp);
            try { cmd.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
        }

        //Description:  修改某个章节
        public void UpdateUnit(int Unit, string UnitName)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 11, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@UnitName", SqlDbType.VarChar, 50, UnitName, ParameterDirection.Input));
            SqlCommand cmd = CreateCmd("UpdateUnit", dp);
            try { cmd.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
        }

        #endregion
    }
}
