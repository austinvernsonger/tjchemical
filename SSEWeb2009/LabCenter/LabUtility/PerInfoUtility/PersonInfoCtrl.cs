using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.LabUtility.PublicUtility;

namespace LabCenter.LabUtility.PerInfoUtility
{
    public class PersonInfoCtrl
    {
        /// <summary>
        /// 通过工号或学号获取姓名的函数
        /// </summary>
        /// <param name="id">
        /// 工号或学号
        /// </param>
        /// <returns>
        /// 如果工号或学号存在，则返回姓名
        /// 如果账号不存在返回null
        /// </returns>
        public static string GetNameByID(string id)
        {
            return Account.Name(id);
        }
    }
}
