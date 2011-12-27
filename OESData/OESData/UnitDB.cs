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
        public void AddUnit(string UnitName, int Unit, int CourseId)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@UnitName", SqlDbType.VarChar, 100, UnitName, ParameterDirection.Input));
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            try
            {
                RunProc("AddUnit", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //Description:	列出所有章节名
        public List<Unit> FindAllUnit()
        {
            List<Unit> UnitList = new List<Unit>();
            Ds = new DataSet();
            try { RunProc("FindAllUnit", null, Ds); }
            catch (Exception Ex) { throw Ex; }
            UnitList = DataSetToListUnit(Ds);
            return UnitList;
        }

        public DataSet FindAllUnit_DataSet()
        {
            List<Unit> UnitList = new List<Unit>();
            Ds = new DataSet();
            try { RunProc("FindAllUnit", null, Ds); }
            catch (Exception Ex) { throw Ex; }
            return Ds;
        }

        public List<Unit> FindUnitByCourseId(int CourseId)
        {
            List<Unit> res = new List<Unit>();
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            try
            {
                RunProc("FindUnitByCourseId", dp, Ds);
                res = DataSetToListUnit(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

        public DataSet FindUnitByCourseId_DataSet(int CourseId)
        {
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            try
            {
                RunProc("FindUnitByCourseId", dp, Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Ds;
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
        public void UpdateUnit(int Unit, string UnitName, int CourseId)
        {
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@Unit", SqlDbType.Int, 0, Unit, ParameterDirection.Input));
            dp.Add(CreateParam("@UnitName", SqlDbType.VarChar, 50, UnitName, ParameterDirection.Input));
            dp.Add(CreateParam("@CourseId", SqlDbType.Int, 0, CourseId, ParameterDirection.Input));
            try
            {
                RunProc("UpdateUnit", dp);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Course> FindAllCourse()
        {
            List<Course> res = new List<Course>();
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            try
            {
                RunProc("FindAllCourse", dp, Ds);
                res = DataSetToListCourse(Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

        public DataSet FindAllCourse_DataSet()
        {
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            try
            {
                RunProc("FindAllCourse", dp, Ds);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Ds;
        }

        #endregion
    }
}
