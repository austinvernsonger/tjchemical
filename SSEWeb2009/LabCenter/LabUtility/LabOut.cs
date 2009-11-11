using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Authority;


namespace LabCenter.LabUtility
{
    class LabOut
    {
        /// <summary>
        ///�ṩ��ȫ�ֳ���������Ա�����ʵ�����ĳ�������Ա�ĺ���
        /// </summary>
        /// <param name="id">
        /// ���Ż�ѧ��
        /// </param>
        /// <returns>
        /// �Ƿ����óɹ�
        /// ���Ѵ��ڳ�������Ա���ʺŲ�����ʱ����false
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
