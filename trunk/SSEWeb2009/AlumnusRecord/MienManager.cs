using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;


/// <summary>
/// An XML data object that lets us read/write from an XML source
/// used for the mien-management object data source.
/// </summary>
[DataObject(true)]
public abstract class MienXmlDataObject
{
    // the web site physical root
    private string _rootPath;
    private DataSet _ds;

    public MienXmlDataObject()
    {
    }

    public MienXmlDataObject(string rootPath)
    {
        _rootPath = rootPath;
    }

    private DataSet DataSet
    {
        get
        {
            if (_ds == null)
            {
                _ds = new DataSet();
                _ds.ReadXmlSchema(XsdFile);
                LoadData();
            }
            return _ds;
        }
    }

    private DataTable Table
    {
        get { return DataSet.Tables["Photos"]; }
    }

    /// <summary>
    /// Figures out the physical root of the website.
    /// </summary>
    protected string RootPath
    {
        get
        {
            if (_rootPath != null)
            {
                return _rootPath;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath);
            }
            else
            {
                throw new ApplicationException("Can't find server root path.");
            }
        }
    }

    protected abstract bool CanReadStream
    {
        get;
    }

    protected virtual bool CanWriteStream
    {
        get { return true; }
    }

    protected abstract Stream XmlStream
    {
        get;
    }


    private string XsdFile
    {
        get { return Path.Combine(RootPath, @"AlumnusRecord\Resources\News\Photos.xsd"); }
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataView Select()
    {
        Table.DefaultView.Sort = "Order";
        return Table.DefaultView;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public int Insert(string Src, string Name, int Order)
    {
        DataRow dr = Table.NewRow();

        dr["Src"] = Src;
        dr["Name"] = Name;
        dr["Order"] = Order;
        Table.Rows.Add(dr);
        SaveChanges();
        return 1;
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public virtual int Update(string Src, string Name, int Order, int Original_ItemID)
    {
        DataRow[] rows = Table.Select(String.Format("ItemID={0}", Original_ItemID));

        if (rows.Length > 0)
        {
            DataRow dr = rows[0];
            dr.BeginEdit();
            dr["Src"] = Src;
            if (Name == String.Empty)
            {
                dr["Name"] = null;
            }
            else
            {
                dr["Name"] = Name;
            }
            dr["Order"] = Order;
            dr.EndEdit();
            SaveChanges();
            return 1;
        }
        return 0;
    }

    protected virtual void LoadData()
    {
        if (CanReadStream)
        {
            _ds.ReadXml(XmlStream, XmlReadMode.IgnoreSchema);
        }
    }

    protected virtual void SaveChanges()
    {
        DataSet.AcceptChanges();
        if (CanWriteStream)
        {
            XmlStream.Flush();
            DataSet.WriteXml(XmlStream, XmlWriteMode.IgnoreSchema);
        }
        else
        {
            throw new ApplicationException("Can't write to XML stream.");
        }
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public virtual int Delete(int Original_ItemID)
    {
        DataRow[] rows = Table.Select(String.Format("ItemID={0}", Original_ItemID));

        if (rows.Length > 0)
        {
            Table.Rows.Remove(rows[0]);
            SaveChanges();
            return 1;
        }
        return 0;
    }
}

/// <summary>
/// A version of the data source that reads and writes from the local XML file.
/// </summary>
public class FileMienXmlDataObject : MienXmlDataObject
{
    private Stream _stream;

    protected override bool CanReadStream
    {
        get { return File.Exists(XmlFile); }
    }

    protected override Stream XmlStream
    {
        get
        {
            if (_stream == null)
            {
                _stream = new FileStream(XmlFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            return _stream;
        }
    }

    private string XmlFile
    {
        get { return Path.Combine(RootPath, @"AlumnusRecord\Resources\News\Photos.xml"); }
    }

    protected override void LoadData()
    {
        XmlStream.Seek(0, SeekOrigin.Begin);
        base.LoadData();
    }

    protected override void SaveChanges()
    {
        XmlStream.Position = 0;
        XmlStream.SetLength(0);
        base.SaveChanges();
        XmlStream.Flush();
    }
}
