using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using System.IO;

/// <summary>
/// 类：DirectoryViewer - 浏览服务器端文件夹
/// 作者：Constantine
/// 最近一次修改时间：2009-6-3
/// </summary>
public class DirectoryViewer
{
    public DirectoryViewer()
    {
       //Auto Generated - Constructor
    }

    /// <summary>
    /// 得到指定服务端路径的文件夹信息
    /// </summary>
    /// <param name="dirPath">服务端路径</param>
    /// <returns>Hashtable - 服务端文件夹集合</returns>
    public Hashtable GetDictionayInfo(String dirPath)
    {
        Hashtable dirInfo = new Hashtable();
        DirectoryInfo[] dirArray = new DirectoryInfo(dirPath).GetDirectories();

        foreach (DirectoryInfo dir in dirArray)
        {
            if (dir.Attributes == FileAttributes.Directory)
            {
                String filePath = dir.FullName;
                int endIndex = filePath.IndexOf("\\Files\\Upload\\");
                String pUrl = filePath.Remove(0, endIndex);
                dirInfo.Add(dir.Name, pUrl);
            }   
        }

        return dirInfo;
    }
}
