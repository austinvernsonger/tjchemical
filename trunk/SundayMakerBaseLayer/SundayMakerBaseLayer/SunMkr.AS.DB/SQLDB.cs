using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SunMkr.Kernel.CfgElem;

namespace SunMkr.AS
{
    /// <summary>
    /// SQL Database Provider.
    /// </summary>
    public class SQLDB : IDBProvider
    {
        string m_connectionstring = string.Empty;
        // Connection
        SqlConnection sqlConn;
        // Command
        SqlCommand sqlCmd;

        bool m_bLocked = false;

        private static string GenerateString( string Path, string Name, string UserName, string Password )
        {
            return string.Format(
                "Data Source={0};Persist Security Info=True;Initial Catalog={1};User ID={2};Password={3}",
                Path.Trim( ), Name.Trim( ), UserName.Trim( ), Password.Trim( ) );
        }

        #region IDBProvider Members

        /// <summary>
        /// Sets the connection string of the 
        /// </summary>
        public string ConnectionStr
        {
            set { m_connectionstring = value; }
        }

        /// <summary>
        /// Check if the connection is open.
        /// </summary>
        public bool IsStarted
        {
            get 
            {
                if ( sqlConn == null ) return false;
                if ( sqlConn.State != ConnectionState.Open ) return false;
                if ( sqlCmd == null )
                {
                    sqlConn.Close( );
                    return false;
                }
                return true;
                //return (sqlConn == null) ? false : sqlConn.State == ConnectionState.Open; 
            }
        }

        /// <summary>
        /// Generate Connection String.
        /// </summary>
        /// <param name="DBP"></param>
        public void GenerateConnString( DBProvider DBP )
        {
            if ( !this.IsStarted )
                this.ConnectionStr = GenerateString( DBP.DBPath, DBP.DBName, DBP.UserName, DBP.Password );
        }

        /// <summary>
        /// Generate Backup Connection String.
        /// </summary>
        /// <param name="DBB"></param>
        public void GenerateBackUpString( DBBackUp DBB )
        {
            if ( !this.IsStarted )
                this.ConnectionStr = GenerateString( DBB.DBPath, DBB.DBName, DBB.UserName, DBB.Password );
        }

        /// <summary>
        /// Execute the sql sentence.
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public object Execute( string Sql )
        {
            sqlCmd.CommandText = Sql;
            return sqlCmd.ExecuteNonQuery( );
        }

        /// <summary>
        /// Querying according to the SQL sentenct.
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public System.Data.DataSet Query( string Sql )
        {
            // Use SqlDataAdapter to execute the query
            SqlDataAdapter tmpAdapter = new SqlDataAdapter( Sql, this.sqlConn );
            DataSet rtnDataSet = new DataSet( );
            // Fill the dataset
            tmpAdapter.Fill( rtnDataSet );
            return rtnDataSet;
        }

        /// <summary>
        /// Producer.
        /// </summary>
        /// <param name="ProducerName"></param>
        /// <param name="HasReturnValue"></param>
        /// <param name="ReturnValue"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public System.Data.DataSet Producer( 
            string ProducerName, bool HasReturnValue, 
            out object ReturnValue, params object [] Parameters )
        {
            sqlCmd.CommandText = ProducerName;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCommandBuilder.DeriveParameters( sqlCmd );

            ReturnValue = System.Reflection.Missing.Value;

            // Fill parameters.
            int npcount = sqlCmd.Parameters.Count;
            for ( int i = 1; i < npcount; ++i )
            {
                sqlCmd.Parameters [i].Value = Parameters [i - 1];
            }

            // Use Adapter
            SqlDataAdapter tmpAdapter = new SqlDataAdapter( sqlCmd );
            DataSet rtnDataSet = new DataSet( );
            // Fill the DataSet
            tmpAdapter.Fill( rtnDataSet );

            if ( HasReturnValue ) ReturnValue = sqlCmd.Parameters [0].Value;

            // Reset
            sqlCmd.CommandType = CommandType.Text;
            return rtnDataSet;
        }

        /// <summary>
        /// Producer.
        /// </summary>
        /// <param name="ProducerName"></param>
        /// <param name="ReturnValue"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public System.Data.DataSet Producer( 
            string ProducerName, out object ReturnValue, params object [] Parameters )
        {
            return Producer( ProducerName, true, out ReturnValue, Parameters );
        }

        /// <summary>
        /// Producer.
        /// </summary>
        /// <param name="ProducerName"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public System.Data.DataSet Producer( string ProducerName, params object [] Parameters )
        {
            object _obj;
            return Producer( ProducerName, false, out _obj, Parameters );
        }

        /// <summary>
        /// Trans Action with the provider's connection and command
        /// </summary>
        /// <param name="DelegateTransaction"></param>
        /// <returns></returns>
        public bool Transaction( delDoTransaction DelegateTransaction )
        {
            // Bind the transaction
            SqlTransaction transAction = sqlConn.BeginTransaction( );
            sqlCmd.Transaction = transAction;

            try
            {
                // Do the methods
                DelegateTransaction( );
                transAction.Commit( );
            }
            catch ( System.Exception e )
            {
                // Error!
                transAction.Rollback( );
                // Throw this exception and let cc to get
                throw e;
            }
            return true;
        }

        #endregion

        #region ILifeCycle Members

        /// <summary>
        /// Start the connection.
        /// </summary>
        /// <returns></returns>
        public bool Start( )
        {
            if ( m_bLocked ) return false;
            // Check if current provider has connected to the database
            if ( this.IsStarted ) return true;
            // Create the connection
            this.sqlConn = new SqlConnection( m_connectionstring );
            // on error throw any exception
            // will be caught by ErrorSystem
            this.sqlConn.Open( );
            //this.beConnected = true;
            this.sqlCmd = new SqlCommand( );
            this.sqlCmd.Connection = this.sqlConn;
            return true;
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        /// <returns></returns>
        public bool End( )
        {
            if ( m_bLocked ) return false;
            if ( !this.IsStarted ) return true;
            // Release the connection
            this.sqlConn.Close( );

            return true;
        }

        /// <summary>
        /// Restart the connection
        /// </summary>
        /// <returns></returns>
        public bool Restart( )
        {
            if ( m_bLocked ) return false;
            //throw new NotImplementedException( );
            this.End( );
            return this.Start( );
        }

        #endregion


        #region IProvider Members

        Guid m_key = Guid.NewGuid( );

        /// <summary>
        /// The Guid to identified the token.
        /// </summary>
        public Guid Key
        {
            get { return m_key; }
        }

        #endregion

        #region ILock Members

        /// <summary>
        /// Lock the Life cycle
        /// </summary>
        /// <returns></returns>
        public object LockLifeCycle( )
        {
            //throw new NotImplementedException( );
            m_bLocked = true;
            return m_key;
        }

        /// <summary>
        /// UnLock Life Cycle.
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public bool UnLockLifeCycle( object Token )
        {
            //throw new NotImplementedException( );
            if ( m_key != new Guid( Token.ToString( ) ) )
                return false;
            m_bLocked = false;
            return true;
        }

        #endregion
    }
}
