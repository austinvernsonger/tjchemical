using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Reservation.Sql
{
    class SqlupdateStuReservationInfo:ISql
    {
        string _stuid;
        int _dateindex;
        int _state;
        Boolean _ifpenalty;
        string _penaltyrecord;

        public SqlupdateStuReservationInfo(){}

        public SqlupdateStuReservationInfo(string stuid,int dateindex,int state)
        {
            _dateindex = dateindex;
            _stuid = stuid;
            _state = state;
            _ifpenalty = false;
            _penaltyrecord = "";
        }

        public SqlupdateStuReservationInfo(string stuid,int dateindex,int state,Boolean ifpenalty,string penaltyrecord)
        {
            _dateindex = dateindex;
            _stuid = stuid;
            _state = state;
            _ifpenalty = ifpenalty;
            _penaltyrecord = penaltyrecord;
        }

        public string GetSql()
        {
            if (!_ifpenalty)
            {
                return "update StuReservationInfo set ReservationState = " + _state + " where StuID = '" + _stuid + "' and DateIndex = " + _dateindex;
            }
            else
            {
                return "update StuReservationInfo set ReservationState = " + _state + ",IfPenalty = 1 ,PenaltyRecord = '" + _penaltyrecord +
                    "',PenaltySetTime = GETDATE() where StuID = '" + _stuid + "' and DateIndex = " + _dateindex;
            }
        }
    }
}
