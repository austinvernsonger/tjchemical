using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
using System.Data;
using System.IO;
namespace SysCom
{
    public class MMTInformation
    {
        static public  DataTable GetActivityInfo()
        {
            Ops.OpBiQuery i = new Ops.OpBiQuery("Information", new Sql.SqlGetActivityInformation());
            i.Do();
            return i.Ds.Tables[0];
        }
        static public SysCom.MMTDelegate.PostEvent getevent()
        {
            SysCom.MMTDelegate.PostEvent p = WriteXML;
            return p;
        }
        static public void WriteXML(String id)
        {
            //SysCom.MMTStatic a = new SysCom.MMTStatic();
            DataTable dt = SysCom.MMTInformation.GetActivityInfo();
            StringBuilder xmlData = new StringBuilder();
            xmlData.AppendLine(@"<?xml version='1.0' encoding='UTF-8' ?>");
            xmlData.AppendLine(@"<root>");

            foreach (DataRow dr in dt.Rows)
            {
                String Title = dr["Title"].ToString();
                String StartTime = dr["StartTime"].ToString();
                String EndTime = dr["EndTime"].ToString();
                String Location = dr["Location"].ToString();
                String ID = dr["ID"].ToString();
                xmlData.Append((@"<Activity>"));
                xmlData.Append((@"<Title>" + Title.Trim() + "</Title>"));
                xmlData.Append((@"<StartTime>" + StartTime.Trim() + "</StartTime>"));
                xmlData.Append((@"<EndTime>" + EndTime.Trim() + "</EndTime>"));
                xmlData.Append((@"<Location>" + Location.Trim() + "</Location>"));
                xmlData.Append((@"<ID>" + ID.Trim() + "</ID>"));
                xmlData.Append((@"</Activity>"));
            }
            xmlData.AppendLine(@"</root>");
            FileStream MyFileStream;
            MyFileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "XmlData\\DefaultActivity.xml", FileMode.Open, FileAccess.Write, FileShare.Write);
            MyFileStream.SetLength(0);
            StreamWriter sw = new StreamWriter(MyFileStream, new System.Text.UTF8Encoding());
            sw.Write(xmlData);
            sw.Close();
        }
    }
}
