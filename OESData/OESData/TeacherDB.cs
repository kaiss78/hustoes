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
        #region 教师信息管理

        //-- Description:	查找Teacher的所有信息，通过Teacher的LoginName
        public Teacher FindTeacherByLoginName(string UserName)
        {
            Teacher teacher = new Teacher();
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@UserName", SqlDbType.VarChar, 50, UserName, ParameterDirection.Input));
            Ds = new DataSet();
            RunProc("FindTeacherByLoginName", ddlparam, Ds);
            teacher = DataSetToTeacher(Ds);
            return teacher;
        }

        //-- Description:	增加教师信息
        public void AddTeacher(string TeacherName, string Password, int Permission, string UserName)
        {

            SqlParameter[] ddlparam = new SqlParameter[4];
            ddlparam[0] = CreateParam("@TeacherName", SqlDbType.VarChar, 50, TeacherName, ParameterDirection.Input);

            ddlparam[1] = CreateParam("@Password", SqlDbType.VarChar, 200, Password, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Permission", SqlDbType.Int, 2, Permission.ToString(), ParameterDirection.Input);
            ddlparam[3] = CreateParam("@UserName", SqlDbType.VarChar, 50, UserName, ParameterDirection.Input);

            DataBind();
            SqlCommand cmd = new SqlCommand("AddTeacher", sqlcon);
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

        //-- Description:	按照Id删除教师信息
        public void DeleteTeacherById(int Id)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input));
            DataBind();
            //RunProc("FindChoiceByUnit", ddlparam, Ds);
            SqlCommand Cmd = CreateCmd("DeleteTeacherById", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        //-- Description:   删除多个教师
        public void DeleteManyTeacher(List<int> list)
        {
            try
            {
                //SqlTransaction tx = sqlcon.BeginTransaction();
                for (int i = 0; i < list.Count; i++)
                    DeleteTeacherById(list[i]);
                //tx.Commit();
            }
            catch (Exception e) { throw e; }
        }

        //-- Description:	修改教师记录的信息
        public void UpdateTeacherById(int Id, string TeacherName, string Password, int Permission, string UserName)
        {

            List<SqlParameter> ddlparam = new List<SqlParameter>();

            ddlparam.Add(CreateParam("@TeacherName", SqlDbType.VarChar, 50, TeacherName, ParameterDirection.Input));

            ddlparam.Add(CreateParam("@Password", SqlDbType.VarChar, 200, Password, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Permission", SqlDbType.Int, 2, Permission.ToString(), ParameterDirection.Input));
            ddlparam.Add(CreateParam("@UserName", SqlDbType.VarChar, 50, UserName, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Id", SqlDbType.Int, 9, Id, ParameterDirection.Input));

            SqlCommand Cmd = CreateCmd("UpdateTeacherById", ddlparam);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (SqlException e)

            {
                throw e;
            }
        }
        //-- Description:	列出所有teacher信息
        public List<Teacher> FindTeacher()
        {
            Ds = new DataSet();
            List<Teacher> teacherList = new List<Teacher>();
            //RunProc("FindTeacher", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindTeacher", sqlcon);
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
            teacherList = DataSetToTeacherList(Ds);
            return teacherList;
        }

        #endregion
    }
}
