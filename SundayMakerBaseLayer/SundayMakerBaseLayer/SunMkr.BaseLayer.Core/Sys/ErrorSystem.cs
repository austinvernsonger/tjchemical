using System;
using System.Collections.Generic;
using System.Text;
using SunMkr.Kernel.CfgElem;
using SunMkr.Kernel;
using SunMkr.Com.Mail;
using SunMkr.Com.Literal;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;
using System.Threading;
using System.IO;

namespace SunMkr.Sys
{
    /// <summary>
    /// The System: Error Handler
    /// </summary>
    public static class ErrorSystem
    {
        static XmlDocument g_ErrorXml;
        static XmlNode g_root;
        static FileLocation g_FileLocation;
        static object lockObj;
        static object lockXml;
        static object [] lockCopy;
        static string g_ErrorPath;
        static ObjCache [] g_cache;
        static int g_cacheNo;
        static Dictionary<string, Exception> g_pool;
        static Queue<string> g_count;
        static object lockCount;

        /// <summary>
        /// Cache an Exception.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns>Error ID</returns>
        public static string CatchError( Exception exp )
        {
            if ( !IsStarted ) return string.Empty;
            XmlNode _exp = g_ErrorXml.CreateElement( "SunMkrExp" );

            XmlAttribute aTime = g_ErrorXml.CreateAttribute("Time");
            aTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            _exp.Attributes.Append(aTime);

            XmlAttribute aMessage = g_ErrorXml.CreateAttribute("Message");
            aMessage.InnerText = exp.Message;
            _exp.Attributes.Append(aMessage);

            XmlAttribute aTarget = g_ErrorXml.CreateAttribute("Target");
            aTarget.InnerText = exp.TargetSite.ReflectedType.FullName;
            _exp.Attributes.Append(aTarget);

            XmlAttribute aStackTrace = g_ErrorXml.CreateAttribute("StackTrace");
            aStackTrace.InnerText = exp.StackTrace;
            _exp.Attributes.Append(aStackTrace);

            lock ( lockObj )
            {
                if ( g_cache [g_cacheNo].IsFull )
                {
                    ThreadStart start = delegate { SaveErrors( g_cacheNo ); };
                    new Thread( start ).Start( );
                    g_cacheNo = ( g_cacheNo == 0 ) ? 1 : 0;
                }
            }
            lock ( lockCopy [g_cacheNo] )
            {
                g_cache [g_cacheNo].Add( ref _exp );
            }
            // Add to the pool
            lock ( lockCount )
            {
                if ( g_count.Count == 50 )
                {
                    g_pool.Remove( g_count.Dequeue( ) );
                }
                string _id = Guid.NewGuid( ).ToString( );
                g_pool.Add( _id, exp );
                g_count.Enqueue( _id );
                return _id;
            }
        }

        /// <summary>
        /// Write an ErrorMessage.
        /// </summary>
        /// <param name="ErrorMessage"></param>
        /// <returns>Error ID</returns>
        public static string CatchError( string ErrorMessage )
        {
            return CatchError( new Exception( ErrorMessage ) );
        }

        /// <summary>
        /// Get The Exception.
        /// </summary>
        /// <param name="ErrorID"></param>
        /// <returns></returns>
        public static Exception GetError( string ErrorID )
        {
            if (string.IsNullOrEmpty(ErrorID)) return new Exception("Invalidate ErrorID in SunMkr.Sys.ErrorSystem.GetError.");
            lock ( lockCount )
            {
                if ( g_pool.ContainsKey( ErrorID ) )
                    return g_pool [ErrorID];
                else return new Exception( "Out of Time. Please check the Error file." );
            }
        }

        /// <summary>
        /// Get Recent Error
        /// </summary>
        /// <returns></returns>
        public static RecentError [] GetRecentErrorList( )
        {
            List<RecentError> _lst = new List<RecentError>( );
            lock ( lockCount )
            {
                foreach ( string eId in g_pool.Keys )
                {
                    _lst.Add( new RecentError( 
                        g_pool [eId].Message, 
                        g_pool [eId].TargetSite.ReflectedType.FullName, 
                        eId ) );
                }
            }
            return _lst.ToArray( );
        }

        /// <summary>
        /// Initialize the System.
        /// </summary>
        /// <param name="FL"></param>
        public static void Initialize( FileLocation FL )
        {
            //Terminate();
            g_FileLocation = FL.Clone( ) as FileLocation;
            g_ErrorPath = FormatString.AppFormat( g_FileLocation.Path );

            // Create Error File.
            g_ErrorXml = new XmlDocument( );
            g_root = g_ErrorXml.CreateElement( "SunMkrErr" );
            g_ErrorXml.AppendChild( g_root );
            g_ErrorXml.Save( g_ErrorPath );

            lockObj = new object( );
            lockXml = new object( );
            lockCopy = new object [2];
            lockCopy[0] = new object();
            lockCopy[1] = new object();

            g_cache = new ObjCache [2];
            g_cache [0] = new ObjCache( 20 );
            g_cache [1] = new ObjCache( 20 );
            // User the first cache.
            g_cacheNo = 0;

            g_pool = new Dictionary<string, Exception>( );
            g_count = new Queue<string>( );
            lockCount = new object( );
        }

        /// <summary>
        /// Terminate the System.
        /// </summary>
        public static void Terminate( )
        {
            SaveErrors( 0 );
            SaveErrors( 1 );
            // End.
            g_ErrorXml = null;
            g_root = null;
        }

        /// <summary>
        /// Reset the File Location of the System.
        /// </summary>
        /// <param name="FL"></param>
        public static void ResetFileLocation( FileLocation FL )
        {
            Terminate( );
            Initialize( FL );
        }

        static bool IsStarted
        {
            get
            {
                return g_ErrorXml != null;
            }
        }

        static void SaveErrors( int CacheNo )
        {
            ObjCache objCache = new ObjCache( 20 );
            lock ( lockCopy [CacheNo] )
            {
                // Copy the cache.
                while ( !g_cache [CacheNo].IsEmpty )
                {
                    XmlNode node = g_cache [CacheNo].Get( );
                    objCache.Add( ref node );
                }
            }
            // Write to file
            lock ( lockXml )
            {
                while ( !objCache.IsEmpty )
                    g_root.AppendChild( objCache.Get( ) );
                try
                {
                    g_ErrorXml.Save( g_ErrorPath );
                    FileInfo fiErr = new FileInfo( g_ErrorPath );
                    if ( fiErr.Length > ( 1024 * 1024 ) )
                    {
                        fiErr.MoveTo( g_ErrorPath + DateTime.Now.ToString( "yyyy-MM-dd-hh-mm-ss" ) + ".backup" );
                        fiErr.Delete( );
                        g_root.RemoveAll( );
                    }
                }
                catch
                {
                    MailSender.Send( "push.chen@gmail.com", "ErrorReport", g_ErrorXml.ToString( ) );
                }
            }
        }
    }
}
