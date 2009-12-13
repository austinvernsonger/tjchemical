using System;
using System.Collections.Generic;
using System.Text;
using SunMkr.Proc;
using SunMkr.Sys;

namespace SunMkr.Kernel
{
    /// <summary>
    /// The Main Platform of SunMkr
    /// </summary>
    public class Platform : ILifeCycle
    {
        private static Platform platform = new Platform();

        /// <summary>
        /// Private Construction to make the 
        /// </summary>
        private Platform()
        {
        }

        /// <summary>
        /// Get the instance of the platform
        /// </summary>
        public static Platform Instance
        {
            get { return platform; }
        }

        #region ILifeCycle Members

        /// <summary>
        /// Start the platform
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            //throw new NotImplementedException();
            // Load the config file.
            if ( !SunMkrConfig.Instance.Start( ) )
                return false;
            // Initialize Error System.
            CfgElem.FileLocation fl = (CfgElem.FileLocation)SunMkrConfig.Instance.GetElement( 
                typeof( CfgElem.FileLocation ), "ErrorSystem" );
            ErrorSystem.Initialize( fl );

            // Initialize control center.
            Proc.ControlCenter.Initialize( );

            // Initialize the AS
            if (!ASLoader.Initialize()) return false;
            
            return true;
        }

        /// <summary>
        /// Terminate the platform
        /// </summary>
        /// <returns></returns>
        public bool End()
        {
            //throw new NotImplementedException();

            // Terminate the AS.
            ASLoader.Terminate();
            // Terminate the Error System.
            ErrorSystem.Terminate( );
            // Release the config file.
            SunMkrConfig.Instance.End( );
            return true;
        }

        /// <summary>
        /// Restart the platform
        /// </summary>
        /// <returns></returns>
        public bool Restart()
        {
            //throw new NotImplementedException();

            this.End( );
            this.Start( );
            return true;
        }

        #endregion
    }
}
