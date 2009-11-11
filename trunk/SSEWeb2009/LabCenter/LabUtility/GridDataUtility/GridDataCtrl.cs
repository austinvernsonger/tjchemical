using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.GridDataUtility
{
    public abstract class GridDataCtrl<T>
        where T:IInputable,new()
    {
        /// <summary>
        /// ��Sqlִ�н�������ļ�
        /// </summary>
        /// <param name="sql">sql���</param>
        /// <returns>�ɹ����</returns>
        public abstract bool SqlToFile(string sql,string datasource,string tofilepath);
        /// <summary>
        /// �ļ�������
        /// </summary>
        /// <param name="filepath">�ļ�·��</param>
        /// <returns>�༯��</returns>
        public abstract List<T> FileToClass(string filepath);

        int _datarowindex=1;
        /// <summary>
        /// ���ݿ�ʼ�е���0��ʼ�Ƶ�����
        /// </summary>
        public int DataRowIndex
        {
            get { return _datarowindex; }
            set { _datarowindex = value; }
        }
    }
}
