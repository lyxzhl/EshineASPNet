using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

/// <summary>
/// upImage 对上传文件以及上传图片的操作（以图片为主、包含创建小图、创建名称等）
/// 作者：SK
/// </summary>
public class upImage : System.Web.UI.Page 
{
    /// <summary>
    /// 保存小图
    /// </summary>
    /// <param name="savePath">保存小图的完整路径</param>
    /// <param name="w">小图宽度</param>
    /// <param name="h">小图高度</param>
    /// <param name="Title">画在图上的水印文字</param>
    /// <param name="fontsize">文字的大小</param>
    /// <param name="File">上传文件的File控件</param>
    public void SaveSmallImg(string savePath, int w, int h, string Title,int fontsize,HtmlInputFile File)
    {
        SaveSmallImg( savePath,  w,  h,  Title,  fontsize, File.Value);
    }
    /// <summary>
    /// 保存小图
    /// </summary>
    /// <param name="savePath">保存小图的完整路径</param>
    /// <param name="w">小图宽度</param>
    /// <param name="h">小图高度</param>
    /// <param name="Title">画在图上的水印文字</param>
    /// <param name="fontsize">文字的大小</param>
    /// <param name="ImagePath">原图的完整路径</param>
    public void SaveSmallImg(string savePath, int w, int h, string Title, int fontsize, string ImagePath)
    {
        Bitmap Img = new Bitmap(ImagePath);
        Bitmap bit = new Bitmap(w, h);
        Graphics gp = Graphics.FromImage(bit);
        gp.DrawImage(Img, new Rectangle(0, 0, w, h));

        gp.SmoothingMode = SmoothingMode.AntiAlias;

        gp.DrawString(Title, new Font("华文彩云", fontsize), Brushes.White, new PointF(10, bit.Height - fontsize - 15));

        bit.Save(savePath, ImageFormat.Jpeg);
    }
    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="savePath">保存图片的完整路径</param>
    /// <param name="File">上传图片File控件ID</param>
    public bool SaveUpFile(string savePath,HtmlInputFile File)
    {
        string path = File.Value;
        if (path.Length == 0)
            return false;
        string imgName = Path.GetFileName(path);
        HttpPostedFile hp = File.PostedFile;

        hp.SaveAs(savePath);
        return true;
    }
    public bool SaveUpFile1(string savePath, HtmlInputFile File)
    {
        string path = File.Value;
        if (path.Length == 0)
            return false;
        string imgName = Path.GetFileName(path);
        HttpPostedFile hp = File.PostedFile;

        hp.SaveAs(savePath);
        return true;
    }
    /// <summary>
    /// 获取文件名称
    /// </summary>
    /// <param name="File">File控件ID</param>
    /// <returns></returns>
    public string GetFileName(HtmlInputFile File)
    {
        string path = File.Value;
        return Path.GetFileName(path);
    }
    /// <summary>
    /// 获取不重复名称
    /// </summary>
    /// <param name="PIC">名称类型标识（比如图片“IMG”）</param>
    /// <returns></returns>
    public string GetFileName(string PIC)
    {
        string time = DateTime.Now.ToString("yyMMddHHmmss");
        return PIC + time;
    }
    /// <summary>
    /// 获取文件扩展名部分
    /// </summary>
    /// <param name="File">上传文件控件</param>
    /// <returns></returns>
    public string GetExtension(HtmlInputFile File)
    {
        FileInfo f = new FileInfo(File.Value);
        return f.Extension;
    }
}
