using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for GradeManager
/// </summary>
namespace AlumnusRecord
{
    public class GradeManager
    {
        private string m_GradeInfoPath = "";
        private string m_ImageLocation = "";

        public string GradeInfoPath
        {
            get { return m_GradeInfoPath; }
            set { m_GradeInfoPath = value; }
        }

        public string ImageLocation
        {
            get { return m_ImageLocation; }
            set { m_ImageLocation = value; }
        }

        public GradeManager()
        {
            //
            // TODO: Add constructor logic here
            //
            m_GradeInfoPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/gradeinfo.xml");
            m_ImageLocation = "~/GradeImage";
        }

        /// <summary>
        /// 列举硕士/学士的所有毕业年级
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public List<Grade> GetGrade(int degree)
        {
            string strDegree = ParseDegreeToStr(degree);

            if (strDegree == null)
                return null;

            List<Grade> grades = new List<Grade>();

            using (XmlReader reader = XmlReader.Create(m_GradeInfoPath))
            {
                reader.ReadToFollowing("grade");
                do
                {
                    if (reader.GetAttribute("graduatingType") == strDegree)
                    {
                        Grade grade = new Grade();
                        grade.Degree = degree;
                        grade.GradYear = reader.GetAttribute("graduatingYear").Trim();
                        grade.GradImageLocation = reader.GetAttribute("graduatingImage");

                        grades.Add(grade);
                    }
                } while (reader.ReadToNextSibling("grade"));
            }

            return grades;
        }

        /// <summary>
        /// 得到某一级硕士/本科的信息
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="gradYear"></param>
        /// <returns></returns>
        public Grade GetGrade(int degree, string gradYear)
        {
            string strDegree = ParseDegreeToStr(degree);

            if (strDegree == null)
                return null;

            Grade grade = null;

            using (XmlReader reader = XmlReader.Create(m_GradeInfoPath))
            {
                reader.ReadToFollowing("grade");
                do
                {
                    if (reader.GetAttribute("graduatingType") == strDegree && reader.GetAttribute("graduatingYear") == gradYear)
                    {
                        grade = new Grade();
                        grade.Degree = degree;
                        grade.GradYear = reader.GetAttribute("graduatingYear").Trim();
                        grade.GradImageLocation = reader.GetAttribute("graduatingImage");

                        break;
                    }
                } while (reader.ReadToNextSibling("grade"));
            }

            return grade;
        }

        /// <summary>
        /// 判断是否存在硕士/学士的某一级
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="gradYear"></param>
        /// <returns></returns>
        public bool Exists(int degree, string gradYear)
        {
            string strDegree = ParseDegreeToStr(degree);
            if (strDegree == null)
                return false;

            using (XmlReader reader = XmlReader.Create(m_GradeInfoPath))
            {
                reader.ReadToFollowing("grade");
                do
                {
                    if (reader.GetAttribute("graduatingYear") == gradYear && reader.GetAttribute("graduatingType") == strDegree)
                        return true;
                } while (reader.ReadToNextSibling("grade"));

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>如存在该年级的本或研，则返回false</returns>
        public bool AddGrade(Grade grade)
        {
            string strDegree = ParseDegreeToStr(grade.Degree);

            if (Exists(grade.Degree, grade.GradYear))
                return false;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(m_GradeInfoPath);
                XmlNode gradesNode = xmlDoc.SelectSingleNode(@"/grades");
                XmlElement newGradeNode = xmlDoc.CreateElement("grade");

                newGradeNode.SetAttribute("graduatingYear", grade.GradYear);
                newGradeNode.SetAttribute("graduatingType", strDegree);
                newGradeNode.SetAttribute("graduatingImage", grade.GradImageLocation);

                gradesNode.AppendChild(newGradeNode);

                xmlDoc.Save(m_GradeInfoPath);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 修改图片路径
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public bool UpdateGradeImage(FileUpload InputFile, Grade grade)
        {
            string strDegree = ParseDegreeToStr(grade.Degree);

            string oldFileAbsolutePath = System.Web.HttpContext.Current.Server.MapPath(grade.GradImageLocation);

            File.Delete(oldFileAbsolutePath);

            string newFileRelativePath = "";

            if (UploadGradeImage(InputFile, strDegree, grade.GradYear, null, ref newFileRelativePath))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(m_GradeInfoPath);

                    string XPathCriteria = String.Format(@"/grades/grade[@graduatingYear='{0}'][@graduatingType='{1}']", grade.GradYear, strDegree);

                    XmlNode node = xmlDoc.SelectSingleNode(XPathCriteria);
                    if (node == null)
                    {
                        return false;
                    }
                    else
                    {
                        node.Attributes["graduatingImage"].Value = newFileRelativePath;
                    }

                    xmlDoc.Save(m_GradeInfoPath);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 上传班级照
        /// </summary>
        /// <param name="fullPath">要上传的文件绝对路径</param>
        /// <param name="folderPath">照片文件夹相对路径</param>
        /// <returns>返回文件的相对路径（由于folderPath文件夹下有可能存在与fullPath重名的文件，故有可能更改文件名）</returns>
        public bool UploadGradeImage(FileUpload InputFile, string degree, string gradyear, string folderPath, ref string newFileRelativePath)
        {
            //采用默认图片存放路径
            if (folderPath == null || folderPath.Trim() == "")
                folderPath = m_ImageLocation;

            string fullPath = InputFile.FileName;
            string imageExtension = Path.GetExtension(fullPath);
            string imageName = gradyear + degree;

            //得到绝对路径名
            string phyPath = System.Web.HttpContext.Current.Server.MapPath(folderPath);

            //如存在相同文件名，则采用“文件名(2).jpg”命名方式
            if (File.Exists(phyPath + @"/" + imageName + imageExtension))
            {
                int count = 2;
                while (File.Exists(phyPath + @"/" + imageName + "(" + count.ToString() + ")" + imageExtension))
                    count++;
                imageName = imageName + "(" + count.ToString() + ")";
            }
            imageName += imageExtension;

            newFileRelativePath = folderPath + @"/" + imageName;
            string newFileAbsolutePath = System.Web.HttpContext.Current.Server.MapPath(newFileRelativePath);

            if (UploadGradeImage(InputFile, newFileAbsolutePath, folderPath))
                return true;
            else
                return false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InputFile"></param>
        /// <param name="savedFilePath"></param>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public bool UploadGradeImage(FileUpload InputFile, string savedFilePath, string folderPath)
        {
            //采用默认图片存放路径
            if (folderPath == null || folderPath.Trim() == "")
                folderPath = m_ImageLocation;

            //如不存在folderPath，则创建该目录
            string phyPath = System.Web.HttpContext.Current.Server.MapPath(folderPath);
            DirectoryInfo upDir = new DirectoryInfo(folderPath);
            if (!upDir.Exists)
            {
                upDir.Create();
            }

            try
            {
                InputFile.SaveAs(savedFilePath);
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 用int表示degree，转换为“本科”/“硕士”
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        private string ParseDegreeToStr(int degree)
        {
            string strDegree = null;

            switch (degree)
            {
                case 0:
                    strDegree = "本科";
                    break;

                case 1:
                    strDegree = "硕士";
                    break;
            }

            return strDegree;
        }
    }
}