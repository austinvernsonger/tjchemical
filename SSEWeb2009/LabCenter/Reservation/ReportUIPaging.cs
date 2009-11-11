using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace LabCenter.Reservation
{
    public class ReportUIPaging
    {
        public DataSet GetReportsDataSet()
        {
            int _term, _name;
            string _number;
            if (HttpContext.Current.Cache["term"] == null
                && HttpContext.Current.Cache["name"] == null
                && HttpContext.Current.Cache["number"] == null)
            {
                return null;
            }
            else
            {
                if (HttpContext.Current.Cache["term"] != null
                    && HttpContext.Current.Cache["name"] == null
                    && HttpContext.Current.Cache["number"] == null)
                {
                    _term = (int)HttpContext.Current.Cache["term"];
                    return BackManager.GetReportsByTerm(_term);
                }
                else if (HttpContext.Current.Cache["term"] != null
                    && HttpContext.Current.Cache["name"] != null
                    && HttpContext.Current.Cache["number"] == null)
                {
                    _term = (int)HttpContext.Current.Cache["term"];
                    _name = (int)HttpContext.Current.Cache["name"];
                    return BackManager.GetReportByTNa(_term, _name);
                }
                else if (HttpContext.Current.Cache["term"] != null
                    && HttpContext.Current.Cache["name"] != null
                    && HttpContext.Current.Cache["number"] != null)
                {
                    _term = (int)HttpContext.Current.Cache["term"];
                    _name = (int)HttpContext.Current.Cache["name"];
                    _number = (string)HttpContext.Current.Cache["number"];
                    return BackManager.GetReportByTNN(_term, _name, _number);
                }
                else if (HttpContext.Current.Cache["term"] == null
                    && HttpContext.Current.Cache["name"] != null
                    && HttpContext.Current.Cache["number"] != null)
                {
                    _name = (int)HttpContext.Current.Cache["name"];
                    _number = (string)HttpContext.Current.Cache["number"];
                    return BackManager.GetReportByNN(_name, _number);
                }
                else if (HttpContext.Current.Cache["term"] == null
                    && HttpContext.Current.Cache["name"] == null
                    && HttpContext.Current.Cache["number"] != null)
                {
                    _number = (string)HttpContext.Current.Cache["number"];
                    return BackManager.GetReportByNo(_number);
                }
                else if (HttpContext.Current.Cache["term"] == null
                    && HttpContext.Current.Cache["name"] != null
                    && HttpContext.Current.Cache["number"] == null)
                {
                    _name = (int)HttpContext.Current.Cache["name"];
                    return BackManager.GetReportByName(_name);
                }
                else if (HttpContext.Current.Cache["term"] != null
                    && HttpContext.Current.Cache["name"] == null
                    && HttpContext.Current.Cache["number"] != null)
                {
                    _term = (int)HttpContext.Current.Cache["term"];
                    _number = (string)HttpContext.Current.Cache["number"];
                    return BackManager.GetReportByTNo(_term, _number);
                }
            }
            return null;
        }

        static ReportUIPaging()
        {
        }

        public void UpdateReports(string StuID, string ExperimentName, Boolean ReportState)
        {
            BackManager.UpdateReportState(StuID, ExperimentName, ReportState);
        }
    }
}
