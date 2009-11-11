using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using AlumnusRecord.Ops;
using AlumnusRecord.Sql;

/// <summary>
/// Summary description for Alumnus
/// </summary>

namespace AlumnusRecord
{
    public class Alumnus
    {
//        private string m_ConnString = "Data Source=10.60.43.9;Initial Catalog=SSE;User ID=sse_graduates;Passwordhelloworld";
        private string m_DbName = "Account";

        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set
            {
                if (value != null)
                    m_Name = value;
            }
        }

        private string m_StdNumber;
        public string StdNumber
        {
            get { return m_StdNumber; }
            set
            {
                if (value != null)
                    m_StdNumber = value;
            }
        }

        private string m_Password;
        public string Password
        {
            get { return m_Password; }
            set
            {
                if (value != null)
                    m_Password = value;
            }
        }

        private string m_BirthPlace;
        public string BirthPlace
        {
            get { return m_BirthPlace; }
            set { m_BirthPlace = value; }
        }

        private string m_GradPlace;
        public string GradPlace
        {
            get { return m_GradPlace; }
            set { m_GradPlace = value; }
        }

        private string m_GradYear;
        public string GradYear
        {
            get { return m_GradYear; }
            set { m_GradYear = value; }
        }

        //private byte[] image;

        private string m_WorkUnit;
        public string WorkUnit
        {
            get { return m_WorkUnit; }
            set { m_WorkUnit = value; }
        }

        private string m_WorkPlace;
        public string WorkPlace
        {
            get { return m_WorkPlace; }
            set { m_WorkPlace = value; }

        }

        private string m_Tel;
        public string Tel
        {
            get { return m_Tel; }
            set { m_Tel = value; }
        }

        private string m_Email;
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        private string m_Intro;
        public string Intro
        {
            get { return m_Intro; }
            set { m_Intro = value; }
        }

        private int m_Openstatus;
        public int Openstatus
        {
            get { return m_Openstatus; }
            set { m_Openstatus = value; }
        }

        private int m_Degree;
        public int Degree
        {
            get { return m_Degree; }
            set { m_Degree = value; }
        }

        public Alumnus()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet GetList(int degree, string gradYear)
        {
            OpAlumnusQuery i = new OpAlumnusQuery(m_DbName, new SqlAlumnusList(degree, gradYear));
            i.Do();
            return i.Ds;
        }

        public DataSet GetAlumnusNameID(int degree, string gradYear,int beginIndex, int count)
        {
            OpAlumnusQuery i = new OpAlumnusQuery(m_DbName, new SqlAlumnusNameID(degree, gradYear, beginIndex, count));
            i.Do();
            return i.Ds;
        }

        public int GetAlumnusCount(int degree, string gradYear)
        {
            OpAlumnusQuery i = new OpAlumnusQuery(m_DbName, new SqlAlumnusCount(degree, gradYear));
            i.Do();
            try
            {
                return Convert.ToInt32(i.Ds.Tables[0].Rows[0][0]);
            }
            catch
            {
                return -1; 
            }   
        }

        public DataSet GetAlumnus(string studentID)
        {
            OpAlumnusQuery i = new OpAlumnusQuery(m_DbName, new SqlGetAlumnus(studentID));
            i.Do();
            return i.Ds;
        }

        public String ErrorMsg = "";

        public Boolean UpdateAlumnus()
        {
            OpAlumnusExecute i = new OpAlumnusExecute(m_DbName, new SqlAlumnusUpdate(this));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                return false;
            }
            return true;
        }

        public byte[] GetAluImg(string id)
        {
            OpAlumnusQuery i = new OpAlumnusQuery(m_DbName, new SqlGetAlumnusImg(id));
            i.Do();
            return (byte[])i.Ds.Tables[0].Rows[0][0]; 
        }

        public Boolean UpdateAluImg(string id, byte[] imgLoc)
        {
            OpAlumnusExecute i = new OpAlumnusExecute(m_DbName, new SqlUpdateAluImg(id, imgLoc));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                return false;
            }
            return true; 
        }

        public List<string> GetStrs()
        {
            List<string> list = new List<string>();
            list.Add("NEWS Link Goes Here");
            list.Add("NEWS Link Goes Here");
            list.Add("NEWS Link Goes Here");
            list.Add("NEWS Link Goes Here");
            return list;
        }

        public void insert(int i )
        {
            OpAlumnusExecute ii = new OpAlumnusExecute(m_DbName, new SqlInsert(i.ToString()));
            if (!ii.Do())
            {
                ErrorMsg = ii.GetLastError();
                
            }
           
        }
    }
}