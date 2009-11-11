using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.Repair
{
    public enum State{Fresh=0,Confirm=1,Cancel=2}
    public class StateCtrl
    {
        static string[] s ={ "报修中", "已确认", "已取消" };
        public static string ParseToString(int state)
        {
            if(state<=2 && state>=0)
            {
                return s[state];
            }
            else
            {
                return null;
            }
        }
        public static State ParseToEnumState(int state)
        {
            if (0 == state)
            {
                return State.Fresh;
            }
            else if (1 == state)
            {
                return State.Confirm;
            }
            else
            {
                return State.Cancel;
            }
        }
    }
}
