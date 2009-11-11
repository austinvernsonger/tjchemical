using System;
using System.Collections.Generic;
using System.Text;
using Report.Descriptor;
using Report.ReportException;
using System.Collections;


namespace Report.Adapter
{
    public class AdapterFactory
    {
        #region Singleton
        //to make this Factory a singleton
        private AdapterFactory()
        {
            ControlAdapterHash = new Hashtable();
            ControlAdapterHash[ItemType.REPORT] = new ReportControlAdapter();
            ControlAdapterHash[ItemType.TEXT] = new TextControlAdapter();
            ControlAdapterHash[ItemType.SINGLESELECT] = new SingleSelectionControlAdapter();
            ControlAdapterHash[ItemType.RICHTEXT] = new RichTextControlAdapter();
            ControlAdapterHash[ItemType.STUDENTID] = new StudentIdControlAdapter();
            ControlAdapterHash[ItemType.ADMINCHECK] = new AdminCheckControlAdapter();

        }
        private AdapterFactory(AdapterFactory other)
        {
        }
        static public AdapterFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdapterFactory();
                }
                return instance;
            }
        }
        private static AdapterFactory instance; 
        #endregion


        public IControlAdapter GetAdapter(ItemType type)
        {
            return (ControlAdapterHash[type] as IControlAdapter).Clone();
        }

        public void SetAdapter(ItemType type, IControlAdapter adapter)
        {
            ControlAdapterHash[type] = adapter;
        }

        /// <summary>
        /// 保存控件适配器的哈希
        /// </summary>
        Hashtable ControlAdapterHash;
    }


}
