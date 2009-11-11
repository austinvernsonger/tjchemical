using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.GridDataUtility
{
    /// <summary>
    /// ������PersonΪ����������ṹ�ļ�������ķ���
    /// Person һ���򵥵ļ�¼�˵���Ϣ��ʵ��
    /// ���Ҫʹ��Excel�ļ�������Ĺ��ܣ������ʵ��������Ҫ��
    /// 1.ʵ��IInputable�ӿڣ����ʵ�����������
    /// 2.��Ĭ�ϵ��޲ι��캯��
    /// </summary>
    public class Person : IInputable
    {
        public Person() { }
        public Person(int id, string name)
        {
            _id = id;
            _name = name;
        }
        private int _id;
        private string _name;
        /// <summary>
        /// ID����
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Inputable�ӿڵĺ������ֶ�
        /// </summary>
        /// <param name="columnindex">�����ļ�������������0��ʼ</param>
        /// <param name="filedata">��Ӧ�е����ݵ��ַ�����ʽ���������õ����������</param>
        /// <returns>�����������Ҫ���������뷵��false</returns>
        bool IInputable.ColumnBind(int columnindex, string filedata)
        {
            if (0 == columnindex)
            {
                //����0�а󶨵�Person���id�����ϣ��������string���ͣ�������ת��
                //���ת��ʧ�ܵĻ����Է���false
                _id = Convert.ToInt32(filedata);
            }
            else if (1 == columnindex)
            {
                //����1�а󶨵�Person���name������
                _name = filedata;
            }
            else
            {
                //��������Ҫ�������������Է���false
                return false;
            }
            //����󶨳ɹ�����true
            return true;
        }
    }
}
