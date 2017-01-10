using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
/// <summary>
/// GetPowerPage 此cs文件为权限设置里的附加文件（获取所有管理目录里的页面需以树型控件显示）
/// 未完，有待续写
/// 作者：SK
/// </summary>
public class GetPowerPage : System.Web.UI.Page
{
    /// <summary>
    /// 将管理页面的根目录给Fpath（比如:"~/admin"）
    /// </summary>
    public static readonly string Fpath = ConfigurationManager.AppSettings["admin"];
    /// <summary>
    /// 创建一个节点
    /// </summary>
    /// <returns></returns>
    public TreeNode CreateNode()
    {
        TreeNode node = new TreeNode(Path.GetFileName(Fpath),"");
        GetPages(node, Server.MapPath(Fpath));
        GetDirs(node, Server.MapPath(Fpath));
        return node;
    }
    /// <summary>
    /// 获取指定路径下的所有目录并将目录添加到指定节点里
    /// </summary>
    /// <param name="node">指定被添加的节点</param>
    /// <param name="path">指定路径</param>
    private void GetDirs(TreeNode node, string path)
    {
        string[] dirs = Directory.GetDirectories(path);
        foreach (string dir in dirs)
        {
            TreeNode nd = new TreeNode(Path.GetFileName(dir),"");

            node.ChildNodes.Add(nd);
            GetPages(nd, dir);
            GetDirs(nd, dir);
        }
    }
    /// <summary>
    /// 获取所有指定路径下的aspx页面并将页面标题添加到指定节点里
    /// </summary>
    /// <param name="node">被添加的节点</param>
    /// <param name="path">指定路径</param>
    private void GetPages(TreeNode node, string path)
    {
        string[] pages = Directory.GetFiles(path);
        foreach (string page in pages)
        {
            if (page.EndsWith(".aspx"))
            {
                TreeNode nd = new TreeNode(Path.GetFileName(page), page.Substring(page.IndexOf("Web") + 10));
                node.ChildNodes.Add(nd);
            }
        }
    }
    public void GetDirs(ListBox list, string path)
    {
        string[] dirs = Directory.GetDirectories(path);
        foreach (string dir in dirs)
        {
            GetPages(list, dir);
            GetDirs(list, dir);
        }
    }
    private void GetPages(ListBox list, string path)
    {
        string[] pages = Directory.GetFiles(path);
        foreach (string page in pages)
        {
            if (page.EndsWith(".aspx"))
            {
                ListItem li=new ListItem (Path.GetFileName(page),page);
                list.Items.Add(li);
            }
        }
    }
}
