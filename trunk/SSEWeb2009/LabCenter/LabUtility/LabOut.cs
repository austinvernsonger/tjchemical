using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Authority;


namespace LabCenter.LabUtility
{
    class LabOut
    {
        /// <summary>
        ///提供给全局超超级管理员，添加实验中心超级管理员的函数
        /// </summary>
        /// <param name="id">
        /// 工号或学号
        /// </param>
        /// <returns>
        /// 是否设置成功
        /// 当已存在超级管理员或帐号不存在时返回false
        /// </returns>
        bool SetLabAdministrator(string id,string xmlfile)
        {
            AuthorityManage am = new AuthorityManage();
            if (am.HasSuper())
            {
                return false;
            }
            if (!am.AddSuper(id))
            {
                return false;
            }
            //am.ImportAuthorities(id, xmlfile);
            return true;
            
        }
    }
}
