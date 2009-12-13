using System;
using System.Collections.Generic;
using System.Text;
using SunMkr.Kernel;
using SunMkr.Sys;
using SunMkr.Proc;
using SunMkr.Kernel.CfgElem;
using SunMkr;

namespace SunMkr.AS
{
    /// <summary>
    /// DBControl
    /// </summary>
    public class DBControl : IAS<IDBProvider>
    {
        static DBControl instance = new DBControl();
        Dictionary<DatabaseType, Type> TypeMap;
        Dictionary<Guid, object> m_locker = null;
        Dictionary<string, ICfgElem> m_cfgElemPool = null;
        Dictionary<string, ProviderCache> m_providers = null;
        ASStatue m_Statue = ASStatue.Running;

        private DBControl()
        {
            m_locker = new Dictionary<Guid, object>( );
        }

        /// <summary>
        /// Get Instance.
        /// </summary>
        /// <returns></returns>
        public static DBControl GetIns()
        {
            return instance;
        }

        #region IAS<IDBProvider> Members

        /// <summary>
        /// Get Provider
        /// </summary>
        /// <param name="KeyWord"></param>
        /// <returns></returns>
        public IDBProvider GetProvider(string KeyWord)
        {
            if ( m_Statue != ASStatue.Running ) throw new Exception( "The DBControl has been shutdowned." );
            //throw new NotImplementedException();
            if ( !m_providers.ContainsKey( KeyWord ) )
            {
                DBProvider dbp = (DBProvider)SunMkrConfig.Instance.GetElement( typeof( DBProvider ), KeyWord );
                if ( dbp == null ) return null;
                m_cfgElemPool.Add( KeyWord, dbp );
                ProviderCache pc = new ProviderCache( dbp.MaxConnection );
                m_providers.Add( KeyWord, pc );
                for ( int i = 0; i < dbp.MaxConnection; ++i )
                {
                    IDBProvider p = (IDBProvider)Activator.CreateInstance( TypeMap [dbp.DBType] );
                    //m_providers.Add( ref p );
                    pc.Add( ref p );
                }
            }
            while ( m_providers [KeyWord].IsEmpty ) ;
            IDBProvider prov = m_providers [KeyWord].Get( );
            prov.GenerateConnString((DBProvider)m_cfgElemPool[KeyWord]);
            return prov;
        }

        /// <summary>
        /// Release Provider
        /// </summary>
        /// <param name="KeyWord"></param>
        /// <param name="UsedProvider"></param>
        public void ReleaseProvider(string KeyWord, IDBProvider UsedProvider )
        {
            //throw new NotImplementedException();
            m_providers [KeyWord].Add( ref UsedProvider );
            if (m_locker.ContainsKey(UsedProvider.Key))
            {
                UsedProvider.UnLockLifeCycle(m_locker[UsedProvider.Key]);
                m_locker.Remove(UsedProvider.Key);
            }
        }

        /// <summary>
        /// Start Provider.
        /// </summary>
        /// <param name="CurrentProvider"></param>
        /// <returns></returns>
        public bool StartProvider(IDBProvider CurrentProvider)
        {
            if ( CurrentProvider.Start( ) )
            {
                m_locker.Add( CurrentProvider.Key, CurrentProvider.LockLifeCycle( ) );
                return true;
            }
            return false;
        }

        /// <summary>
        /// Statue of current AS
        /// </summary>
        public ASStatue Statue
        {
            get
            {
                //throw new NotImplementedException();
                return m_Statue;
            }
            set
            {
                //throw new NotImplementedException();
                m_Statue = value;
                if ( m_Statue == ASStatue.Stopped )
                    this.End( );
            }
        }

        #endregion

        #region ILifeCycle Members

        /// <summary>
        /// Start the AS.
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            m_cfgElemPool = new Dictionary<string, ICfgElem>( );
            m_providers = new Dictionary<string, ProviderCache>( );
            TypeMap = new Dictionary<DatabaseType, Type>( );

            // Create the map
            TypeMap.Add( DatabaseType.SQLDB, typeof( SQLDB ) );

            this.m_Statue = ASStatue.Running;
            return true;
        }

        /// <summary>
        /// Terminate the AS.
        /// </summary>
        /// <returns></returns>
        public bool End()
        {
            //throw new NotImplementedException();
            this.m_Statue = ASStatue.Stopped;
            m_cfgElemPool.Clear( );
            m_cfgElemPool = null;
            foreach ( ProviderCache iProv in m_providers.Values )
            {
                iProv.Clear( );
            }
            m_providers = null;
            TypeMap.Clear( );
            TypeMap = null;
            return true;
        }

        /// <summary>
        /// Restart the AS.
        /// </summary>
        /// <returns></returns>
        public bool Restart()
        {
            //throw new NotImplementedException();
            this.End( );
            return this.Start( );
        }

        #endregion

    }
}
