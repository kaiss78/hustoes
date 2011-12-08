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
        #region 班级信息管理

        //-- Description:   添加班级 输入老师教工号
        public void AddClass(string dept, string className, string teacherUserName)
        {
            SqlParameter[] dp = new SqlParameter[3];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            dp[2] = CreateParam("@TeacherUserName", SqlDbType.VarChar, 50, teacherUserName, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddClass", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 3; i++)
                cmd.Parameters.Add(dp[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }

        //-- Description:   批量导入班级时的添加单个班级
        public void AddClassByClassImport(string dept, string className, string teacherUserName)
        {
            SqlParameter[] dp = new SqlParameter[3];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            dp[2] = CreateParam("@UserName", SqlDbType.VarChar, 50, teacherUserName, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddManyClass", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 3; i++)
                cmd.Parameters.Add(dp[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }


        //-- Description:   批量导入班级
        public void AddManyClasses(List<string[]> value)
        {
            SqlTransaction tx = sqlcon.BeginTransaction();
            for (int i = 0; i < value.Count; i++)
            {
                string dept = value[i][0].ToString();
                string className = value[i][1].ToString();
                string userName = value[i][2].ToString();
                AddClassByClassImport(dept, className, userName);
            }
            tx.Commit();
        }



        //-- Description:   导入学生时添加的班级
        public string AddClassByImport(string dept, string className)
        {
            string res = "";                //返回ClassId
            Ds = new DataSet();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddClassByImport", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 2; i++)
                cmd.Parameters.Add(dp[i]);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            try
            {
                Da.Fill(Ds);
                DataTable dt = Ds.Tables[0];
                res = dt.Rows[0][0].ToString();
            }
            catch (Exception Ex) { throw Ex; }
            return res;
        }

        //-- Description:   删除班级信息
        public void DeleteClass(string classId)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@ClassId", SqlDbType.VarChar, 50, classId, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("DeleteClass", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(dp[0]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }

        //-- Description:   删除多个班级
        public void DeleteManyClass(List<String> list)
        {
            try
            {
                SqlTransaction tx = sqlcon.BeginTransaction();
                for (int i = 0; i < list.Count; i++)
                    DeleteClass(list[i]);
                tx.Commit();
            }
            catch (Exception e) { throw e; }
        }

        //-- Description:   修改班级信息
        public void UpdateClass(string classId, string dept, string className, string teacherUserName)
        {
            SqlParameter[] dp = new SqlParameter[4];
            dp[0] = CreateParam("@ClassId", SqlDbType.VarChar, 50, classId, ParameterDirection.Input);
            dp[1] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[2] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            dp[3] = CreateParam("@TeacherUserName", SqlDbType.VarChar, 50, teacherUserName, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("UpdateClass", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 4; i++)
                cmd.Parameters.Add(dp[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }

        //-- Description:   超级管理员查询所有班级信息
        public List<Classes> FindAllClass()
        {
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindAllClass", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   超级管理员按学院查找班级
        public List<Classes> FindClassByDept(string dept)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByDept", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp[0]);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   普通教师按学院查找班级
        public List<Classes> FindClassByDeptWithTeacher(string dept, string userName)
        {
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByDeptWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   超级管理员按班级名称查找班级
        public List<Classes> FindClassByClassName(string className)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByClassName", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp[0]);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   普通教师按班级名称查找班级
        public List<Classes> FindClassByClassNameWithTeacher(string className, string userName)
        {
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByClassNameWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:   按教工号查找班级
        public List<Classes> FindClassByUserName(string userName)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            Ds = new DataSet();
            List<Classes> classList = new List<Classes>();
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindClassByUserName", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp[0]);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            classList = DataSetToClass(Ds);
            return classList;
        }

        //-- Description:	查找某个学院下的所有班级
        public List<string> FindClassNameOfDept(string Dept)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@Dept", SqlDbType.VarChar, 50, Dept, ParameterDirection.Input));

            Ds = new DataSet();
            List<string> classStringList = new List<string>();

            RunProc("FindClassNameOfDept", ddlparam, Ds);
            classStringList = DataSetToclassStringList(Ds);
            return classStringList;
        }

        //-- Description:   查找某个学院下某个老师的所有班级
        public List<String> FindClassNameOfDeptWithTeacher(string dept, string userName)
        {
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            Ds = new DataSet();
            List<string> res = new List<string>();
            SqlCommand Cmd = new SqlCommand("FindClassNameOfDeptWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            res = DataSetToclassStringList(Ds);
            return res;
        }

        //-- Description:	查找所有的学院
        public List<string> FindAllDept()
        {
            Ds = new DataSet();
            List<string> deptStringList = new List<string>();

            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindAllDept", sqlcon);
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
            deptStringList = DataSetToDeptStringList(Ds);
            return deptStringList;
        }

        //-- Description:   查找某个老师所教班级所在的所有学院
        public List<String> FindAllDeptWithTeacher(string userName)
        {
            Ds = new DataSet();
            List<string> res = new List<string>();
            SqlParameter dp = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindAllDeptWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            res = DataSetToDeptStringList(Ds);
            return res;
        }

        #endregion

        #region 学生信息管理

        //-- Description:   验证学生信息是否正确
        public bool ValidateStudentInfo(string studentId, string studentName, string password)
        {
            DataSet Ds = new DataSet();
            List<SqlParameter> dp = new List<SqlParameter>();
            dp.Add(CreateParam("@StudentId", SqlDbType.VarChar, 50, studentId, ParameterDirection.Input));
            dp.Add(CreateParam("@StudentName", SqlDbType.VarChar, 50, studentName, ParameterDirection.Input));
            dp.Add(CreateParam("@Password", SqlDbType.VarChar, 50, password, ParameterDirection.Input));
            try { RunProc("ValidateStudentInfo", dp, Ds); }
            catch { throw; }
            return Ds.Tables[0].Rows.Count > 0;
        }

        //-- Description:   添加学生 输入学院、班级信息.
        public void AddStudent(string id, string name, string dept, string className, string password)
        {
            SqlParameter[] ddlparam = new SqlParameter[5];
            ddlparam[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddNewStudent", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 5; i++)
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

        //-- Description:   批量导入时，导入单个学生的方法
        public void AddStudentByImport(string id, string name, string classId, string password)
        {
            SqlParameter[] ddlparam = new SqlParameter[4];
            ddlparam[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@ClassId", SqlDbType.VarChar, 50, classId, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@Password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("AddStudent", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 4; i++)
                cmd.Parameters.Add(ddlparam[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException e) { throw e; }
        }

        //-- Description:   批量导入学生
        public void AddManyStudents(string dept, string className, List<string[]> value)
        {
            SqlTransaction tx = sqlcon.BeginTransaction();
            string classId = AddClassByImport(dept, className);
            for (int i = 0; i < value.Count; i++)
            {
                string name = value[i][0].ToString();
                string id = value[i][1].ToString();
                string pw = value[i][2].ToString();
                AddStudentByImport(id, name, classId, pw);
            }
            tx.Commit();
        }

        //-- Description:   删除学生
        public void DeleteStudent(string id)
        {
            SqlParameter[] dp = new SqlParameter[1];
            dp[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("DeleteStudentByStudentId", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(dp[0]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException Ex) { throw Ex; }
        }

        //-- Description:   删除多个学生
        public void DeleteManyStudent(List<String> list)
        {
            try
            {
                SqlTransaction tx = sqlcon.BeginTransaction();
                for (int i = 0; i < list.Count; i++)
                    DeleteStudent(list[i]);
                tx.Commit();
            }
            catch (Exception e) { throw e; }
        }

        //-- Description:   修改学生
        public void UpdateStudent(string id, string name, string dept, string className, string password, string oriId)
        {
            SqlParameter[] ddlparam = new SqlParameter[6];
            ddlparam[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            ddlparam[1] = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            ddlparam[2] = CreateParam("@Dept", SqlDbType.VarChar, 50, dept, ParameterDirection.Input);
            ddlparam[3] = CreateParam("@ClassName", SqlDbType.VarChar, 50, className, ParameterDirection.Input);
            ddlparam[4] = CreateParam("@Password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);
            ddlparam[5] = CreateParam("@OriStudentId", SqlDbType.VarChar, 50, oriId, ParameterDirection.Input);
            DataBind();
            SqlCommand cmd = new SqlCommand("UpdateStudent", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < 6; i++)
                cmd.Parameters.Add(ddlparam[i]);
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException e) { throw e; }
        }

        //-- Description:	超级管理员列出所有学生
        public List<Student> FindAllStudent()
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();

            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindAllStudent", sqlcon);
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
            studentList = DataSetToListStudent(Ds);
            return studentList;

        }
        //-- Description:	普通教师查看自己所教院系的学生信息
        public List<Student> FindStudentByUserName(string userName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter dp = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByUserName", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            studentList = DataSetToListStudent(Ds);
            return studentList;

        }
        //-- Description:	按院系班级信息查询学生
        public List<Student> FindStudentByClass(string Dept, string ClassName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, Dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, ClassName, ParameterDirection.Input);
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByClass", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }

        //-- Description:	 普通教师按院系班级信息查询学生
        public List<Student> FindStudentByClassWithTeacher(string Dept, string ClassName, string userName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter[] dp = new SqlParameter[3];
            dp[0] = CreateParam("@Dept", SqlDbType.VarChar, 50, Dept, ParameterDirection.Input);
            dp[1] = CreateParam("@ClassName", SqlDbType.VarChar, 50, ClassName, ParameterDirection.Input);
            dp[2] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByClassWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }



        //-- Description:	按学生姓名查询学生信息
        public List<Student> FindStudentByName(string name)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter dp = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByName", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }

        //-- Description:   普通教师按学生姓名查询学生信息
        public List<Student> FindStudentByNameWithTeacher(string name, string userName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@StudentName", SqlDbType.VarChar, 50, name, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByNameWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }

        //-- Description:	按学号查询学生信息
        public List<Student> FindStudentByStudentId(string StudentId)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter dp = CreateParam("@StudentId", SqlDbType.VarChar, 50, StudentId, ParameterDirection.Input);
            //RunProc("FindChoice", null, Ds);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByStudentId", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }

        //-- Description:   普通教师按学号查询学生信息
        public List<Student> FindStudentByStudentIdWithTeacher(string id, string userName)
        {
            Ds = new DataSet();
            List<Student> studentList = new List<Student>();
            SqlParameter[] dp = new SqlParameter[2];
            dp[0] = CreateParam("@StudentId", SqlDbType.VarChar, 50, id, ParameterDirection.Input);
            dp[1] = CreateParam("@UserName", SqlDbType.VarChar, 50, userName, ParameterDirection.Input);
            DataBind();
            SqlCommand Cmd = new SqlCommand("FindStudentByStudentIdWithTeacher", sqlcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddRange(dp);
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            try { Da.Fill(Ds); }
            catch (Exception Ex) { throw Ex; }
            studentList = DataSetToListStudent(Ds);
            return studentList;
        }

        //-- Description:	验证学生可否参加考试,返回false 表示验证不通过，true，验证通过
        public bool CheckStudent(string StudentName, string StudentId, string Password)
        {
            List<SqlParameter> ddlparam = new List<SqlParameter>();
            ddlparam.Add(CreateParam("@StudentName", SqlDbType.VarChar, 50, StudentName, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@StudentId", SqlDbType.VarChar, 50, StudentId, ParameterDirection.Input));
            ddlparam.Add(CreateParam("@Password", SqlDbType.VarChar, 50, Password, ParameterDirection.Input));

            Ds = new DataSet();
            RunProc("CheckStudent", ddlparam, Ds);

            DataTable p_Data = Ds.Tables[0];
            if (p_Data.Columns.Count < 1)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
