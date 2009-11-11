using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;


/// <summary>
/// 页面：SysMgr_UploadPics - 上传图片
/// 作者：Constantine
/// 最近一次修改时间：2009-6-24
/// </summary>
public partial class SysMgr_UploadPics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
    }

    /// <summary>
    /// 确定按钮事件，上传文件
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (picUpload.HasFile)
        {
            //得到文件扩展名
            String fileExt = Path.GetExtension(picUpload.FileName);
            //检查文件类型
            if (CheckFileType(fileExt))
            {
                DateTime today = DateTime.Now;
                String dirPath = today.Year.ToString() + "Y";
                String dirDetailPath = dirPath + "/" + ((today.Month < 10) ? "0" + today.Month.ToString() : today.Month.ToString()) + "M";
                String serDirPath = Server.MapPath("~/Files/Upload/" + dirPath);
                String serDetailDirPath = Server.MapPath("~/Files/Upload/" + dirDetailPath);
                //创建以年为名字的目录，名字为"20xxY"
                if (!Directory.Exists(serDirPath))
                {
                    Directory.CreateDirectory(serDirPath);
                }
                //创建以月为名字的目录，名字为"XXM"，并且为年目录的子目录
                if (!Directory.Exists(serDetailDirPath))
                {
                    Directory.CreateDirectory(serDetailDirPath);
                }

                String postedName = picUpload.PostedFile.FileName;
                FileInfo fileInfo = new FileInfo(postedName);

                String serFileName = fileInfo.Name;
                //原图路径
                String serFilePath = serDetailDirPath + "/" +serFileName;
                //缩略图路径，以"t_"为前缀
                String serThuFilePath = serDetailDirPath + "/t_" +serFileName;
                //文件不存在，则创建文件
                if (!File.Exists(serFilePath))
                {
                    try
                    {
                        picUpload.SaveAs(serFilePath);
                        //制作缩略图
                        MakeThumbnailPic(serFilePath, serThuFilePath, 145, 94);
                        System.Drawing.Image orgImg = System.Drawing.Image.FromFile(serFilePath);
                        this.tbWidth.Text = orgImg.Width.ToString()+"px";
                        this.tbHeight.Text = orgImg.Height.ToString()+"px";
                        this.lbErr.Text = "上传图片" + serFileName + "成功！图片大小：" + picUpload.PostedFile.ContentLength + "B";
                        this.ImageShow.ImageUrl = "~/Files/Upload/" + dirDetailPath + "/t_" + serFileName;
                        orgImg.Dispose();
                    }
                    catch (System.Exception ex)
                    {
                        this.lbErr.Text = "上传图片失败，失败原因：" + ex.Message;
                    }
                    
                }
                else
                {
                    this.lbErr.Text = "图片" + serFileName + "已存在！";
                }
            }
            else //不合符就报错
            {
                this.lbErr.Text = "错误：文件类型不正确！请选择正确的图片类型！";
            }
        }
    }

    /// <summary>
    /// 检测文件类型合法性
    /// </summary>
    /// <param name="type">String - 文件类型</param>
    /// <returns>true - 合法，false - 不合法</returns>
    private Boolean CheckFileType(String type)
    {
        switch (type.ToLower())
        {
            case ".gif": return true;
            case ".jpg": return true;
            case ".jpeg": return true;
            case ".bmp": return true;
            case ".png": return true;
            default: return false;
        }
    }

    /// <summary>
    /// 制作缩略图
    /// </summary>
    /// <param name="OrgPicFile">原图路径</param>
    /// <param name="ThuPicFile">要制作的缩略图路径</param>
    /// <param name="ToWidth">缩略图宽度</param>
    /// <param name="ToHeight">缩略图高度</param>
    private void MakeThumbnailPic(String OrgPicFile, String ThuPicFile,int ToWidth,int ToHeight)
    {
        System.Drawing.Image imgOrg = System.Drawing.Image.FromFile(OrgPicFile);

        int toWidth = ToWidth, toHeight = ToHeight;
        int x = 0, y = 0;
        int orgWidth = imgOrg.Width, orgHeight = imgOrg.Height;
        //根据长宽比例计算缩略图在原图的位置
        if ((double)imgOrg.Width / (double)imgOrg.Height > (double)toWidth / (double)toHeight)
        {
            orgHeight = imgOrg.Height;
            orgWidth = imgOrg.Height * toWidth / toHeight;
            y = 0;
            x = (imgOrg.Width - orgWidth) / 2;
        }
        else
        {
            orgWidth = imgOrg.Width;
            orgHeight = imgOrg.Width * toHeight / toWidth;
            x = 0;
            y = (imgOrg.Height - orgHeight) / 2;
        }

        System.Drawing.Image bmp = new Bitmap(toWidth, toHeight);
        Graphics g = Graphics.FromImage(bmp);
        //选择相关的插值算法和平滑模型
        g.InterpolationMode = InterpolationMode.High;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.Clear(Color.Transparent);
        //画上去了~
        g.DrawImage(imgOrg, new Rectangle(0, 0, toWidth, toHeight), new Rectangle(x, y, orgWidth, orgHeight),
            GraphicsUnit.Pixel);

        try
        {
            //保存为jpg
            bmp.Save(ThuPicFile, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            e.ToString();
            throw e;
        }
        finally
        {
            imgOrg.Dispose();
            bmp.Dispose();
            g.Dispose();
        }
    }
}
