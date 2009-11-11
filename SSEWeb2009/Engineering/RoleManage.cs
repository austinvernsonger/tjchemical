using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SMBL.Interface.Database;
using System.Collections;

namespace Department.Engineering
{
    public class RoleManage
    {

        #region Member Variables

        private string _userID;
        private int _roleID;
        private string _name;

        #endregion

        #region Constructor

        public RoleManage()
        { }

        #endregion

        #region OtherFunctions Relative to Transaction 

        public bool AddUserAndRoleTran()
        {
            AddUser(_userID, _name);
            AddUserRole(_userID, _roleID);
            return true;
        }

        public bool DeleteUserAndRole()
        {
            DeleteRolesAoutUserID(_userID);
            DeleteUser(_userID);
            return true;
        }

        public bool AddSuperAdminForMSE()
        {
            string userID = "";
            DataSet ds = null;
            //判断该部门当前的超级管理员是否存在
            ds = GetCurrentSuperAdmin();
            if (ds.Tables[0].Rows.Count > 0)
            { 
                //该部门当前存在超级管理员
                userID = ds.Tables[0].Rows[0]["UseId"].ToString().Trim();
                //删除当前超级管理员所具有的权限
                DeleteRoleFunc(5);
                //删除该账号超级管理这个角色
                DeleteUserRole(5, userID);
            }
            int roleID = 0;
            //获取该账号在MSE所具有的角色
            ds = GetRolesSet(_userID);
            if (ds.Tables[0].Rows.Count > 0)
            { 
                //该账号在该部门有角色
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]) == 1)
                    { 
                        //该账号具有管理员角色
                        roleID = Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]);
                        break;
                    }
                }
                if (roleID != 0)
                {
                    //删除该账号所具有的管理员权限
                    DeleteRoleFunc(roleID);
                    //删除该账号所具有的管理员角色
                    DeleteUserRole(roleID, _userID);
                }
            }
            //判断该账号是否在MSE部门
            ds = GetUsersFromMSE(_userID);
            if (ds.Tables[0].Rows.Count == 0)
            {
                //该账号不在该部门
                //获取教师的姓名
                TeacherManage tMag = new TeacherManage();
                string teacherName = tMag.GetTeacherName(_userID);
                //将该用户添加在MSE部门
                AddUser(_userID, teacherName);
            }
            //将该用户的角色设置为超级管理员
            AddUserRole(_userID, 5);
            //获取超级管理员所具有的全部权限
            List<string> func = new List<string>();
            func = GetAllFuncAoutAdmin();
            if (func.Count > 0)
            {
                //添加超级管理员的权限
                for (int i = 0; i < func.Count; i++)
                {
                    AddRoleFunc(5, func[i]);
                }
            }
            return true;
        }

        #endregion

        #region GetFunctions

        /// <summary>
        /// 获取所有角色信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllRoles()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllRoles());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取MSE部门的所有教师用户
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllUsers()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllUsers());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取角色的名称
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public string GetRoleName(int roleID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetRoleName(roleID));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }

        /// <summary>
        /// // 返回除角色Student外的其他角色
        /// </summary>
        /// <returns></returns>
        public DataView GetAllRolesExceptForStudentRoleList()
        {
            DataSet ds = GetAllRoles();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "--请选择角色--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "RoleId<>4";
            return dv;
        }

        /// <summary>
        /// 返回除超级管理员角色以外的所有角色
        /// </summary>
        /// <returns></returns>
        public DataView GetAllRolesWithoutSuperAdm()
        {
            DataSet ds = GetAllRoles();
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "RoleId<>5";
            return dv;
        }

        /// <summary>
        /// 返回与该角色相对应的用户信息
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public DataSet GetUsersByRoleID(int roleID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetUsersByRoleID(roleID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取不是当前角色的所有教师信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetTeachersNotCurrentRole(int roleID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeachersNotCurrentRole(roleID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取当前用户所具有的角色
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetRolesSet(string userID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetRolesByUser(userID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据角色ID，返回相关的角色权限
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public DataSet GetRoleFunc(int roleID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetRoleFunc(roleID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 判断该用户是否属于MSE部门
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetUsersFromMSE(string userID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetUsersFromMSE(userID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取管理员所具有的全部权限
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllFuncAoutAdmin()
        {
            List<string> func = new List<string>();
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetAllFuncAoutAdmin());
            op.Do();
            DataSet ds = op.Ds;
            int num = ds.Tables[0].Rows.Count;
            if (num > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    func.Add(ds.Tables[0].Rows[i]["FuncID"].ToString().Trim());
                }
                return func;
            }
            return null;
        }

        /// <summary>
        /// 获取当前的超级管理员信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetCurrentSuperAdmin()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetCurrentSuperAdmin());
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 获取该角色所属用户的信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public DataSet GetUserAndRole(string userID, int roleID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetUserAndRole(userID, roleID));
            op.Do();
            return op.Ds;
        }

        #endregion

        #region AddFunctions

        /// <summary>
        /// 将用户添加进MSE部门
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddUser(string userID, string name)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddUser(userID, name));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 为该用户添加角色
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public bool AddUserRole(string userID, int roleID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddUserRole(userID, roleID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 为角色添加相关权限
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="FuncID"></param>
        /// <returns></returns>
        public bool AddRoleFunc(int roleID, string FuncID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddRoleFunc(roleID, FuncID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region UpdateFunctions

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool UpdateRoles(int roleID, string roleName)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateRoles(roleID, roleName));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateUser(string userID, string userName)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateUser(userID, userName));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion 

        #region DeleteFunctions

        /// <summary>
        /// 删除用户角色信息
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool DeleteUserRole(int roleID, string userID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteUserRole(roleID, userID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除该角色的相关权限
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public bool DeleteRoleFunc(int roleID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteRoleFunc(roleID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        public bool DeleteRolesAoutUserID(string userID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteRolesAoutUserID(userID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据用户ID，删除该用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool DeleteUser(string userID)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlDeleteUser(userID));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Transaction

        /// <summary>
        /// 通过事务处理删除用户角色
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool DeleteUserRoleByTran(string userID)
        {
            _userID = userID;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(DeleteUserAndRole));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过事务处理添加用户角色信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="name"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public bool AddUserRoleByTran(string userID, string name, int roleID)
        {
            _userID = userID;
            _name = name;
            _roleID = roleID;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddUserAndRoleTran));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过事务处理为该部门添加超级管理员
        /// </summary>
        /// <returns></returns>
        public bool AddSuperAdminForMSEByTran(string userID)
        {
            _userID = userID;
            OpEngineerTransaction op = new OpEngineerTransaction("Engineering", new delDoTransaction(AddSuperAdminForMSE));
            op.Do();
            if (op.Result == true)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
