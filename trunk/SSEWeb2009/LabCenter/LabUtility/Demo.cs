using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.LabUtility.GridDataUtility;
using LabCenter.LabUtility.EmailUtility;
using LabCenter.LabUtility.XmlBase;
using LabCenter.LabUtility.TimeUtility;

namespace LabCenter.LabUtility
{
    class Demo
    {
        /// <summary>
        /// 使用方法
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ////using LabCenter.LabUtility.GridDataUtility;
            ////首先声明一个网格文件控制类,模版类要指定要将文件中数据导入的类
            ////之前已说过这个类要满足两个条件，否则会报错的，具体条件见Person类
            //ExcelDataCtrl<Person> edc = new ExcelDataCtrl<Person>();
            ////调用FileToClass函数，第一个参数为网格文件的路径
            //List<Person> personlist = edc.FileToClass("../../aaa.xls");

            ////using LabCenter.LabUtility.EmailUtility;
            ////首先初始化一个Smtp邮差实体
            //SmtpMailer sm = new SmtpMailer();
            ////然后可以通过配置文件配置之
            //sm.SenderConfig("../../MailConfig.xml");
            ////再填入邮件的接受者，主题，内容
            //sm.Receiver = "realwronger@gmail.com";
            //sm.Subject = "测试ing";
            //sm.Body = "没什么";
            ////最后就Send
            //if (!sm.Send())
            //{
            //    //如果失败，通过LastError属性查看错误信息
            //    string error = sm.LastError;
            //}

            ////TermList terms = new TermList(@"c:\terms.txt");
            ////terms.Terms.Add("200601");
            ////terms.Terms.Add("200602");
            ////terms.Serialize();
            //TermList terms = new TermList(@"c:\terms.txt");
            //TermList ret=(TermList)terms.Deserialize();

            DateTime dt = new DateTime(2008, 2,7,9,25,14);
            DateTime dtcompare = new DateTime(2009, 4, 10, 13, 30, 20);
            //Console.WriteLine(TimeTeller.Diff(dt,dtcompare,10));
            DateTime dtcompare2 = new DateTime(2008, 2, 7, 10, 55, 0);
            Console.WriteLine(TimeTeller.DiffHour(dt, dtcompare2));
        }
    }
}
