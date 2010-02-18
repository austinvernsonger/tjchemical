using System;
using System.Collections.Generic;
using System.Text;

namespace SysCom.Ops
{
    class doProducer : SMBL.Operation.DBOperation
    {
        private doProducer( string ProducerName, object [] Params )
        {
            BindDBName = "TjMedical";
            _params = Params;
            _p_name = ProducerName;
        }
        string _p_name = string.Empty;
        object [] _params;

        public override void processDelegate( )
        {
            myProcessor.Producer( _p_name, _params );
            //base.processDelegate( );
        }

        public static bool DoProc(string P_Name, params object [] Parameters)
        {
            doProducer _do = new doProducer( P_Name, Parameters );
            return _do.Do( );
        }
    }
}
