using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.LabUtility.PublicUtility;

namespace LabCenter.LabUtility.PerInfoUtility
{
    public class PersonInfoCtrl
    {
        /// <summary>
        /// ͨ�����Ż�ѧ�Ż�ȡ�����ĺ���
        /// </summary>
        /// <param name="id">
        /// ���Ż�ѧ��
        /// </param>
        /// <returns>
        /// ������Ż�ѧ�Ŵ��ڣ��򷵻�����
        /// ����˺Ų����ڷ���null
        /// </returns>
        public static string GetNameByID(string id)
        {
            return Account.Name(id);
        }
    }
}
