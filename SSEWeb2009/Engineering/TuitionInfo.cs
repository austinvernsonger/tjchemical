using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Department.Engineering
{
    [Serializable]
    public class TuitionInfo
    {
        #region Member Variables

        private string _studID = null;
        private double _actualMoney;
        private double _mustMoney;
        private string _paymentTerm = null;
        private string _paymentTime;
        private string _remark = null;
        private string _grade = null;
        private string _tSchoolID = null;
        private int _status = -1;
        private int _tuitionID = -1;

        #endregion

        #region Constructor

        public TuitionInfo() { }

        #endregion

        #region Public Properties

        public int TuitionID
        {
            set { _tuitionID = value; }
            get { return _tuitionID; }
        }

        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        public string Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }

        public string TSchoolID
        {
            set { _tSchoolID = value; }
            get { return _tSchoolID; }
        }

        public string StudID
        {
            set { _studID = value; }
            get { return _studID; }
        }

        public double ActualMoney
        {
            set { _actualMoney = value; }
            get { return _actualMoney; }
        }

        public double MustMoney
        {
            set { _mustMoney = value; }
            get { return _mustMoney; }
        }

        public string PaymentTerm
        {
            set { _paymentTerm = value; }
            get { return _paymentTerm; }
        }

        public string PaymentTime
        {
            set { _paymentTime = value; }
            get { return _paymentTime; }
        }

        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        #endregion

    }
}
